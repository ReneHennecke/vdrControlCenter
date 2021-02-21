using System;

namespace vdrControlService.Models
{
    public class FileContent
    {
        private string _fullPath;
        private string _content;
        private Exception _exception;

        public string FullPath 
        { 
            get => _fullPath; 
            set => _fullPath = value; 
        }

        public string Content 
        { 
            get => _content; 
            set => _content = value; 
        }

        public Exception Exception
        {
            get => _exception;
            set => _exception = value;
        }
    }
}
