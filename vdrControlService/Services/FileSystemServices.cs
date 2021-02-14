namespace vdrControlService.Services
{
    using System;
    using System.IO;
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

    }
}
