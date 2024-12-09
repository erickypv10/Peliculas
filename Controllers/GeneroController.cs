using AutoMapper;
using IntroduccionAEFCore.Data;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Controllers
{
    [ApiController]
    [Route("api/genero")]
    public class GeneroController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GeneroController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult> Post (GeneroCreacionDTO generoCreacion)
        {
            var YaExisteUnGeneroConEsteNombre = await context.Generos.AnyAsync(g =>
            g.Name == generoCreacion.Name);
            if (YaExisteUnGeneroConEsteNombre)
            {
                return BadRequest("Ya existe un genero con este nombre "  +  generoCreacion.Name);
            }
            var genero = mapper.Map<Genero>(generoCreacion);
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generoCreacionDTO)
        {
            var generos = mapper.Map<Genero[]>(generoCreacionDTO);
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);
            if(genero is null)
            {
                return NotFound();
            }

            genero.Name = genero.Name + "2";

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id=int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            genero.Id = id;
            context.Update(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAlteradas = await context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();
            if (FilasAlteradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
