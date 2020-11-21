namespace vdrControlCenterUI.Controls
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class EpgGuideLinePanel : UserControl
    {
        public EpgGuideLinePanel()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Neu zeichnen
            Graphics g = e.Graphics;
            int x1 = ClientRectangle.Left;
            int y1 = ClientRectangle.Top;
            int x2 = ClientRectangle.Right;
            int y2 = ClientRectangle.Bottom;

            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, x1 + 142, y1 + 2, x2 - 2, y2 - 2);

            y1 += 26;
            Pen blackPen = new Pen(Color.Black, 1);
            g.DrawLine(blackPen, x1 + 142, y1, x1 + 1582, y1);      // 142 + 1440 (min)

            Pen dottedBlackPen = new Pen(Color.Black, 1);
            dottedBlackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            x1 = 142;
            int y;
            for (int i = 0; i <= 1440; i += 15)
            {
                if (i == 0 || i % 60 == 0)
                    y = y1 - 17;
                else if (i % 60 != 0 && i % 30 == 0)
                    y = y1 - 9;
                else
                    y = y1 - 4;

                g.DrawLine(blackPen, x1, y1, x1, y);

                if (i == 0 || i % 60 == 0)
                {
                    g.DrawLine(dottedBlackPen, x1, y1, x1, y2 - 2);
                    if (i < 1440)
                    {
                        Rectangle r = new Rectangle(x1 - 15, y1 - 20, x1 + 15, y1 - 26);
                        g.DrawString($"{i / 60:D2}:00", new Font("Arial", 7), Brushes.Black, r);
                    }
                }

                x1 += 15;
            }
        }
    }
}
