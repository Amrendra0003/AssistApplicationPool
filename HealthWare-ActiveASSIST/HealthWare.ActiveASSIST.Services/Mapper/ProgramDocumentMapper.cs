using HealthWare.ActiveASSIST.Entities;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IProgramDocumentMapper
    {
        ProgramDocument MapFrom(long programId, string documentName, string formLocation, bool eSignFlag);
    }
    public class ProgramDocumentMapper: IProgramDocumentMapper
    {
        public ProgramDocument MapFrom(long programId, string documentName, string formLocation, bool eSignFlag)
        {
            var programDocument = new ProgramDocument
            {
                Program = new Program { Id = programId },
                DocumentName = documentName,
                DocumentDescription = null,
                FormLocation = formLocation,
                ESignFlag = eSignFlag
            };
            return programDocument;
        }
    }
}
