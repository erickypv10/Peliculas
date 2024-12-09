namespace IntroduccionAEFCore.Modelos
{
    public class Comentario
    {
        public int id {  get; set; }
        public string? Contenido { get; set; }
        public bool Recomendar {  get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
    }
}
