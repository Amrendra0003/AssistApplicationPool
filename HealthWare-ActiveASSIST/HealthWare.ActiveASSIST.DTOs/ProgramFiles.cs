namespace HealthWare.ActiveASSIST.DTOs
{
    public class ProgramFiles
    {
        public long ProgramId { get; set; }
        public long ProgramDocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string? DocumentId { get; set; }
        public bool IsProgramDocumentEsigned { get; set; }
        public bool EsignFlag { get; set; }
        public bool IsDeleted { get; set; } 
        public bool IsDownloaded { get; set; }
        public long DocumentDownloadId { get; set; }
    }
}
