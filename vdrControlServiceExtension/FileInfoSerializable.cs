namespace vdrControlServiceExtension
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    [Serializable]
    public class FileInfoSerializable
    {
        private FileInfo _fileInfo;

        public FileInfoSerializable() 
        {

        }

        public string Attributes
        {
            get
            {
                string attributes = string.Empty;
                if ((_fileInfo.Attributes & FileAttributes.Archive) == FileAttributes.Archive)
                    attributes += "A";
                if ((_fileInfo.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed)
                    attributes += "C";
                if ((_fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    attributes += "D";
                if ((_fileInfo.Attributes & FileAttributes.Normal) == FileAttributes.Normal)
                    attributes += "N";
                if ((_fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    attributes += "R";
                if ((_fileInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                    attributes += "S";
                if ((_fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    attributes += "H";

                return attributes;
            }
            set 
            { 
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return _fileInfo.CreationTime;
            }
            set
            {
            }
        }

        public DateTime CreationTimeUtc
        {
            get
            {
                return _fileInfo.CreationTimeUtc;
            }
            set
            {
            }
        }

        public string DirectoryName
        {
            get
            {
                string directory = _fileInfo.DirectoryName;
                bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                if (isWindows)
                    directory = directory.Substring(2).Replace("\\", "/");

                return directory;
            }
            set
            {
            }
        }

        public string Extension
        {
            get
            {
                return _fileInfo.Extension;
            }
            set
            {
            }
        }

        public string FullName
        {
            get
            {
                return _fileInfo.FullName;
            }
            set
            {
                // Der Setter wird hier zum Zuweisen der FileInfo "missbraucht"
                _fileInfo = new FileInfo(value);
            }
        }

        public bool ValidFilePath
        {
            get
            {
                return _fileInfo.FullName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
            }
            set
            {
            }
        }

        public DateTime LastAccessTime
        {
            get
            {
                return _fileInfo.LastAccessTime;
            }
            set
            {
            }
        }

        public DateTime LastAccessTimeUtc
        {
            get
            {
                return _fileInfo.LastAccessTimeUtc;
            }
            set
            {
            }
        }

        public DateTime LastWriteTime
        {
            get
            {
                return _fileInfo.LastWriteTime;
            }
            set
            {
            }
        }

        public DateTime LastWriteTimeUtc
        {
            get
            {
                return _fileInfo.LastWriteTimeUtc;
            }
            set
            {
            }
        }

        public long Length
        {
            get
            {
                long length = -1;
                try
                {
                    length = _fileInfo.Length;
                }
                catch
                {

                }

                return length;
            }
            set
            {
            }
        }

        public string Name 
        { 
            get { return _fileInfo.Name; } set { }
        }
    }
}
