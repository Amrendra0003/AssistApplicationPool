using System.Collections.Generic;

namespace Healthware.Core.DTO
{
    public class ValidationResultsDto<T>
    {
        
        /// <summary>
        /// Did the validation succeed for the payload
        /// </summary>
        public bool IsValid { get; set; }
        
        /// <summary>
        /// If validation fails, this will include the validation errors
        /// </summary>
        public IEnumerable<ValidationErrorDto<T>> ValidationErrors { get; set; }
        
        /// <summary>
        /// If validation passes, this validation identifier can be passed with the same payload to the import endpoint
        /// </summary>
        public string ValidationIdentifier { get; set; }
    }
}