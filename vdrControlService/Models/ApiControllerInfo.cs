namespace vdrControlService.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ApiControllerInfo
    {
        private string _fullName;
        private string _name;
        private List<ApiMethodInfo> _methods;

        [DataMember]
        public string Controller
        {
            get => _name.Replace("Controller", string.Empty);
        }

        [DataMember]
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        [DataMember]
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [DataMember]
        public List<ApiMethodInfo> Methods
        {
            get => _methods;
            set => _methods = value;
        }

        public ApiControllerInfo()
        {
            _methods = new List<ApiMethodInfo>();
        }
    }
}
