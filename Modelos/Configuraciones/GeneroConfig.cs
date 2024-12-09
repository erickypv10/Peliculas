using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionAEFCore.Modelos.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            var cienciaficcion = new Genero { Id = 5, Name = "Ciencia Ficcion" };
            var animacion = new Genero { Id = 6, Name = "Animacion" };
            builder.HasData(cienciaficcion, animacion);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
