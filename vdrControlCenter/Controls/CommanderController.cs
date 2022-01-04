namespace vdrControlCenterUI.Controls;

public partial class CommanderController : UserControl
{
    private vdrControlCenterContext _context;

    private frmMain _mainForm;
    public frmMain MainForm
    {
        set => _mainForm = value;
    }

    public CommanderController()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        if (_context != null)
        {
            SaveConfig();
            _context.DisposeAsync();
        }

        base.OnHandleDestroyed(e);
    }

    private void PostInit()
    {
        if (_context == null)
            _context = new vdrControlCenterContext();

        DataLayer.Classes.Configuration configuration = ConfigurationHelper.CurrentConfig;

        CommanderPanelView commanderPanelView = configuration.LastCommanderPanelViewLeft;
        cmvLeft.Controller = this;
        cmvLeft.LoadData(commanderPanelView, "cmvLeft");

        commanderPanelView = configuration.LastCommanderPanelViewRight;
        cmvRight.Controller = this;
        cmvRight.LoadData(commanderPanelView, "cmvRight");
    }

    public void SaveConfig()
    {
        Configuration configuration = ConfigurationHelper.CurrentConfig;
        configuration.LastCommanderPanelViewLeft = cmvLeft.CommanderPanelView;
        configuration.LastCommanderPanelViewRight = cmvRight.CommanderPanelView;
        ConfigurationHelper.CurrentConfig = configuration;
    }

    private CommanderView GetTargetView(string name)
    {
        return name == "cmvLeft" ? cmvRight : cmvLeft;
    }

    public FileSystemEntry GetTargetFileSystemEntry(string name)
    {
        CommanderView target = GetTargetView(name);
        return target.CurrentFileSystemEntry;
    }

    public void RefreshTarget(string name)
    {
        CommanderView target = GetTargetView(name);
        target.RefreshView();
    }
}

