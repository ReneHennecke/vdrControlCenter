namespace vdrControlService.Models
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Serialization;

    [DataContract]
    public class ApiHelpEndpoint
    {
        [DataMember]
        public string Controller { get; set; }
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public string ReturnType { get; set; }
        [DataMember]
        public string Attributes { get; set; }
        [DataMember]
        public string DisplayableName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string EndpointRoute => $"/api/{Controller}";
        [DataMember]
        public PropertyInfo[] Properties { get; set; }
        [DataMember]
        public List<IList<CustomAttributeTypedArgument>> PropertyDescription { get; set; }
    }
}
