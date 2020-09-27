using System;
using System.IO;

namespace vdrControlServiceExtension
{
    public interface IVdrServiceController
    {
        /// <summary>
        /// Get file attributes
        /// </summary>
        /// <param name="fileName"></param>
        FileAttributes FileAttributes(string fileName);

        /// <summary>
        /// Check existence of or access to file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool FileExists(string fileName);

        /// <summary>
        /// Copy a file, override flag is true as default
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <returns></returns>
        bool FileCopy(string sourceFileName, string destFileName);

        /// <summary>
        /// Copy a file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="forceOverride"></param>
        /// <returns></returns>
        bool FileCopyForceOverride(string sourceFileName, string destFileName, bool forceOverride);

        /// <summary>
        /// Get file creation time
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DateTime FileCreationTime(string fileName);

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool FileDelete(string fileName);

        /// <summary>
        /// Move a file, override flag is true as default
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <returns></returns>
        bool FileMove(string sourceFileName, string destFileName);

        /// <summary>
        /// Move a file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="forceOverride"></param>
        /// <returns></returns>
        bool FileMoveForceOverride(string sourceFileName, string destFileName, bool forceOverride);

        /// <summary>
        /// Get file last write time
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DateTime FileLastWriteTime(string fileName);

        /// <summary>
        /// Get file size info
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        long FileSize(string fileName);

        /// <summary>
        /// Read the text contents of a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string FileRead(string fileName);

        /// <summary>
        /// Write the text contents to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        bool FileWrite(string fileName, string contents);

        #region Directory methods

        /// <summary>
        /// Check the existence of or the access to an directory
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        bool DirectoryExists(string directoryName);


        /// <summary>
        /// Create a directory
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        bool DirectoryCreate(string directoryName);

        /// <summary>
        /// Liest den Inhalt eines Verzeichnisses 
        /// Im String sind die serialisierte FileInfoSerializable Daten
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="pattern"></param>
        /// <param name="recursiv"></param>
        /// <returns></returns>
        string GetDirectoryEntries(string filePath, string pattern, bool recursiv);
        #endregion

        #region Several methods

        string Bash(string args);

        Version GetVersion();

        bool IsAlive();

        #endregion

        #region Path
        string GetFullPath(string path);

        string GetTempPath();

        string GetTempFileName();

        char[] GetInvalidPathChars();

        char[] GetInvalidFileNamechars();

        char GetPathSeparator();

        char GetVolumeSeparatorChar();

        char GetDirectorySeparatorChar();

        char GetAltDirectorySeparatorChar();
        #endregion
    }
}
