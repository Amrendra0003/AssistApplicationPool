using Healthware.Core.DTO;
using System.Collections.Generic;
using Healthware.Core.Containers;

namespace HealthWare.ActiveASSIST.Services.Authentication.Validation
{
    /// <summary>
    /// Run general update or create validations (IValidator)
    /// </summary>
    /// <typeparam name="T">Type of update dto for which to run the validators</typeparam>
    public interface IRunValidationsCommand<T>
    {
        IEnumerable<ValidationErrorDto<T>>  Validate(IEnumerable<T> items);
        ValidationErrorDto<T> Validate(T item);
    }

    public class RunValidationsCommand<T> : RunValidationsBase<T>, IRunValidationsCommand<T>
    {
        public RunValidationsCommand()
        {
            Validators = Resolve.AllImplementationsOf<IValidator<T>>();
        }
    }
}