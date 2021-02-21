namespace vdrControlService.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using vdrControlService.Interface;
    using vdrControlService.Models;
    
    public class FileSystemService : IFileSystemService
    {
        public FileSystemEntry GetDirectory(FileSystemEntryRequest request)
        {
            FileSystemEntry result = new FileSystemEntry();

            try
            {
                string fullPath = request.FullPath;
                if (string.IsNullOrWhiteSpace(fullPath))
                    fullPath = Directory.GetCurrentDirectory();

                result.ReInit(fullPath);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public FileSystemEntry SetDirectory(FileSystemEntryRequest request)
        {
            FileSystemEntry result = new FileSystemEntry();

            try
            {

                string fullPath = request.FullPath;
                if (Directory.Exists(fullPath))
                    Directory.SetCurrentDirectory(fullPath);
                
                result.ReInit(fullPath);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<FileContent> ReadFileContent(FileSystemEntryRequest request)
        {
            FileContent result = new FileContent()
            {
                 FullPath = request.FullPath
            };

            try
            {
                byte[] bytes = await File.ReadAllBytesAsync(request.FullPath);
                result.Content = Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<bool> WriteFileContent(FileSystemEntryRequest request)
        {
            bool result = false;

            try
            {
                byte[] bytes = Convert.FromBase64String(request.Content);
                await File.WriteAllBytesAsync(request.FullPath, bytes);
                result = true;
            }
            catch //(Exception ex)
            {

            }

            return result;
        }
    }
}
