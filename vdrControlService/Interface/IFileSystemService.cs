namespace vdrControlService.Interface
{
    using System.Threading.Tasks;
    using vdrControlService.Models;

    public interface IFileSystemService
    {
        FileSystemResponse GetDirectory(FileSystemEntryRequest request);
        FileSystemResponse SetDirectory(FileSystemEntryRequest request);

        Task<FileSystemResponse> ReadFileContent(FileSystemEntryRequest request);
        Task<FileSystemResponse> WriteFileContent(FileSystemEntryRequest request);
        Task<FileSystemResponse> DeleteFileSystemEntry(FileSystemEntryRequest request);
    }
}
