namespace vdrControlService.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class StandardRequest
    {
        private Guid _requestId;

        public StandardRequest()
        {
            _requestId = Guid.NewGuid();
        }

        [DataMember]
        public Guid RequestId 
        {
            get => _requestId;
            set => _requestId = value; 
        }
    }
}
