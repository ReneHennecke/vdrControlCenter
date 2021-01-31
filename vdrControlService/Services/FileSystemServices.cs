namespace vdrControlService.Services
{
    using System;
    using System.IO;
    using vdrControlService.Interface;
    using vdrControlService.Models;
    
    public class FileSystemService : IFileSystemService
    {
        public DirEntryInfoResult GetCurrentDirectory()
        {
            DirEntryInfoResult result = new DirEntryInfoResult();

            try
            {
                result.DirEntryInfo = new DirEntryInfo(Directory.GetCurrentDirectory());
            }
            catch (Exception ex)
            {
                result.ErrorResult.ErrorCode = Enums.ErrorResultCode.CurrentDirectoryError;
                result.ErrorResult.ErrorException = ex;
            }

            return result;
        }

        public DirEntriesInfo GetDirEntriesInfo()
        {
            return GetDirEntriesInfo(Environment.CurrentDirectory);
        }

        public DirEntriesInfo GetDirEntriesInfo(string path)
        {
            return GetDirEntriesInfo(path, "*", SearchOption.TopDirectoryOnly);
        }

        public DirEntriesInfo GetDirEntriesInfo(string path, string searchPattern)
        {
            return GetDirEntriesInfo(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public DirEntriesInfo GetDirEntriesInfo(string path, string searchPattern, SearchOption searchOption)
        {
            DirEntriesInfo dirEntriesInfo = new DirEntriesInfo();
            dirEntriesInfo.FullPath = path;
            dirEntriesInfo.SearchPattern = searchPattern;
            dirEntriesInfo.SearchOption = searchOption;
            dirEntriesInfo.FilesOnly = false;
            dirEntriesInfo.GetEntries();
            return dirEntriesInfo;
        }

        public DirEntryInfoResult SetCurrentDirectory(string path)
        {
            DirEntryInfoResult result = new DirEntryInfoResult();

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.SetCurrentDirectory(path);

                    result.DirEntryInfo = new DirEntryInfo(Directory.GetCurrentDirectory());
                }
                catch (Exception ex)
                {
                    result.ErrorResult.ErrorCode = Enums.ErrorResultCode.CurrentDirectoryError;
                    result.ErrorResult.ErrorException = ex;
                }
            }

            return result;
        }
    }
}
