using System.Drawing.Printing;

namespace DocManagementSystem.DTOModel.DockManagement
{
    public record GetDockDTO
    {
        public int DockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; } = 0;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public record GetDockDTOPagination
    {
        public List<GetDockDTO> GetDockDTO { get; set; } = new List<GetDockDTO>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
