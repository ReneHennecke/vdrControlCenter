using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vdrControlService.Models
{
    public class FileSystemEntry
    {
        private FileAttributes _attributes = FileAttributes.Normal;

        private bool _isDirectory;
        
        private DateTime _creationTime;
        private DateTime _creationTimeUtc;
        private DateTime _lastAccessTime;
        private DateTime _lastAccessTimeUtc;
        private DateTime _lastWriteTime;
        private DateTime _lastWriteTimeUtc;

        private bool _exists;

        private string _fullPath;

        // Settings über public Methoden sonst Problem mit Deserializer

        public FileSystemEntry()
        {
        }

        public FileSystemEntry(string fullPath)
        {
            PrepareFullPathForOS(fullPath);
            LoadAttributes();
        }

        private void PrepareFullPathForOS(string fullPath)        
        {
            const string DOS_DRIVE_SEPARATOR = ":";

            if (OperatingSystem.IsLinux())
            {
                fullPath = fullPath.Replace("\\", "/");
                if (fullPath.Contains(DOS_DRIVE_SEPARATOR))
                    fullPath = fullPath.Substring(fullPath.IndexOf(DOS_DRIVE_SEPARATOR)) + "ää";
            }

            _fullPath = fullPath;
        }

        private void LoadAttributes()
        {
            _attributes = File.GetAttributes(_fullPath);

            _isDirectory = _attributes.HasFlag(FileAttributes.Directory);

            _creationTime = _isDirectory ? Directory.GetCreationTime(_fullPath) : File.GetCreationTime(_fullPath);
            _creationTimeUtc = _isDirectory ? Directory.GetCreationTimeUtc(_fullPath) : File.GetCreationTimeUtc(_fullPath);
            _lastAccessTime = _isDirectory ? Directory.GetLastWriteTime(_fullPath) : File.GetLastAccessTime(_fullPath);
            _lastAccessTimeUtc = _isDirectory ? Directory.GetLastAccessTimeUtc(_fullPath) : File.GetLastAccessTimeUtc(_fullPath);
            _lastWriteTime = _isDirectory ? Directory.GetLastWriteTime(_fullPath) : File.GetLastWriteTime(_fullPath);
            _lastWriteTimeUtc = _isDirectory ? Directory.GetLastWriteTimeUtc(_fullPath) : File.GetLastWriteTimeUtc(_fullPath);

            _exists = _isDirectory ? Directory.Exists(_fullPath) : File.Exists(_fullPath);
        }

        public string FullPath
        {
            get => _fullPath;
            set => _fullPath = value;
        }

        public FileAttributes Attributes 
        { 
            get => _attributes;
            set => _attributes = value;
        }

        public DateTime CreationTime
        {
            get => _creationTime;
            set => _creationTime = value;
        }

        public DateTime CreationTimeUtc
        {
            get => _creationTimeUtc;
            set => _creationTimeUtc = value;
        }

        public DateTime LastAccessTime
        {
            get => _lastAccessTime;
            set => _lastAccessTime = value;
        }

        public DateTime LastAccessTimeUtc
        {
            get => _lastAccessTimeUtc;
            set => _lastAccessTimeUtc = value;
        }

        public DateTime LastWriteTime
        {
            get => _lastWriteTime;
            set => _lastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => _lastWriteTimeUtc;
            set => _lastWriteTimeUtc = value;
        }

        public bool Exists
        {
            get => _exists;
            set => _exists = value;
        }
    }
}
