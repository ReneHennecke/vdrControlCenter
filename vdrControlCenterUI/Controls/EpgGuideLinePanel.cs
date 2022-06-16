namespace vdrControlCenterUI.Controls;

public partial class EpgGuideLinePanel : UserControl
{
    private const int X_START = 142;
    private const int SPAN = 2;

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

        Brush brush = new SolidBrush(BackColor); 
        g.FillRectangle(brush, x1 + SPAN, y1 + SPAN, x2 - SPAN, y2 - SPAN);

        Pen dottedGraykPen = new Pen(Color.DarkGray, 1);
        dottedGraykPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

        x1 = X_START;
        for (int i = 0; i <= 24; i++)
        {
            g.DrawLine(dottedGraykPen, x1, y1 + SPAN, x1, y2 - SPAN);
            x1 += 60;
        }
    }
}

