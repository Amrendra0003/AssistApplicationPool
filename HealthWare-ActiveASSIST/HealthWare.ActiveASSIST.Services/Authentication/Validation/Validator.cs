using System.Collections.Generic;
using Healthware.Core.DTO;

namespace HealthWare.ActiveASSIST.Services.Authentication.Validation
{

    public interface IBaseValidator<in T>
    {
        /// <summary>
        /// validate a single item within a collection
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items">Items cannot be null</param>
        ValidationResultDto Execute(T item, IEnumerable<T> items);

        /// <summary>
        /// Validate a single item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ValidationResultDto Execute(T item);
        
    }

    /// <summary>
    /// For validations that apply to creating or updating 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<in T> : IBaseValidator<T>
    {
    }
}