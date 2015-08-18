using System.ComponentModel.DataAnnotations;

namespace junkiesWeb.Models
{
    public class Ship
    {
        public int Id { get; set; }
        [Required]
        public int SectorId { get; set; }
    }
}
