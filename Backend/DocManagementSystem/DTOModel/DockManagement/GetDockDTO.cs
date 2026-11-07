namespace DocManagementSystem.DTOModel.DockManagement
{
    public class GetDockDTO
    {
        public int DockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; } = 0;
        public bool IsActive { get; set; }
    }
}
