using Healthware.Core.Base;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Repository
{
    public interface ISessionActivityRepository<TK> where TK : DbContext
    {
        Task<bool> FindActiveSessionExists(long userId);
        Task<SessionActivity> InitiateSession(SessionActivity sessionActivity);
        Task<bool> IsSessionActive(long userId);
        Task<bool> DeactivateTheSession(long userId);
        Task<bool> IsSessionActiveBySessionId(long sessionId);
    }

    public class SessionActivityRepository<TK> : ISessionActivityRepository<TK> where TK : DbContext
    {
        private readonly IUnitOfWork<TK> _unitOfWork;

        public SessionActivityRepository(IUnitOfWork<TK> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> FindActiveSessionExists(long userId)
        {
            var activeSessionList =
                await _unitOfWork.GetAllAsync<SessionActivity>(y => y.User.Id == userId && y.Active == true);
            return activeSessionList.Count() > 0;

        }

        public async Task<SessionActivity> InitiateSession(SessionActivity sessionActivity)
        {
            _unitOfWork.Attach(sessionActivity.User);
            await _unitOfWork.AddAsync(sessionActivity);
            await _unitOfWork.CommitAsync();
            return sessionActivity.Id > 0 ? sessionActivity : null;
        }

        public async Task<bool> IsSessionActive(long userId)
        {
            var activeSessionList =
                await _unitOfWork.GetAllAsync<SessionActivity>(y => y.User.Id == userId && y.Active == true);
            return activeSessionList.Count() > 0;
        }

        public async Task<bool> DeactivateTheSession(long userId)
        {
            var activeSession =
                await _unitOfWork.GetEntityAsync<SessionActivity>(y => y.User.Id == userId && y.Active == true);
            if (activeSession == null)
            {
                return false;
            }

            activeSession.Active = false;
            _unitOfWork.Update(activeSession);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> IsSessionActiveBySessionId(long sessionId)
        {
            var activeSessionList =
                await _unitOfWork.GetAllAsync<SessionActivity>(y => y.Id == sessionId && y.Active == true);
            return activeSessionList.Count() > 0;
        }
    }
}
