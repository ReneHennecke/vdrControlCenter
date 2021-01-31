namespace vdrControlService.Models
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    [DataContract]
    public class DirEntryInfo
    {
        private const string DIRECTORY_PREFIX = "*";

        private string _fullPath;
        private DirectoryInfo _directoryInfo;
        private FileInfo _fileInfo;
        private bool _isDirectory;

        private FileAttributes _attributes;
        private bool _exists;
        private DateTime _creationTime;
        private DateTime _creationTimeUtc;
        private DateTime _lastAccessTime;
        private DateTime _lastAccessTimeUtc;
        private DateTime _lastWriteTime;
        private DateTime _lastWriteTimeUtc;
        private Int64 _length;

        public DirEntryInfo()
        {
           
        }

        public DirEntryInfo(string fullPath)
        {
            if (OperatingSystem.IsLinux())
            {
                fullPath = fullPath.Replace("\\", "/");
                if (fullPath.Contains(":"))
                    fullPath = fullPath.Substring(fullPath.IndexOf(":"));
            }

            _fullPath = fullPath;
            _isDirectory = File.GetAttributes(_fullPath).HasFlag(FileAttributes.Directory);

            PostInit();
        }

        private void PostInit()
        {
            if (_isDirectory)
                _directoryInfo = new DirectoryInfo(_fullPath);
            else
                _fileInfo = new FileInfo(_fullPath);

           
        }

        [DataMember]
        public FileAttributes Attributes
        {
            get
            {
                _attributes = _isDirectory ? _directoryInfo.Attributes : _fileInfo.Attributes;
                return _attributes;
            }
            set => _attributes = value;
        }

        [DataMember]
        public DateTime CreationTime
        {
            get
            {
                _creationTime = _isDirectory ? _directoryInfo.CreationTime : _fileInfo.CreationTime;
                return _creationTime;
            }
            set => _creationTime = value;
        }

        [DataMember]
        public DateTime CreationTimeUtc
        {
            get
            {
                _creationTimeUtc = _isDirectory ? _directoryInfo.CreationTimeUtc : _fileInfo.CreationTimeUtc;
                return _creationTimeUtc;
            }
            set => _creationTimeUtc = value;
        }

        [DataMember]
        public bool Exists
        {
            get
            {
                _exists = _isDirectory ? _directoryInfo.Exists : _fileInfo.Exists;
                return _exists;
            }
            set => _exists = value;
        }

        [DataMember]
        public string FullName
        {
            get => _isDirectory ? $"{DIRECTORY_PREFIX}{_directoryInfo.FullName}" : _fileInfo.FullName;
            set
            {
                string fullPath = value;
                if (fullPath.StartsWith(DIRECTORY_PREFIX))
                {
                    fullPath = fullPath.Substring(1);
                    _isDirectory = true;
                }

                _fullPath = fullPath;
                PostInit();
            }
        }

        [DataMember]
        public bool IsDirectory
        {
            get => _isDirectory;
            set => _isDirectory = value;
        }

        [DataMember]
        public DateTime LastAccessTime
        {
            get
            {
                _lastAccessTime = _isDirectory ? _directoryInfo.LastAccessTime : _fileInfo.LastAccessTime;
                return _lastAccessTime;
            }
            set => _lastAccessTime = value;
        }

        [DataMember]
        public DateTime LastAccessTimeUtc
        {
            get
            {
                _lastAccessTimeUtc = _isDirectory ? _directoryInfo.LastAccessTimeUtc : _fileInfo.LastAccessTimeUtc;
                return _lastAccessTimeUtc;
            }
            set => _lastAccessTimeUtc = value;
        }

        [DataMember]
        public DateTime LastWriteTime
        {
            get
            {
                _lastWriteTime = _isDirectory ? _directoryInfo.LastWriteTime : _fileInfo.LastWriteTime;
                return _lastWriteTime;
            }
            set => _lastWriteTime = value;
        }

        [DataMember]
        public DateTime LastWriteTimeUtc
        {
            get
            {
                _lastWriteTimeUtc = _isDirectory ? _directoryInfo.LastWriteTimeUtc : _fileInfo.LastWriteTimeUtc;
                return _lastWriteTimeUtc;
            }
            set => _lastWriteTimeUtc = value;
        }

        [DataMember]
        public Int64 Length
        {
            get
            {
                _length = _isDirectory ? -1 : _fileInfo.Length;
                return _length;
            }
            set => _length = value;
        }
    }
}
