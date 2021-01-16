namespace vdrControlService.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class StandardResponse
    {
        private Guid _requestId;
        private Guid _responseId;

        public StandardResponse()
        {
            _responseId = Guid.NewGuid();
        }

        [DataMember]
        public Guid RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }

        [DataMember]
        public Guid ResponseId
        {
            get => _responseId;
            set => _responseId = value;
        }
    }
}
