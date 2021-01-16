namespace vdrControlService.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;

    [DataContract]
    public class DirEntriesInfo
    {
        private string _fullPath;
        private string _searchPattern;
        private SearchOption _searchOption;
        private bool _filesOnly;

        private List<DirEntryInfo> _directories;
        private List<DirEntryInfo> _files;


        public DirEntriesInfo()
        {
            _searchPattern = "*";
            _searchOption = SearchOption.TopDirectoryOnly;
            _filesOnly = true;

            _directories = new List<DirEntryInfo>();
            _files = new List<DirEntryInfo>();
        }

        [DataMember]
        public List<DirEntryInfo> Directories
        {
            get => _directories;
            set => _directories = value;
        }

        [DataMember]
        public List<DirEntryInfo> Files
        {
            get => _files;
            set => _files = value;
        }

        [DataMember]
        public bool FilesOnly
        {
            get => _filesOnly;
            set => _filesOnly = value;
        }

        [DataMember]
        public string FullPath
        {
            get => _fullPath;
            set => _fullPath = value;
        }

        [DataMember]
        public SearchOption SearchOption
        {
            get => _searchOption;
            set => _searchOption = value;
        }


        [DataMember]
        public string SearchPattern
        {
            get => _searchPattern;
            set => _searchPattern = value;
        }

        public void GetEntries()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_fullPath);
            DirEntryInfo dirEntryInfo;
            if (!_filesOnly)
            {
                foreach (DirectoryInfo di in directoryInfo.GetDirectories(_searchPattern, _searchOption))
                {
                    dirEntryInfo = new DirEntryInfo(di.FullName);
                    _directories.Add(dirEntryInfo);
                }
            }

            foreach (FileInfo fi in directoryInfo.GetFiles(_searchPattern, _searchOption))
            {
                dirEntryInfo = new DirEntryInfo(fi.FullName);
                _files.Add(dirEntryInfo);
            }
        }
    }
}