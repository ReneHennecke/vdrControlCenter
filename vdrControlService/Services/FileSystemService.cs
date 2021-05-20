namespace vdrControlService.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using vdrControlService.Interface;
    using vdrControlService.Models;
    
    public class FileSystemService : IFileSystemService
    {
        public FileSystemResponse GetDirectory(FileSystemEntryRequest request)
        {
            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            try
            {
                string fullPath = request.Source.FullPath;
                if (string.IsNullOrWhiteSpace(fullPath))
                    fullPath = Directory.GetCurrentDirectory();

                response.Source.ReInit(fullPath);
            }
            catch (Exception ex)
            {
                response.ErrorResult.ErrorCode = Enums.ErrorResultCode.GetDirectory;
                response.ErrorResult.ErrorException = ex;
            }

            return response;
        }

        public FileSystemResponse SetDirectory(FileSystemEntryRequest request)
        {
            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            try
            {
                string fullPath = request.Source.FullPath;
                if (Directory.Exists(fullPath))
                    Directory.SetCurrentDirectory(fullPath);
                
                response.Source.ReInit(fullPath);
            }
            catch (Exception ex)
            {
                response.ErrorResult.ErrorCode = Enums.ErrorResultCode.SetDirectory;
                response.ErrorResult.ErrorException = ex;
            }

            return response;
        }

        public async Task<FileSystemResponse> ReadFileContent(FileSystemEntryRequest request)
        {
            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };
            
            try
            {
                byte[] bytes = await File.ReadAllBytesAsync(request.Source.FullPath);
                response.Content = Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                response.ErrorResult.ErrorCode = Enums.ErrorResultCode.ReadFileContent;
                response.ErrorResult.ErrorException = ex;
            }

            return response;
        }

        public async Task<FileSystemResponse> WriteFileContent(FileSystemEntryRequest request)
        {
            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            try
            {
                byte[] bytes = Convert.FromBase64String(request.Content);
                await File.WriteAllBytesAsync(request.Source.FullPath, bytes);
            }
            catch (Exception ex)
            {
                response.ErrorResult.ErrorCode = Enums.ErrorResultCode.WriteFileContent;
                response.ErrorResult.ErrorException = ex;
            }

            return response;
        }

        public async Task<FileSystemResponse> DeleteFileSystemEntry(FileSystemEntryRequest request)
        {
            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            try
            {
                File.Delete(request.Source.FullPath);
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                response.ErrorResult.ErrorCode = Enums.ErrorResultCode.WriteFileContent;
                response.ErrorResult.ErrorException = ex;
            }

            return response;
        }
    }
}
