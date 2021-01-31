﻿namespace vdrControlService.Models.Responses
{
    using System;
    using System.Runtime.Serialization;
    using vdrControlService.Model;

    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public Guid RequestId{ get; set; }

        private Guid _responseId;
        [DataMember]
        public Guid ResponseId 
        { 
            get => _responseId; 
            set => _responseId = value; 
        }

        private ErrorResult _errorResult;
        [DataMember]
        public ErrorResult ErrorResult 
        { 
            get => _errorResult;
            set => _errorResult = value;
        }

        public ApiResponse()
        {
            _responseId = Guid.NewGuid();
            _errorResult = ErrorResult.CreateSuccess();
        }

        public string Test { get; set; }
    }
}
