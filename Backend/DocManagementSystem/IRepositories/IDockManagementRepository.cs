using DocManagementSystem.DTOModel.DockManagement;

namespace DocManagementSystem.IRepositories
{
    public interface IDockManagementRepository
    {
        public Task<int> DeleteDock(int id);
        public Task<GetDockDTO?> GetDock(int id);
        public Task<List<GetDockDTO>> GetDocks();
        public Task<int> EditDock(int id, EditDockRequestDTO dock);
        public Task<int> CreateDock(CreateDockRequestDTO dock);
        public Task<int> ChangeIsActive(int id, bool isActive);
        public Task<GetDockDTOPagination> GetDockPagination(int page = 1, int pageSize = 10, string? filter = null);
    }
}
