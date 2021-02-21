namespace vdrControlService.Interface
{
    using System.IO;
    using System.Threading.Tasks;
    using vdrControlService.Models;

    public interface IFileSystemService
    {
        FileSystemEntry GetDirectory(FileSystemEntryRequest request);
        FileSystemEntry SetDirectory(FileSystemEntryRequest request);

        Task<FileContent> ReadFileContent(FileSystemEntryRequest request);
        Task<bool> WriteFileContent(FileSystemEntryRequest request);
    }
}
