using System.IO;
using HealthWare.ActiveASSIST.DTOs;
using Healthware.Core.Utility;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IDocumentLocationMapper
    {
        public FileLocationDetail GetFileLocation(FileDetails fileDetails);
    }
    public class DocumentLocationMapper : IDocumentLocationMapper
    {
        private readonly DocumentConfiguration _fileUploadConfig;
        private readonly string ProfileImageFileExtension = ".png";
        public DocumentLocationMapper(DocumentConfiguration Config)
        {
            _fileUploadConfig = Config;
        }

        public FileLocationDetail GetFileLocation(FileDetails fileDetails)
        {

            switch (fileDetails.DocumentTitle.ToLower())
            {
                case nameof(_fileUploadConfig.userprofileimage):
                    return new FileLocationDetail
                    {
                        FolderPath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId),
                        FilePath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", nameof(_fileUploadConfig.profileimage), ProfileImageFileExtension)
                    };

                case nameof(_fileUploadConfig.assessmentprofileimage):
                    return new FileLocationDetail
                    {
                        FolderPath = string.Concat(_fileUploadConfig.UploadFolderPath, (nameof(_fileUploadConfig.Profile_Images)), "\\", (nameof(_fileUploadConfig.assessmentprofileimage)), "\\", fileDetails.AssessmentId),
                        FilePath = string.Concat(_fileUploadConfig.UploadFolderPath, (nameof(_fileUploadConfig.Profile_Images)), "\\", (nameof(_fileUploadConfig.assessmentprofileimage)), "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.profileimage), ProfileImageFileExtension)
                    };

                case nameof(_fileUploadConfig.verificationdocument):
                    {
                        if (fileDetails.DocumentCategory.ToLower().Equals(nameof(_fileUploadConfig.income)))
                            return new FileLocationDetail
                            {
                                FolderPath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files), "\\", fileDetails.DocumentCategory, "\\", fileDetails.HouseHoldMemberId, "\\", fileDetails.DocumentType),
                                FilePath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files), "\\", fileDetails.DocumentCategory, "\\", fileDetails.HouseHoldMemberId, "\\", fileDetails.DocumentType, "\\", Path.GetFileNameWithoutExtension(fileDetails.DocumentName), Clock.Now().ToString("yyyyMMddHHmmss"), Path.GetExtension(fileDetails.DocumentName))
                            };
                        else
                            return new FileLocationDetail
                            {
                                FolderPath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files), "\\", fileDetails.DocumentTitle, "\\", fileDetails.DocumentCategory, "\\", fileDetails.DocumentType),
                                FilePath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files), "\\", fileDetails.DocumentTitle, "\\", fileDetails.DocumentCategory, "\\", fileDetails.DocumentType, "\\", Path.GetFileNameWithoutExtension(fileDetails.DocumentName), Clock.Now().ToString("yyyyMMddHHmmss"), Path.GetExtension(fileDetails.DocumentName)),
                                FolderBasePath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files), "\\", fileDetails.DocumentTitle, "\\", fileDetails.DocumentCategory)
                            };
                    }
                case nameof(_fileUploadConfig.programdocument):
                    return new FileLocationDetail
                    {
                        FolderPath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.Program_Files), "\\", fileDetails.ProgramId, "\\", fileDetails.ProgramDocumentId),
                        FilePath = string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.Program_Files), "\\", fileDetails.ProgramId, "\\", fileDetails.ProgramDocumentId, "\\", Path.GetFileNameWithoutExtension(fileDetails.DocumentName), Clock.Now().ToString("yyyyMMddHHmmss"), Path.GetExtension(fileDetails.DocumentName))
                    };

                default:
                    return new FileLocationDetail();
            }
        }
    }
}
