namespace vdrControlService.Interface
{
    using System.IO;
    using vdrControlService.Models;

    public interface IFileSystemService
    {
        DirEntriesInfo GetDirEntriesInfo();
        DirEntriesInfo GetDirEntriesInfo(string path);
        DirEntriesInfo GetDirEntriesInfo(string path, string searchPattern);
        DirEntriesInfo GetDirEntriesInfo(string path, string searchPattern, SearchOption searchOption);
    }
}
