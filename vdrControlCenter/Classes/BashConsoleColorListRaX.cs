namespace vdrControlCenterUI.Classes
{ 
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public static class BashConsoleColorListRaX
    {
        private static List<BashConsoleColorRaX> _bashConsoleColorList;
        public static List<BashConsoleColorRaX> ColorList
        {
            get { return _bashConsoleColorList; }
        }

        static BashConsoleColorListRaX()
        {
            _bashConsoleColorList = new List<BashConsoleColorRaX>();

            _bashConsoleColorList.Add(new BashConsoleColorRaX("0", Color.Transparent));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;30", Color.Black));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;34", Color.Blue));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;32", Color.Green));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;36", Color.Cyan));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;31", Color.Red));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;35", Color.Purple));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;33", Color.Brown));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("00;37", Color.LightGray));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;30", Color.DarkGray));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;34", Color.RoyalBlue));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;32", Color.LightGreen));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;36", Color.LightCyan));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;31", Color.OrangeRed));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;35", Color.MediumPurple));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;33", Color.Yellow));
            _bashConsoleColorList.Add(new BashConsoleColorRaX("01;37", Color.White));
        }

        public static Color GetColor(string sequence)
        {
            return (_bashConsoleColorList.SingleOrDefault(x => x.Sequence == sequence) ?? _bashConsoleColorList[0]).Color;
        }
    }
}
