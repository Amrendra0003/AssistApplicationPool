using Healthware.Core.Base;
using Healthware.Core.Extensions;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IRoleRepository : IRoleStore<Healthware.Core.Entities.Role>
    {
    }
    public class RoleRepository : IRoleRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public RoleRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
        }

        public async Task<IdentityResult> CreateAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            await _unitOfWork.AddAsync(role);
            await _unitOfWork.CommitAsync(cancellationToken);
            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> UpdateAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            _unitOfWork.Update(role);
            await _unitOfWork.CommitAsync(cancellationToken);
            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            _unitOfWork.Remove(role);
            await _unitOfWork.CommitAsync(cancellationToken);
            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<string> GetRoleIdAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            var roleResult = _unitOfWork.GetEntities<Healthware.Core.Entities.Role>().FirstOrDefault(r => r.Id == role.Id);
            return await Task.FromResult(roleResult?.Id.ToString());
        }

        public async Task<string> GetRoleNameAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            var roleResult = _unitOfWork.GetEntities<Healthware.Core.Entities.Role>().FirstOrDefault(r => r.RoleName == role.RoleName);
            return await Task.FromResult(roleResult.IsNull() ? role?.RoleName : String.Empty);
        }

        public async Task SetRoleNameAsync(Healthware.Core.Entities.Role role, string roleName, CancellationToken cancellationToken)
        {
            role.RoleName = roleName;
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<string> GetNormalizedRoleNameAsync(Healthware.Core.Entities.Role role, CancellationToken cancellationToken)
        {
            var roleResult = _unitOfWork.GetEntities<Healthware.Core.Entities.Role>().FirstOrDefault(r => r.RoleName == role.RoleName);
            return await Task.FromResult(roleResult?.RoleName);
        }

        public async Task SetNormalizedRoleNameAsync(Healthware.Core.Entities.Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.RoleName = normalizedName;
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<Healthware.Core.Entities.Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetEntityAsync<Healthware.Core.Entities.Role>(x => x.Id == long.Parse(roleId));
            return role;
        }

        public async Task<Healthware.Core.Entities.Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetEntityAsync<Healthware.Core.Entities.Role>(x => x.RoleName == normalizedRoleName);
            return role;
        }
    }
}
