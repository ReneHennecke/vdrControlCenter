namespace DataLayer.Classes
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.Serialization;

    [DataContract]
    public class Highlightning
    {
        private Color _color;
        private Font _font;
        private List<string> _keywords;

        [DataMember]
        public Color Color
        { 
            get => _color; 
            set => _color = value; 
        }

        [DataMember]
        public Font Font 
        { 
            get => _font; 
            set => _font = value; 
        }

        [DataMember]
        public List<string> Keywords 
        { 
            get => _keywords; 
            set => _keywords = value; 
        }

        public Highlightning()
        {
            _color = Color.Black;
            _font = new Font(FontFamily.GenericSansSerif, 9.0f);
            _keywords = new List<string>();
        }
    }
}
