﻿using AutoMapper;
using IntroduccionAEFCore.Data;
using IntroduccionAEFCore.DTOs;
using IntroduccionAEFCore.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionAEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    public class ComentarioController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ComentarioController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int peliculaId, ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId = peliculaId;
            context.Add(comentario);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
