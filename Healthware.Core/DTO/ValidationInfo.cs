using System;

namespace Healthware.Core.DTO
{
    /// <summary>
    /// Validation Info for successful validation so that import doesn't need to re-validate a page.
    /// </summary>
    [Serializable]
    public class ValidationInfo
    {
        public string Md5Sum { get; set; }
        public DateTime ValidationDate { get; set; }
    }
}