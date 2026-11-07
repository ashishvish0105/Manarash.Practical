using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.Entities
{
    public class DockEntity
    {
        [Key]
        public int DockId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
    }
}
