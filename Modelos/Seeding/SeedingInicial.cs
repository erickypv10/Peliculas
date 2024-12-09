using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Modelos.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJackson = new Actor()
            {
                Id = 2, 
                Name = "Samuel L. Jackson", 
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 15000 
            };
            var RobertDowneyJunior = new Actor()
            {
                Id = 3,
                Name = "Robert Downey Jr.",
                FechaNacimiento = new DateTime(1965, 4, 4),
                Fortuna = 18000,
            };

            modelBuilder.Entity<Actor>().HasData(samuelLJackson, RobertDowneyJunior);

            var avengers = new Pelicula()
            {
                Id = 2,
                Titulo = "Avengers Endgame",
                FechaEstreno = new DateTime(2019, 4, 22),
            };

            var spiderManNWH = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No Way Home",
                FechaEstreno = new DateTime(2021, 12, 13),
            };
            var spiderManSpiderVerse2 = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Across the Spider-Verse (Part One)",
                FechaEstreno = new DateTime(2022, 10, 7),
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers,  spiderManNWH, spiderManSpiderVerse2);


            var comentarioAvengers = new Comentario()
            {
                id = 2,
                Recomendar = true,
                Contenido = "Muy Buena!!",
                PeliculaId = avengers.Id,
            };

            var comentarioAvenger2 = new Comentario()
            {
                id = 3,
                Recomendar = true,
                Contenido = "Dura dura",
                PeliculaId = avengers.Id,
            };

            var comentarioNWH = new Comentario()
            {
                id = 4,
                Recomendar = false,
                Contenido = "no debieron hacer eso....",
                PeliculaId = spiderManNWH.Id,
            };
            modelBuilder.Entity<Comentario>().HasData(comentarioAvengers,comentarioAvenger2, comentarioNWH);

            //relacion muchos a muchos con salto

            var tablaGeneroPelicula = "GeneroPelicula";
            var GeneroIdPropiedad = "GenerosId";
            var PeliculaIdpropiedad = "PeliculasId";

            var CienciaFiccion = 5;
            var animacion = 6;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object>
                {
                    [GeneroIdPropiedad] = CienciaFiccion,
                    [PeliculaIdpropiedad] = avengers.Id
                },
                new Dictionary<string, object>
                {
                    [GeneroIdPropiedad] = CienciaFiccion,
                    [PeliculaIdpropiedad] = spiderManNWH.Id
                },
                new Dictionary<string, object>
                {
                    [GeneroIdPropiedad] = animacion,
                    [PeliculaIdpropiedad] = spiderManSpiderVerse2.Id
                }

                );
            //relacion muchos a muchos sin salto

            var samuelLJacksonSpiderManNWH = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = spiderManNWH.Id,
                Orden = 1,
                Personaje = "Nick Fury",
            };
            var samuelLJacksonAvengers = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Nick Fury",
            };
            var robertDowneyJuniorAvengers = new PeliculaActor
            {
                ActorId = RobertDowneyJunior.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Iron Man",
            };

            modelBuilder.Entity<PeliculaActor>()
                .HasData(samuelLJacksonAvengers, 
                samuelLJacksonSpiderManNWH, 
                robertDowneyJuniorAvengers);


        }

    }
}
