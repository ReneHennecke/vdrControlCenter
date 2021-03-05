namespace DataLayer.Classes
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class HighlightningConfiguration
    {
        private List<Highlightning> _highlightnings;

        [DataMember]
        public List<Highlightning> Highlightnings
        {
            get => _highlightnings;
            set => _highlightnings = value;
        }

        public HighlightningConfiguration()
        {
            _highlightnings = new List<Highlightning>();
        }
    }
}
