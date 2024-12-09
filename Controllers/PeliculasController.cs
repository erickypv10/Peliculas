using AutoMapper;
using IntroduccionAEFCore.Data;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IntroduccionAEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Comentarios)
                .Include(p => p.Generos)
                .Include(p => p.PeliculasActores.OrderBy(pa => pa.Orden))
                .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula is null)
            {
                return NotFound();
            }
            return pelicula;
        }

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var pelicula = await context.Peliculas
                .Select(pel => new
                {
                    pel.Id,
                    pel.Titulo,
                    Generos = pel.Generos.Select(g => g.Name).ToList(),
                    Actores = pel.PeliculasActores.OrderBy(pa => pa.Orden).Select(pa => new
                    {
                        Id = pa.ActorId,
                        pa.Actor.Name,
                        pa.Personaje,
                    }),
                    CantidadComentarios = pel.Comentarios.Count()
                })
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula is null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if(pelicula.Generos is not null) {
            foreach(var genero in  pelicula.Generos)
                {
                    context.Entry(genero).State = EntityState.Unchanged;
                }
            }

            if(pelicula.PeliculasActores is not null)
            {
                for(int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i+1;
                }
            }
            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();

        }


        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAlteradas = await context.Peliculas.Where(g => g.Id == id).ExecuteDeleteAsync();
            if (FilasAlteradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
