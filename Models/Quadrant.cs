using System.ComponentModel.DataAnnotations;

namespace junkiesWeb.Models
{
    public class Quadrant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
