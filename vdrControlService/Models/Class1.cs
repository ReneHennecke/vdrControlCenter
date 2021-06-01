using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace vdrControlService.Models
{
    [DataContract]
    public class ActionMethod
    {
        private string _fullName;
        private string _name;
        private List<Parameter> _parameters;
        private string _supportedHttpMethods;

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
        public List<Parameter> Parameters 
        { 
            get => _parameters; 
            set => _parameters = value; 
        }

        [DataMember]
        public string SupportedHttpMethods 
        { 
            get => _supportedHttpMethods; 
            set => _supportedHttpMethods = value; 
        }

        public ActionMethod()
        {
            _parameters = new List<Parameter>();
        }
    }

    [DataContract]
    public class Parameter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Source { get; set; } //where we pass the parameter when calling the action
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public List<Parameter> SubParameters { get; set; }

    }
}
