namespace vdrControlCenterUI.Classes
{ 
    using System.Drawing;

    public class BashConsoleColorRaX
    {
        public string Sequence { get; set; }
        public Color Color { get; set; }

        public BashConsoleColorRaX(string sequence, Color color)
        {
            Sequence = sequence;
            Color = color;
        }
    }
}
