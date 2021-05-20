﻿namespace vdrControlCenterUI.Controls
{
    using DataLayer.Classes;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using vdrControlService.Models;

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

        private async void PostInit()
        {
            if (_context == null)
                _context = new vdrControlCenterContext();

            Configuration configuration = null;
            SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
            if (systemSettings != null)
            {
                if (systemSettings.Configuration != null)
                    configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);
            }

            CommanderPanelView commanderPanelView = configuration.LastCommanderPanelViewLeft;
            List<CommanderPanelView> commanderViewList = configuration.CommanderViewListLeft;
            cmvLeft.Controller = this;
            cmvLeft.LoadData(commanderPanelView, commanderViewList, "cmvLeft");

            commanderPanelView = configuration.LastCommanderPanelViewRight;
            commanderViewList = configuration.CommanderViewListRight;
            cmvRight.Controller = this;
            cmvRight.LoadData(commanderPanelView, commanderViewList, "cmvRight");
        }

        public async void SaveConfig()
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                    {
                        Configuration configuration = null;
                        if (systemSettings.Configuration != null)
                            configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);
                        else
                            configuration = new Configuration();

                        configuration.LastCommanderPanelViewLeft = cmvLeft.CommanderPanelView;
                        configuration.CommanderViewListLeft = cmvLeft.CommanderList;
                        configuration.LastCommanderPanelViewRight = cmvRight.CommanderPanelView;
                        configuration.CommanderViewListRight = cmvRight.CommanderList;

                        systemSettings.Configuration = JsonConvert.SerializeObject(configuration, Formatting.Indented);
                        _context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch //(Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
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
}
