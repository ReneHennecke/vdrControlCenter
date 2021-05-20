using System;

namespace vdrControlService.Models
{
    public class FileContent
    {
        private string _fullPath;
        private string _content;
        private ErrorResult _errorResult;

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

        public ErrorResult ErrorResult
        {
            get => _errorResult;
            set => _errorResult = value;
        }

        public FileContent()
        {
            _errorResult = new ErrorResult();
        }
    }
}
