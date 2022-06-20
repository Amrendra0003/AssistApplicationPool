namespace HealthWare.ActiveASSIST.DTOs
{
    public class FileDetails
    {

        public long DocumentId { get; set; }
        public long AssessmentId { get; set; }
        public long UserId { get; set; }
        public long? HouseHoldMemberId { get; set; }
        public long? ProgramId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentCategory { get; set; }
        public string DocumentType { get; set; }
        public bool IsProgramDocument { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentSize { get; set; }
        public long? ProgramDocumentId { get; set; }
        public bool Esigned { get; set; }

    }
}
