using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdrControlService.Models
{
    public class FileSystemEntry
    {
        private string _fullPath;

        public FileSystemEntry()
        {

        }

        public FileSystemEntry(string fullPath)
        {
            const string DOS_DRIVE_SEPARATOR = ":";
            
            if (OperatingSystem.IsLinux())
            {
                fullPath = fullPath.Replace("\\", "/");
                if (fullPath.Contains(DOS_DRIVE_SEPARATOR))
                    fullPath = fullPath.Substring(fullPath.IndexOf(DOS_DRIVE_SEPARATOR));
            }

            _fullPath = fullPath;
        }

        public string FullPath
        {
            get => _fullPath;
            set => _fullPath = value;
        }
    }
}
