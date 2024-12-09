namespace IntroduccionAEFCore.Modelos
{
    public class Genero
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Pelicula> Peliculas { get; set;} = new HashSet<Pelicula>();
    }
}
