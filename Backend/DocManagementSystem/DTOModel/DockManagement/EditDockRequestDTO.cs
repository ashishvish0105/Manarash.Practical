namespace DocManagementSystem.DTOModel.DockManagement
{
    public class EditDockRequestDTO
    {
        public int DockId { get; set; }
        public required string Name { get; set; }
        public required int TypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
