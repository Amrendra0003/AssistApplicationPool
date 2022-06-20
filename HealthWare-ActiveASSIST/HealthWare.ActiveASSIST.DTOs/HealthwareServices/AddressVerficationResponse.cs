namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class AddressVerificationResponse
    {
        public CASSResult CassResult { get; set; }
    }

    public class CASSResult
    {
        public int ObjectId { get; set; }
        public int RequestNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }
        public string DeliveryError { get; set; }
        public string VerificationError { get; set; }
        public string VerificationDPVFootNotes { get; set; }
        public string VerificationStatusCode { get; set; }
        public Status Status { get; set; }
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public string Message { get; set; }

    }

    public class Status
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
    }


}

