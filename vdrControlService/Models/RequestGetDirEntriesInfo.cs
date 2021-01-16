namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class RequestGetDirEntriesInfo : StandardRequest
    {
        private string _filePath;

        public RequestGetDirEntriesInfo() : base()
        {

        }

        [DataMember]
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }
    }
}
