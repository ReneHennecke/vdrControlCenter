namespace vdrControlService.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ApiMethodInfo
    {
        private string _fullName;
        private string _name;
        private List<Parameter> _parameters;

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
        public List<Parameter> Parameters
        {
            get => _parameters;
            set => _parameters = value;
        }

        public ApiMethodInfo()
        {
            _parameters = new List<Parameter>();
        }
    }
}
