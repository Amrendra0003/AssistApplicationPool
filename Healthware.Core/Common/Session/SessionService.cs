using System.Threading.Tasks;
using Healthware.Core.Common.Session.Mapper;
using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Common.Session
{
    public interface ISessionService<TK> where TK : DbContext
    {
        Task<SessionActivity> InitiateSession(MainUser user);
        Task<Result<MessageDto>> IsSessionActive(long userId);
        Task<Result<MessageDto>> IsSessionActiveBySessionId(long sessionId);
    }
    public class SessionService<TK> : ISessionService<TK> where TK : DbContext
    {
        private readonly ISessionMapper _sessionMapper;
        private readonly ISessionActivityRepository<TK> _sessionActivityRepository;
        public SessionService(ISessionMapper sessionMapper, ISessionActivityRepository<TK> sessionActivityRepository)
        {
            _sessionMapper = sessionMapper;
            _sessionActivityRepository = sessionActivityRepository;
        }
        public async Task<SessionActivity> InitiateSession(MainUser user)
        {
            var sessionActivity = _sessionMapper.MapFrom(user);
            SessionActivity sessionEntity;

            var isActiveSessionExists = await _sessionActivityRepository.FindActiveSessionExists(user.Id);
            if (isActiveSessionExists)
            {
                var isSessionDeactivated = await _sessionActivityRepository.DeactivateTheSession(user.Id);
            }
            sessionEntity = await _sessionActivityRepository.InitiateSession(sessionActivity);
            return sessionEntity;
        }

        public async Task<Result<MessageDto>> IsSessionActive(long userId)
        {
            var result = await _sessionActivityRepository.IsSessionActive(userId);
            return result ? new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.HasActiveSession) } : new Result<MessageDto>().AddError(Error.DoesNotHaveActiveSession);
        }

        public async Task<Result<MessageDto>> IsSessionActiveBySessionId(long sessionId)
        {
            var result = await _sessionActivityRepository.IsSessionActiveBySessionId(sessionId);
            return result ? new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.HasActiveSession) } : new Result<MessageDto>().AddError(Error.DoesNotHaveActiveSession);
        }
    }
}
