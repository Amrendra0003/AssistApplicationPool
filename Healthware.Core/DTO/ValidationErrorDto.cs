using System.Collections.Generic;

namespace Healthware.Core.DTO
{
    public class ValidationErrorDto<T>
    {
        /// <summary>
        /// Item that the validation failed for
        /// </summary>
        public T item { get; set; }
        
        /// <summary>
        /// Error messages that describe why the validation failed
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}