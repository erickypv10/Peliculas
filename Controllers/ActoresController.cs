using AutoMapper;
using AutoMapper.QueryableExtensions;
using IntroduccionAEFCore.Data;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ActoresController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.OrderByDescending(a => a.FechaNacimiento).ToListAsync();
        }

        [HttpGet("Nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string Name)
        {
            return await context.Actores.Where(a => a.Name == Name).OrderBy(a => a.Name)
                .ThenByDescending(a => a.FechaNacimiento).ToListAsync();
        }

        [HttpGet("Nombre/V2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string Name)
        {
            return await context.Actores.Where(a => a.Name.Contains(Name)).ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime inicio, DateTime fin)
        {
            return await context.Actores
                .Where(a => a.FechaNacimiento >= inicio && a.FechaNacimiento <= fin)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
           var actor = await context.Actores.FirstOrDefaultAsync(a => a.Id == id);
           if(actor is null)
            {
                return NotFound();
            }
           return actor;
        }

        [HttpGet("idynombre")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdyNombre()
        {
           return await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
           
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
