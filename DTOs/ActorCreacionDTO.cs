using System.ComponentModel.DataAnnotations;

namespace IntroduccionAEFCore.DTOs
{
    public class ActorCreacionDTO
    {
        [StringLength(150)]
        public string Name { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public decimal Fortuna { get; set; }
    }
}
