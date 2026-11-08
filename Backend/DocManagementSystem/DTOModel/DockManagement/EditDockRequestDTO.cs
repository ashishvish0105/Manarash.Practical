using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.DTOModel.DockManagement
{
    public record EditDockRequestDTO
    {
        public int DockId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int TypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
