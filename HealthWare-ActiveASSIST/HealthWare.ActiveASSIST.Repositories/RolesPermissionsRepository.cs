using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IRolesPermissionsRepository
    {
        public Task<List<RolesPermission>> GetRolesPermissionByRoleId(long roleId);
        public Task<bool> DeleteAsync(RolesPermission rolePermission);
        public Task<bool> CreateAsync(RolesPermission rolePermission);
    }
    class RolesPermissionsRepository : IRolesPermissionsRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public RolesPermissionsRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(RolesPermission rolePermission)
        {
            _unitOfWork.Attach(rolePermission.Role);
            _unitOfWork.Attach(rolePermission.Permission);
            await _unitOfWork.AddAsync(rolePermission);
            return await _unitOfWork.CommitAsync();
        }


        public async Task<bool> DeleteAsync(RolesPermission rolePermission)
        {
            _unitOfWork.Remove<RolesPermission>(rolePermission);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<List<RolesPermission>> GetRolesPermissionByRoleId(long roleId)
        {
            var rolePermissions = await _unitOfWork.GetAllAsync<RolesPermission>(x => x.Role.Id == roleId);

            return rolePermissions.ToList();
        }

    }
}
