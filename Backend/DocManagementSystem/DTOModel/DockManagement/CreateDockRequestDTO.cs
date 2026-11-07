using System.ComponentModel.DataAnnotations;

namespace DocManagementSystem.DTOModel.DockManagement
{
    public record CreateDockRequestDTO
    {
        public required string Name { get; set; }
        public required int TypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
