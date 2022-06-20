using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.FileListener.Config;
using HealthWare.ActiveASSIST.FileListener.Constants;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HealthWare.ActiveASSIST.FileListener.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private FileSystemWatcher _folderWatcher;
        private readonly string _inputFolder;
        private readonly string _patientOnBoardURL;

        public Worker(ILogger<Worker> logger, IOptions<AppSettings> settings, IServiceProvider services)
        {
            _logger = logger;
            _inputFolder = settings.Value.InputFolder;
            _patientOnBoardURL = settings.Value.PatientOnBoardURL;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service Starting");
            if (!Directory.Exists(_inputFolder))
            {
                _logger.LogWarning($"Please make sure the InputFolder [{_inputFolder}] exists, then restart the service.");
                return Task.CompletedTask;
            }

            _logger.LogInformation($"Binding Events from Input Folder: {_inputFolder}");
            _folderWatcher = new FileSystemWatcher(_inputFolder)
            {
                NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                  NotifyFilters.DirectoryName
            };
            _folderWatcher.IncludeSubdirectories = false;
            _folderWatcher.Changed += Input_OnChanged;
            _folderWatcher.EnableRaisingEvents = true;

            return base.StartAsync(cancellationToken);
        }

        protected void Input_OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                _logger.LogInformation(ApplicationConstant.InBoundChangeEventStart + e.FullPath);
                var filePath = e.FullPath;
                var filePathArgs = filePath.Split('\\');
                var tenantId = filePathArgs[4];
                var fileExtension = Path.GetExtension(e.FullPath);
                try
                {
                    if (fileExtension.Equals(ApplicationConstant.CSVFileExtension) && File.Exists(e.FullPath))
                    {
                        //Call User on board API.
                        HttpClient client = new HttpClient();
                        Thread.Sleep(1000);
                        var gg = File.ReadAllBytes(e.FullPath);
                        var byteArrayContent = new ByteArrayContent(gg);
                        var multipartContent = new MultipartFormDataContent();
                        multipartContent.Add(byteArrayContent, ApplicationConstant.FileHeader, e.Name);

                        string[] strArray = filePath.Split('\\');
                        client.DefaultRequestHeaders.Add(ApplicationConstant.TenantHeader, strArray[4]);

                        var postResponse = client.PostAsync(_patientOnBoardURL, multipartContent).GetAwaiter().GetResult();
                        if (postResponse.IsSuccessStatusCode)
                        {
                            var processedFilesPath = $@"C:\inetpub\wwwroot\ActiveASSISTUserImport\{tenantId}\ProcessedFiles\";
                            processedFilesPath = processedFilesPath + Path.GetFileName(e.FullPath) + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

                            bool isFileExistsInProcessedPath = File.Exists(processedFilesPath);
                            bool isFileExistsInParentPath = File.Exists(e.FullPath);
                            if (!isFileExistsInProcessedPath && isFileExistsInParentPath)
                            {
                                Thread.Sleep(1000);
                                     Directory.Move(e.FullPath, processedFilesPath);
                                Thread.Sleep(1000);
                            }
                        }
                    }
                    else
                    {
                        var failedFilesPath = $@"C:\inetpub\wwwroot\ActiveASSISTUserImport\{tenantId}\FailedFiles\";
                        failedFilesPath = failedFilesPath + Path.GetFileName(e.FullPath) + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                        bool isFileExistsInFailedPath = File.Exists(failedFilesPath);
                        bool isFileExistsInParentPath = File.Exists(e.FullPath);
                        if (!isFileExistsInFailedPath && isFileExistsInParentPath)
                        {
                            Thread.Sleep(1000);
                            while (true)
                            {
                                try
                                {
                                    Directory.Move(e.FullPath, failedFilesPath);
                                    break;
                                }
                                catch
                                {
                                    Thread.Sleep(60000);
                                }
                            }
                            
                            
                        }
                    }

                    _logger.LogInformation(ApplicationConstant.InBoundChangeEventDone);
                }
                catch (Exception exception)
                {
                    _logger.LogInformation($"Exception handled is : [{exception.StackTrace.ToString()}]");
                    throw;
                }
                
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Service");
            _folderWatcher.EnableRaisingEvents = false;
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _logger.LogInformation("Disposing Service");
            _folderWatcher.Dispose();
            base.Dispose();
        }
    }
}
