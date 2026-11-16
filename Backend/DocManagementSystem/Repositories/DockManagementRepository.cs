using DocManagementSystem.Data;
using DocManagementSystem.DTOModel.DockManagement;
using DocManagementSystem.Entities;
using DocManagementSystem.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace DocManagementSystem.Repositories
{
    public class DockManagementRepository: IDockManagementRepository
    {
        private readonly DMSDBContext _dbContext;

        public DockManagementRepository(DMSDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateDock(CreateDockRequestDTO dock)
        {
            var entity = new DockEntity
            {
                Name = dock.Name,
                TypeId = dock.TypeId,
                IsActive = dock.IsActive,
                CreatedAt = DateTime.Now
            };
            _dbContext.Docks.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> EditDock(int id, EditDockRequestDTO dock)
        {

            var dockEntity = await _dbContext.Docks.FindAsync(id);

            if (dockEntity == null)
            {
                return 0;
            }

            dockEntity.Name = dock.Name;
            dockEntity.TypeId = dock.TypeId;
            dockEntity.IsActive = dock.IsActive;
            dockEntity.LastUpdatedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync();
        }
        public async Task<List<GetDockDTO>> GetDocks()
        {
            return await _dbContext.Docks.Select(d => new GetDockDTO
            {
                DockId = d.DockId,
                Name = d.Name,
                TypeId = d.TypeId,
                IsActive = d.IsActive
            }).ToListAsync();
        }

        public async Task<GetDockDTOPagination> GetDockPagination(int page =1, int pageSize=10,string ?filter=null)
        {
            //            var result = await (
            //    from d in _dbContext.Docks
            //    join b in _dbContext.Bookings on d.DockId equals b.DockId
            //    where d.IsActive == true
            //    select new
            //    {
            //        OrderId = d.DockId,
            //        CustomerName = b.CompanyName,
            //        ProductName = b.GeneratedReferenceNumber
            //    }
            //).ToListAsync();

            // Console.WriteLine(result);

            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            IQueryable<DockEntity> returnQuery = _dbContext.Docks
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                returnQuery = returnQuery.Where(x =>
                    x.Name.Contains(filter));
            }

            var totalRecord = await returnQuery.CountAsync();

            var returnResponse = await returnQuery
                .OrderByDescending(d => d.DockId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new GetDockDTO
                {
                    DockId = d.DockId,
                    Name = d.Name,
                    TypeId = d.TypeId,
                    IsActive = d.IsActive
                })
                .ToListAsync();

            return new GetDockDTOPagination
            {
                TotalCount = totalRecord,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(
                    (double)totalRecord / pageSize),
                GetDockDTO = returnResponse
            };

        }
        public async Task<GetDockDTO?> GetDock(int id)
        {
           
            var dockEntity = await _dbContext.Docks.FindAsync(id);
            //var dockEntity = await _dbContext.Docks.FirstOrDefaultAsync(x => x.DockId == id);
            if (dockEntity == null)
            {
                return null;
            }

            return new GetDockDTO
            {
                DockId = dockEntity.DockId,
                Name = dockEntity.Name,
                TypeId = dockEntity.TypeId,
                IsActive = dockEntity.IsActive
            };
        }
        public async Task<int> DeleteDock(int id)
        {
          
            var dockEntity = await _dbContext.Docks.FindAsync(id);

            if (dockEntity == null)
            {
                return 0;
            }

            _dbContext.Docks.Remove(dockEntity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> ChangeIsActive(int id, bool isActive)
        {
            var dockEntity = await _dbContext.Docks.FindAsync(id);

            if (dockEntity == null)
            {
                return 0;
            }
            dockEntity.IsActive = isActive;
            dockEntity.LastUpdatedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync();
        }
    }
}
