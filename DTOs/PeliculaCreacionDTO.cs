namespace IntroduccionAEFCore.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCine { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Genero {  get; set; } = new List<int>();
        public List<PeliculaActorCreacionDTO> PeliculasActores { get; set; } =
        new List<PeliculaActorCreacionDTO>();
    }
}
