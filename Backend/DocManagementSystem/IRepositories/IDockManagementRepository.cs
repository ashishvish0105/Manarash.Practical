using DocManagementSystem.DTOModel.DockManagement;

namespace DocManagementSystem.IRepositories
{
    public interface IDockManagementRepository
    {
        public Task<int> DeleteDock(int id);
        public Task<GetDockDTO> GetDock(int id);
        public Task<List<GetDockDTO>> GetDocks();
        public Task<int> EditDock(int id, EditDockRequestDTO dock);
        public Task<int> CreateDock(CreateDockRequestDTO dock);
    }
}
