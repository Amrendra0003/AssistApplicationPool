using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Base;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IDropDownService
    {
        Task<Result<Dictionary<string, string>>> GetDropDownValues<T>() where T : class;
        Task<Result<Dictionary<string, string>>> GetReasonNoSsn();

    }
    public class DropDownService : IDropDownService
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public DropDownService(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Dictionary<string, string>>> GetDropDownValues<T>() where T : class
        {
            var keyValuePair = await _unitOfWork.GetAllAsync<T>();
            if (keyValuePair.IsNull()) return new Result<Dictionary<string, string>>().AddError(Constants.ErrorReadingDataFromDatabase);
            var dropDownValueDictionary = keyValuePair.ToDictionary(x => x.GetType().GetProperty(Constants.KeyName).GetValue(x).ToString().Trim(), y => y.GetType().GetProperty(Constants.Value).GetValue(y).ToString().Trim());
            return new Result<Dictionary<string, string>>()
            { Data = dropDownValueDictionary };
        }

        public async Task<Result<Dictionary<string, string>>> GetReasonNoSsn()
        {
            var keyValuePair = await _unitOfWork.GetAllAsync<ReasonNoSsn>();
            if (keyValuePair.IsNull()) return new Result<Dictionary<string, string>>().AddError(Constants.ErrorReadingDataFromDatabase);

            var dropDownValueDictionary = keyValuePair.ToDictionary(x => x.GetType().GetProperty("CodeData").GetValue(x).ToString().Trim(), y => y.GetType().GetProperty("CodeDescription").GetValue(y).ToString().Trim());
            return new Result<Dictionary<string, string>>() { Data = dropDownValueDictionary };
        }
    }
}
