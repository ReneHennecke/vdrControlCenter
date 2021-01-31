namespace vdrControlService.Model
{
    using System;
    using System.Runtime.Serialization;
    using vdrControlService.Enums;

    [DataContract]
    public class ErrorResult
    {
        private string _errorMessage = string.Empty;

        [DataMember]
        public ErrorResultCode ErrorCode { get; set; }
        [DataMember]
        public string ErrorMessage 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_errorMessage))
                    _errorMessage = ErrorCode.ToString();

                return _errorMessage;
            }
            set => _errorMessage = value; 
        }
        [DataMember]
        public Exception ErrorException { get; set; }
        [DataMember]
        public bool Success 
        { 
            get => ErrorCode == ErrorResultCode.Success;
        }

        public static ErrorResult CreateSuccess()
        {
            return new ErrorResult()
            {
                ErrorCode = ErrorResultCode.Success,
                ErrorMessage = string.Empty
            };
        }
    }
}
