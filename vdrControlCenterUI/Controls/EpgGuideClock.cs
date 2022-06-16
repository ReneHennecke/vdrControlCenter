namespace vdrControlCenterUI.Controls;

public partial class EpgGuideClock : UserControl
{
    private DateTime _currentDate = DateTime.Now.Date;

    private const int X_START = 142;
    private const int Y_START = 26;
    private const int SPAN = 2;
    private const int DAY_MINUTES = 1440;
    private const int STEP = 15;

    public DateTime CurrentDate
    {
        set
        {
            _currentDate = value.Date;
            tmClock.Enabled = (_currentDate.CompareTo(DateTime.Now.Date) == 0);
            tmClock_Tick(null, null);
        }
    }

    public EpgGuideClock()
    {
        InitializeComponent();

        PostInit();
    }

    private void PostInit()
    {
        DoubleBuffered = true;

        CurrentDate = DateTime.Now;
        tmClock_Tick(null, null);
    
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
        g.FillRectangle(brush, x1 + X_START, y1 + SPAN, x2 - SPAN, y2 - SPAN);

        x1 += X_START;
        y1 += Y_START;
        Pen blackPen = new Pen(Color.Black, 1);
        g.DrawLine(blackPen, x1, y1, x1 + DAY_MINUTES, y1); 

        int y;
        for (int i = 0; i <= DAY_MINUTES; i += STEP)
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
                if (i < 1440)
                {
                    Rectangle r = new Rectangle(x1 - STEP, y1 - 20, x1 + STEP, y1 - 26);
                    g.DrawString($"{i / 60:D2}:00", new Font("Arial", 7), Brushes.Black, r);
                }
            }

            x1 += STEP;
        }

        if (_currentDate.CompareTo(DateTime.Now.Date) == 0)
        {
            DateTime now = DateTime.Now;
            TimeSpan diff = now - now.Date;
            int minutes = (int)diff.TotalMinutes;

            x1 = X_START + minutes;
            y = Y_START;
            Pen red = new Pen(Color.Red, 3);
            g.DrawLine(red, x1, y, x1, y - 15);
        }
    }

    private void tmClock_Tick(object sender, System.EventArgs e)
    {
        Invalidate();
    }
}

