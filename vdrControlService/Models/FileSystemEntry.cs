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
        private string _name;
        private string _extension;
        private string _rootPath;
        private string _parentPath;
        private long _size;
        private bool _replaceDosPathSeparator = true;

        private Exception _exception;

        private List<FileSystemEntry> _directories;
        private List<FileSystemEntry> _files;

        private string _searchPattern = "*";


        // Settings über public Methoden sonst Problem mit Deserializer

        public FileSystemEntry()
        {

        }

        public FileSystemEntry(string fullPath)
        {
            PrepareFullPathForOS(fullPath);
            LoadAttributes();
        }

        private FileSystemEntry(string fullPath, bool subDirectories)
        {
            PrepareFullPathForOS(fullPath);
            LoadAttributes(subDirectories);
        }

        private void PrepareFullPathForOS(string fullPath)        
        {

            //const string DOS_DRIVE_SEPARATOR = ":";

            //if (OperatingSystem.IsLinux())
            //{
            //   // fullPath = fullPath.Replace("\\", "/");
            //    //if (fullPath.Contains(DOS_DRIVE_SEPARATOR))
            //    //    fullPath = fullPath.Substring(fullPath.IndexOf(DOS_DRIVE_SEPARATOR)) + "ää";
            //}

            if (_replaceDosPathSeparator)
                fullPath = fullPath.Replace("\\", "/");

            _fullPath = fullPath;
        }

        private void LoadAttributes(bool includeSubDirectories = true)
        {
            try
            {
                _attributes = File.GetAttributes(_fullPath);

                _isDirectory = _attributes.HasFlag(FileAttributes.Directory);

                _creationTime = _isDirectory ? Directory.GetCreationTime(_fullPath) : File.GetCreationTime(_fullPath);
                _creationTimeUtc = _isDirectory ? Directory.GetCreationTimeUtc(_fullPath) : File.GetCreationTimeUtc(_fullPath);
                _lastAccessTime = _isDirectory ? Directory.GetLastWriteTime(_fullPath) : File.GetLastAccessTime(_fullPath);
                _lastAccessTimeUtc = _isDirectory ? Directory.GetLastAccessTimeUtc(_fullPath) : File.GetLastAccessTimeUtc(_fullPath);
                _lastWriteTime = _isDirectory ? Directory.GetLastWriteTime(_fullPath) : File.GetLastWriteTime(_fullPath);
                _lastWriteTimeUtc = _isDirectory ? Directory.GetLastWriteTimeUtc(_fullPath) : File.GetLastWriteTimeUtc(_fullPath);

                _name = Path.GetFileNameWithoutExtension(_fullPath);

                _exists = _isDirectory ? Directory.Exists(_fullPath) : File.Exists(_fullPath);

                _directories = null;
                _files = null;

                if (_isDirectory)
                {
                    if (includeSubDirectories)
                        LoadEntries();
                }
                else
                {
                    _extension = Path.GetExtension(_fullPath);
                    _size = new FileInfo(_fullPath).Length;
                }
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        private void LoadEntries()
        {
            string[] directories = Directory.GetDirectories(_fullPath);
            if (directories.Length > 0)
            {
                _directories = new List<FileSystemEntry>();
                foreach (var directory in directories)
                {
                    FileSystemEntry dirEntry = new FileSystemEntry(directory, false);
                    _directories.Add(dirEntry);
                }
            }

            _rootPath = Directory.GetDirectoryRoot(_fullPath);
            
            DirectoryInfo di = new DirectoryInfo(_fullPath);
            _parentPath = di.Parent == null ? string.Empty : di.Parent.FullName;

            string[] files = Directory.GetFiles(_fullPath, _searchPattern);
            if (files.Length > 0)
            {
                _files = new List<FileSystemEntry>();
                foreach (var file in files)
                {
                    FileSystemEntry fileEntry = new FileSystemEntry(file);
                    _files.Add(fileEntry);
                }
            }
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

        public Exception Exception
        {
            get => _exception;
            set => _exception = value;
        }

        public List<FileSystemEntry> Directories
        {
            get => _directories;
            set => _directories = value;
        }

        public List<FileSystemEntry> Files
        {
            get => _files;
            set => _files = value;
        }

        public string RootPath
        {
            get => _rootPath;
            set => _rootPath = value;
        }

        public string Extension
        {
            get => _extension;
            set => _extension = value;
        }

        public long Size
        {
            get => _size;
            set => _size = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string ParentPath
        {
            get => _parentPath;
            set => _parentPath = value;
        }

        public string AttributeString
        {
            get
            {
                string attr = string.Empty;

                if (_attributes.HasFlag(FileAttributes.Archive))
                    attr += "A";
                if (_attributes.HasFlag(FileAttributes.Compressed))
                    attr += "C";
                if (_attributes.HasFlag(FileAttributes.Directory))
                    attr += "D";
                if (_attributes.HasFlag(FileAttributes.Encrypted))
                    attr += "E";
                if (_attributes.HasFlag(FileAttributes.Hidden))
                    attr += "H";
                if (_attributes.HasFlag(FileAttributes.System))
                    attr += "S";
                if (_attributes.HasFlag(FileAttributes.ReadOnly))
                    attr += "R";
                if (_attributes.HasFlag(FileAttributes.Normal))
                    attr += "N";


                return attr;
            }
        }

        public bool SetFullPath(string fullPath)
        {
            bool retval = false;

            try
            {
                PrepareFullPathForOS(fullPath);

                LoadAttributes();

                retval = true;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }

            return retval;
        }

        public bool SetAttributes(FileAttributes? attributes,
                                  DateTime? creationTime,
                                  DateTime? creationTimeUtc,
                                  DateTime? lastAccessTime,
                                  DateTime? lastAccesTimeUtc,
                                  DateTime? lastWriteTime,
                                  DateTime? lastWriteTimeUtc)
        {
            bool retval = false;

            try
            {
                if (attributes.HasValue)
                    File.SetAttributes(_fullPath, attributes.Value);
                if (creationTime.HasValue)
                    File.SetCreationTime(_fullPath, creationTime.Value);
                if (creationTimeUtc.HasValue)
                    File.SetCreationTimeUtc(_fullPath, creationTimeUtc.Value);
                if (lastAccessTime.HasValue)
                    File.SetLastAccessTime(_fullPath, lastAccessTime.Value);
                if (lastAccesTimeUtc.HasValue)
                    File.SetLastAccessTimeUtc(_fullPath, lastAccesTimeUtc.Value);
                if (lastWriteTime.HasValue)
                    File.SetLastWriteTime(_fullPath, lastWriteTime.Value);
                if (lastWriteTimeUtc.HasValue)
                    File.SetLastWriteTimeUtc(_fullPath, lastWriteTimeUtc.Value);

                LoadAttributes();

                retval = true;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }

            return retval;
        }

        public void ReInit(string fullPath)
        {
            PrepareFullPathForOS(fullPath);
            LoadAttributes();
        }

        public bool ReplaceDosPathSeparator
        {
            get => _replaceDosPathSeparator;
            set => _replaceDosPathSeparator = value;
        }
    }
}
