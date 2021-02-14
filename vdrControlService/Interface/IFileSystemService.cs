namespace vdrControlService.Interface
{
    using System.IO;
    using vdrControlService.Models;

    public interface IFileSystemService
    {
        FileSystemEntry GetDirectory(FileSystemEntryRequest request);
        FileSystemEntry SetDirectory(FileSystemEntryRequest request);
    }
}
