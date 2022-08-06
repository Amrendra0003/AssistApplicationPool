using System;
using System.IO;
using HealthWare.ActiveASSIST.DTOs;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IFileUploadServiceHelper
    {

        public bool SaveFile(IFormFile file, string filePath, bool eSign = false, bool formFlatten = false);
        public bool CreateDirectory(string folderPath);
        public byte[] ReadBytes(string filePath);
        public string ImageBase64Data(byte[] byteData);
        public string ImageDataUrl(string imageBase64Data);
        public bool DeleteFile(string filePath);
        public bool DeleteFiles(string filePath);
        public bool DeleteDirectory(string path);
        public void CheckCategory(FileDetails fileDetails, FileLocationDetail fileLocation);
        public byte[] ReadFileBytes(string filePath);
        bool IsFileExists(string filePath);
        bool SaveFileStream(string filePath, string fileName);
    }
    public class DocumentServiceHelper : IFileUploadServiceHelper
    {

        private readonly DocumentConfiguration _fileUploadConfig;
        private readonly string ImageUrlDataPrefix = @"data:image/png;base64,";
        public DocumentServiceHelper(DocumentConfiguration fileUploadConfig)
        {
            _fileUploadConfig = fileUploadConfig;
        }

        public string UserAssessmentFileDetails(FileDetails fileDetails)
        {
            return string.Concat(_fileUploadConfig.UploadFolderPath, fileDetails.UserId, "\\", fileDetails.AssessmentId, "\\", nameof(_fileUploadConfig.User_Files));
        }

        public void CheckCategory(FileDetails fileDetails, FileLocationDetail fileLocation)
        {
            if (fileDetails.DocumentTitle.ToLower().Equals(nameof(_fileUploadConfig.verificationdocument)) && !fileDetails.DocumentCategory.ToLower().Equals(nameof(_fileUploadConfig.income)))
            {
                if (Directory.Exists(fileLocation.FolderBasePath))
                    DeleteDirectory(fileLocation.FolderBasePath);
            }
            if (fileDetails.DocumentTitle.ToLower().Equals(nameof(_fileUploadConfig.programdocument)) && Directory.Exists(fileLocation.FolderPath))
            {
                if(!Directory.Exists(fileLocation.FolderPath + "\\Deleted"))
                {
                    DeleteDirectory(fileLocation.FolderPath);
                }
            }
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFiles(string filePath)
        {
            try
            {
                if (Directory.Exists(filePath))
                {
                    DirectoryInfo directory = new DirectoryInfo(filePath);
                    foreach (FileInfo file in directory.GetFiles())
                        file.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }

            return true;
        }

        public bool SaveFile(IFormFile file, string filePath, bool eSign = false, bool formFlatten = false)
        {
            FileStream stream = null;
            PdfStamper pdfEditorInstance = null;
            PdfReader reader = null;
            try
            {
                stream = new FileStream(filePath, FileMode.OpenOrCreate);
                if (eSign)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        reader = new PdfReader(fileBytes);
                        pdfEditorInstance = new PdfStamper(reader, stream);
                        pdfEditorInstance.FormFlattening = formFlatten;
                    }
                }
                else
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (pdfEditorInstance != null)
                {
                    pdfEditorInstance?.Reader?.Close();
                    pdfEditorInstance?.Close();
                }
                reader?.Close();
                stream?.Close();
            }
            return true;
            
        }

        public bool CreateDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return true;
        }

        public byte[] ReadBytes(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch
            {
                var defaultImagePath = _fileUploadConfig.DefaultProfileImagePath;
                return File.ReadAllBytes(defaultImagePath);
            }
        }

        public string ImageBase64Data(byte[] byteData)
        {
            return Convert.ToBase64String(byteData);
        }

        public string ImageDataUrl(string imageBase64Data)
        {
            return string.Concat(ImageUrlDataPrefix + imageBase64Data);
        }
        public byte[] ReadFileBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public bool IsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public bool SaveFileStream(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool SavePdfFileStream(string url, string filePath, string fileName)
        {//const string filePath1 = "test.pdf";
            //var reader = new PdfReader(@"http://localhost:21021/api/FileUpload/PreviewProgramDocument?PgrmdocId=1");
            //var pdfStamper = new PdfStamper(reader, new FileStream(filePath1, FileMode.Create));
            //
            //test.SetField("PATLastFirst", "test");
            //pdfStamper.Close();
            //var programDocumentFromUrl = new PdfReader(url);
            //var pdfStamper = new PdfStamper(programDocumentFromUrl, new FileStream(filePath, FileMode.Create));
            //var pdfDocumentFields = pdfStamper.AcroFields;
            //pdfStamper.Close();
            return true;

        }
    }
}
   

