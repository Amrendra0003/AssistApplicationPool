using Healthware.Core.Base;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IPatientRepository
    {
        Task<long> CreatePatient(Entities.Patient patient);
    }
    public class PatientRepository: IPatientRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public PatientRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreatePatient(Entities.Patient patient)
        {
            await _unitOfWork.AddAsync(patient);
            await _unitOfWork.CommitAsync();
            return patient.Id; 
        }
    }
}
