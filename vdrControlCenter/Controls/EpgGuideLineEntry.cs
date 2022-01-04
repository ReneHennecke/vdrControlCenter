namespace vdrControlCenterUI.Controls;

public partial class EpgGuideLineEntry : UserControl
{
    private Color _colorFirst = Color.WhiteSmoke;                       // first color
    private Color _colorSecond = Color.DarkGray;                        // second color
    private int _colorFirstTransparent = 64;                            // transparency degree (applies to the 1st color)
    private int _colorSecondTransparent = 128;                          // transparency degree (applies to the 2nd color)
    private Color _colorFirstTimer = Color.LightGreen;                  // show timer first color
    private Color _colorSecondTimer = Color.Green;                      // show timer second color
    private Color _colorFirstRecordings = Color.Red;                    // show recording first color
    private Color _colorSecondRecordings = Color.DarkRed;               // show recording second color
    private Color _colorFirstFind = Color.LightGoldenrodYellow;         // show find first color
    private Color _colorSecondFind = Color.DarkGoldenrod;               // show find second color

    private FakeEpg _epg;
    private ToolTip _toolTip = new ToolTip();

    private bool _enableRequest = false;
    private bool _buttonDown = false;
    private bool _isTimer = false;
    private bool _isRecording = false;
    private bool _isFound = false;

    public bool EnableRequest
    {
        get { return _enableRequest; }
        set { _enableRequest = value; }
    }

    public bool IsTimer
    {
        get { return _isTimer; }
        set { _isTimer = value; }
    }
    public bool IsRecording
    {
        get { return _isRecording; }
        set { _isRecording = value; }
    }

    public bool IsFound
    {
        get { return _isFound; }
        set { _isFound = value; }
    }


    public EpgGuideLineEntry()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private void PostInit()
    {
        MouseDown += TimeLineEntry_MouseDown;
        MouseUp += TimeLineEntry_MouseUp;

        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        // Force the ToolTip text to be displayed whether or not the form is active.
        _toolTip.ShowAlways = true;
        _toolTip.IsBalloon = true;
    }

    private void TimeLineEntry_MouseUp(object sender, MouseEventArgs e)
    {
        _buttonDown = false;
        Invalidate();
        ProcessMouseEvent(e);
    }

    private void TimeLineEntry_MouseDown(object sender, MouseEventArgs e)
    {
        _buttonDown = true;
        Invalidate();
        ProcessMouseEvent(e);
    }

    public Color ColorFirst
    {
        get { return _colorFirst; }
        set
        {
            _colorFirst = value;
            Invalidate();
        }
    }

    public Color ColorSecond
    {
        get { return _colorSecond; }
        set
        {
            _colorSecond = value;
            Invalidate();
        }
    }

    public int ColorFirstTransparent
    {
        get { return _colorFirstTransparent; }
        set
        {
            _colorFirstTransparent = value;
            Invalidate();
        }
    }

    public int ColorSecondTransparent2
    {
        get { return _colorSecondTransparent; }
        set
        {
            _colorSecondTransparent = value;
            Invalidate();
        }
    }

    public Color ColorFirstTimer
    {
        get { return _colorFirstTimer; }
        set
        {
            _colorFirstTimer = value;
            Invalidate();
        }
    }

    public Color ColorSecondTimer
    {
        get { return _colorSecondTimer; }
        set
        {
            _colorSecondTimer = value;
            Invalidate();
        }
    }

    public Color ColorFirstRecordings
    {
        get { return _colorFirstRecordings; }
        set
        {
            _colorFirstRecordings = value;
            Invalidate();
        }
    }

    public Color ColorSecondRecordings
    {
        get { return _colorSecondRecordings; }
        set
        {
            _colorSecondRecordings = value;
            Invalidate();
        }
    }

    public FakeEpg Epg
    {
        get { return _epg; }
        set 
        { 
            _epg = value;
            _toolTip.SetToolTip(this, $"{_epg.Title}{Environment.NewLine}{_epg.ShortDescription}{Environment.NewLine}{_epg.StartTime:dd.MM.yyyy HH:mm}");
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        Graphics g = pe.Graphics;
        Pen leftPen;
        Pen rightPen;
        Color c1;
        Color c2;

        if (_isFound)
        {
            leftPen = new Pen(Color.LightYellow, 1);
            rightPen = new Pen(Color.Brown, 1);
            c1 = Color.FromArgb(_colorFirstTransparent, _colorFirstFind);
            c2 = Color.FromArgb(_colorSecondTransparent, _colorSecondFind);
        }
        else if (_isRecording)
        {
            leftPen = new Pen(Color.Orange, 1);
            rightPen = new Pen(Color.DarkRed, 1);
            c1 = Color.FromArgb(_colorFirstTransparent, _colorFirstRecordings);
            c2 = Color.FromArgb(_colorSecondTransparent, _colorSecondRecordings);
        }
        else if (_isTimer)
        {
            leftPen = new Pen(Color.Honeydew, 1);
            rightPen = new Pen(Color.DarkGreen, 1);
            c1 = Color.FromArgb(_colorFirstTransparent, _colorFirstTimer);
            c2 = Color.FromArgb(_colorSecondTransparent, _colorSecondTimer);
        }
        else
        {
            leftPen = new Pen(Color.White, 1);
            rightPen = new Pen(Color.Black, 1);
            c1 = Color.FromArgb(_colorFirstTransparent, _colorFirst);
            c2 = Color.FromArgb(_colorSecondTransparent, _colorSecond);
        }

        if (!_buttonDown)
        {
            g.DrawLine(leftPen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Bottom - 1);
            g.DrawLine(leftPen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Right - 2, ClientRectangle.Top);
            g.DrawLine(rightPen, ClientRectangle.Right - 1, ClientRectangle.Top - 1, ClientRectangle.Right - 1, ClientRectangle.Bottom - 1);
            g.DrawLine(rightPen, ClientRectangle.Left + 1, ClientRectangle.Bottom - 1, ClientRectangle.Right - 1, ClientRectangle.Bottom - 1);
        }
        else
        {
            g.DrawLine(rightPen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Bottom - 1);
            g.DrawLine(rightPen, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Right - 2, ClientRectangle.Top);
            g.DrawLine(leftPen, ClientRectangle.Right - 1, ClientRectangle.Top - 1, ClientRectangle.Right - 1, ClientRectangle.Bottom - 1);
            g.DrawLine(leftPen, ClientRectangle.Left + 1, ClientRectangle.Bottom - 1, ClientRectangle.Right - 1, ClientRectangle.Bottom - 1);
        }

        Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, 10);
        pe.Graphics.FillRectangle(b, ClientRectangle);

        Rectangle r = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Right, ClientRectangle.Bottom);
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;
        g.DrawString(_epg.Title, new Font("Arial", 8), Brushes.Black, r, stringFormat);
        b.Dispose();
    }

    private void cusTimeLineEntry_MouseDown(object sender, EventArgs e)
    {
        _buttonDown = true;
        Invalidate();
    }

    private void cusTimeLineEntry_MouseUp(object sender, EventArgs e)
    {
        _buttonDown = false;
        Invalidate();
    }

    private void ProcessMouseEvent(MouseEventArgs e)
    {
        if (_buttonDown && _enableRequest)
        {
            if (e.Button == MouseButtons.Left)
            {
                dlgEpg dlg = new dlgEpg();
                dlg.PostInit(_epg);
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            else if (e.Button == MouseButtons.Right)
            {

            }

            _buttonDown = false;
            Invalidate();
        }
    }
}

