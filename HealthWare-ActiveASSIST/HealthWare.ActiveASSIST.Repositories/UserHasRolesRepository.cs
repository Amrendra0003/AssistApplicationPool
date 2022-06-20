using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IUserHasRolesRepository
    {
        Task<Healthware.Core.Entities.UserHasRoles> GetUserRoleByUserId(long userId);
        Task<long> CreateUserRole(Healthware.Core.Entities.UserHasRoles userHasRole);
    }
    public class UserHasRolesRepository : IUserHasRolesRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public UserHasRolesRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Healthware.Core.Entities.UserHasRoles> GetUserRoleByUserId(long userId)
        {
            var userHasRoles = await _unitOfWork.GetEntityAsync<Healthware.Core.Entities.UserHasRoles>(y => y.User.Id == userId);
            return userHasRoles;
        }

        public async Task<long> CreateUserRole(Healthware.Core.Entities.UserHasRoles userHasRole)
        {
            _unitOfWork.Attach(userHasRole.User);
            _unitOfWork.Attach(userHasRole.Role);
            await _unitOfWork.AddAsync(userHasRole);
            await _unitOfWork.CommitAsync();
            return userHasRole.Id;
        }
    }
}
