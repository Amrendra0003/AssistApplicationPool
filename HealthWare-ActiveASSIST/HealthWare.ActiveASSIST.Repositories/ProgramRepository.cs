using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;
using System.Threading;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IProgramRepository
    {
        Task<IEnumerable<Program>> GetAllPrograms();
        Task<Program> GetProgramDetailsById(long programId);
        Task<long> CreateProgram(Program program);
        Task<Program> GetProgramByName(string programName);
    }
    public class ProgramRepository : IProgramRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public ProgramRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Program>> GetAllPrograms()
        {
            var programList = await _unitOfWork.GetAllAsync<Program>();
            return programList;
        }
        public async Task<Program> GetProgramDetailsById(long programId)
        {
            var program = await _unitOfWork.GetEntityAsync<Program>(x => x.Id == programId);
            return program;
        }
        public async Task<long> CreateProgram(Program program)
        {
            await _unitOfWork.AddAsync(program);
            await _unitOfWork.CommitAsync();
            return program.Id;
        }
        public async Task<Program> GetProgramByName(string programName)
        {
            var program = await _unitOfWork.GetEntityAsync<Program>(x => x.Name == programName);
            return program;
        }
    }
}
