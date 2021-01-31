namespace vdrControlService.Models
{
    using System.Runtime.Serialization;
    using vdrControlService.Model;

    [DataContract]
    public class InfoResult
    {
        private ErrorResult _errorResult;
        [DataMember]
        public ErrorResult ErrorResult 
        { 
            get => _errorResult; 
            set => _errorResult = value; 
        }

        public InfoResult()
        {
            _errorResult = ErrorResult.CreateSuccess();
        }
    }
}
