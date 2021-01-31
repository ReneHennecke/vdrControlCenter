namespace vdrControlService.Models.Requests
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ApiRequest
    {
        private Guid _authorization;
        public Guid Authorization
        {
            get => _authorization;
            set => _authorization = value;
        }

        private Guid _requestId;
        [DataMember]
        public Guid RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }

        public ApiRequest()
        {
            _requestId = Guid.NewGuid();
        }
    }
}
