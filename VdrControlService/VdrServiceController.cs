
namespace VdrControlService
{
    using Microsoft.Extensions.Logging;
    //using Microsoft.Extensions.Options;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    using vdrControlServiceExtension;

    public class VdrServiceController : IVdrServiceController
    {
        private readonly ILogger<VdrServiceController> _logger;
        //private readonly IOptions<VdrControlServiceConfig> _config;

        //public VdrControlService(ILoggerFactory loggerFactory, IOptions<VdrControlServiceConfig> config)
        //{
        //    _logger = loggerFactory.CreateLogger<VdrControlService>();
        //    _config = config;
        //}


        public VdrServiceController(ILogger<VdrServiceController> logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            _logger.LogInformation("Disposing...");
        }

        private FileInfo GetFileInfo(string fileName)
        {
            return new FileInfo(fileName);
        }


        #region File methods
        /// <summary>
        /// Get file attributes
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileAttributes FileAttributes(string fileName)
        {
            FileAttributes fileAttributes = 0;

            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileAttributes({fileName})");
                    fileAttributes = File.GetAttributes(fileName);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return fileAttributes;
        }

        /// <summary>
        /// Check existence of or access to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool FileExists(string fileName)
        {
            _logger.LogInformation($"FileExists({fileName})");
            bool b = File.Exists(fileName);
            if (!b)
                _logger.LogWarning($"File {fileName} not exist or accessable.");

            return b;
        }

        /// <summary>
        /// Copy a file, override flag is true as default
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <returns></returns>
        public bool FileCopy(string sourceFileName, string destFileName)
        {
            return FileCopyForceOverride(sourceFileName, destFileName, true);
        }

        /// <summary>
        /// Copy a file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="forceOverride"></param>
        /// <returns></returns>
        public bool FileCopyForceOverride(string sourceFileName, string destFileName, bool forceOverride)
        {
            bool b = false;

            if (FileExists(sourceFileName))
            {
                try
                {
                    _logger.LogInformation($"FileCopyForceOverride({sourceFileName}, {destFileName}, {forceOverride})");
                    File.Copy(sourceFileName, destFileName, forceOverride);
                    b = true;
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return b;
        }

        /// <summary>
        /// Get file creation time 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DateTime FileCreationTime(string fileName)
        {
            DateTime dt = DateTime.MinValue;

            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileCreationTime({fileName})");
                    dt = File.GetCreationTime(fileName);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return dt;
        }

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool FileDelete(string fileName)
        {
            bool b = false;

            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileDelect({fileName})");
                    File.Delete(fileName);
                    b = true;
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return b;
        }

        /// <summary>
        /// Get file last write time
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DateTime FileLastWriteTime(string fileName)
        {
            DateTime dt = DateTime.MinValue;

            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileLastWriteTime({fileName})");
                    dt = File.GetLastAccessTime(fileName);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return dt;
        }


        /// <summary>
        /// Move a file, override is true as default
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <returns></returns>
        public bool FileMove(string sourceFileName, string destFileName)
        {
            return FileMoveForceOverride(sourceFileName, destFileName, true);
        }

        /// <summary>
        /// Move a file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="forceOverride"></param>
        /// <returns></returns>
        public bool FileMoveForceOverride(string sourceFileName, string destFileName, bool forceOverride)
        {
            bool b = false;

            if (FileExists(sourceFileName))
            {
                try
                {
                    _logger.LogInformation($"FileMoveForceOverride({sourceFileName}, {destFileName}, {forceOverride})");
                    File.Move(sourceFileName, destFileName, forceOverride);
                    b = true;
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return b;
        }


        /// <summary>
        /// Get file size
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public long FileSize(string fileName )
        {
            FileInfo fi = null;

            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileSize({fileName})");
                    fi = new FileInfo(fileName);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return fi == null ? -1 : fi.Length;
        }

        /// <summary>
        /// Read the text contents of a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string FileRead(string fileName)
        {
            string contents = string.Empty;
            if (FileExists(fileName))
            {
                try
                {
                    _logger.LogInformation($"FileRead({fileName})");
                    contents = File.ReadAllText(fileName, System.Text.Encoding.UTF8);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return contents;

        }


        /// <summary>
        /// Write the text contents to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public bool FileWrite(string fileName, string contents)
        {
            bool b = false;
            
            if (FileExists(fileName))
                FileDelete(fileName);

            try
            {
                _logger.LogInformation($"FileWrite({fileName}, {contents})");
                File.WriteAllText(fileName, contents, System.Text.Encoding.UTF8);
                b = true;
            }
            catch (IOException ex)
            {
                _logger.LogError(ex.Message);
            }

            return b;
        }

        #endregion

        #region Directory methods
        public bool DirectoryExists(string directoryName)
        {
            _logger.LogInformation($"DirectoryExists({directoryName})");
            bool b = Directory.Exists(directoryName);
            if (!b)
                _logger.LogWarning($"Directory {directoryName} not exist or accessable.");

            return b;
        }

        public bool DirectoryCreate(string directoryName)
        {
            _logger.LogInformation($"DirectoryCreate({directoryName})");
            bool b = Directory.Exists(directoryName);
            if (!b)
            {
                try
                {
                    Directory.CreateDirectory(directoryName);
                    b = true;
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return b;
        }

        public string GetDirectoryEntries(string filePath, string pattern, bool recursiv)
        {
            string retval = string.Empty;
            try
            {
                _logger.LogInformation($"GetDirectoryEntries({filePath}, {pattern}, {recursiv})");

                DirectoryInfo di = new DirectoryInfo(filePath);
                FileInfo[] fileInfos = di.GetFiles(pattern, recursiv ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                FileInfoListSerializable fileInfoList = new FileInfoListSerializable();
                foreach (FileInfo fi in fileInfos)
                {
                    FileInfoSerializable fis = new FileInfoSerializable();
                    fis.FullName = fi.FullName;
                    fileInfoList.FileList.Add(fis);
                }

                retval = XmlSerializerRaX.Serialize(fileInfoList);
            }
            catch (IOException ex)
            {
                _logger.LogError(ex.Message);
            }

            return retval;
        }

        #endregion

        #region Several methods
            public string Bash(string args)
        {
            _logger.LogInformation($"Bash({args})");

            string output = string.Empty;
            string escapedArgs = args.Replace("\"", "\\\"");
            escapedArgs = args.Replace("\"", "/");

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = $"-c \"{escapedArgs}\""
            };

            using (Process p = Process.Start(psi))
            {
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }

            return output;
        }

        public Version GetVersion()
        {
            _logger.LogInformation($"GetVersion()");
            return Assembly.GetEntryAssembly().GetName().Version;
        }

        public bool IsAlive()
        {
            _logger.LogInformation($"IsAlive()");
            return true;
        }
        #endregion

        #region Path
        public string GetFullPath(string path) 
        { 
            return Path.GetFullPath(path); 
        }

        public string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public string GetTempFileName()
        {
            return Path.GetTempFileName();
        }

        public char[] GetInvalidPathChars()
        {
            return Path.GetInvalidPathChars();
        }
            
        public char[] GetInvalidFileNamechars()
        {
            return Path.GetInvalidFileNameChars();
        }

        public char GetPathSeparator()
        {
            return Path.PathSeparator;
        }

        public char GetVolumeSeparatorChar()
        {
            return Path.VolumeSeparatorChar;
        }

        public char GetDirectorySeparatorChar()
        {
            return Path.DirectorySeparatorChar;
        }

        public char GetAltDirectorySeparatorChar()
        {
            return Path.AltDirectorySeparatorChar;
        }
        #endregion
    }
}
