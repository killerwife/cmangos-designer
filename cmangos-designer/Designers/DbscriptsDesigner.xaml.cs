using Data.Definitions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Windows.ApplicationModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Designers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DbscriptsDesigner : Page, INotifyPropertyChanged
    {
        private List<(string, int)> CommandsBinding { get; set; } = new List<(string, int)>();
        private List<DbscriptCommands> Commands { get; set; } = new List<DbscriptCommands>();

        // tooltips
        private string _datalong1Tooltip;
        public string Datalong1Tooltip
        {
            get { return _datalong1Tooltip; }
            set
            {
                _datalong1Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _datalong2Tooltip;
        public string Datalong2Tooltip
        {
            get { return _datalong2Tooltip; }
            set
            {
                _datalong2Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _datalong3Tooltip;
        public string Datalong3Tooltip
        {
            get { return _datalong3Tooltip; }
            set
            {
                _datalong3Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _dataint1Tooltip;
        public string Dataint1Tooltip
        {
            get { return _dataint1Tooltip; }
            set
            {
                _dataint1Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _dataint2Tooltip;
        public string Dataint2Tooltip
        {
            get { return _dataint2Tooltip; }
            set
            {
                _dataint2Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _dataint3Tooltip;
        public string Dataint3Tooltip
        {
            get { return _dataint3Tooltip; }
            set
            {
                _dataint3Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _dataint4Tooltip;
        public string Dataint4Tooltip
        {
            get { return _dataint4Tooltip; }
            set
            {
                _dataint4Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _buddyEntryTooltip;
        public string BuddyEntryTooltip
        {
            get { return _buddyEntryTooltip; }
            set
            {
                _buddyEntryTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _searchRadiusTooltip;
        public string SearchRadiusTooltip
        {
            get { return _searchRadiusTooltip; }
            set
            {
                _searchRadiusTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _commandAdditionalTooltip;
        public string CommandAdditionalTooltip
        {
            get { return _commandAdditionalTooltip; }
            set
            {
                _commandAdditionalTooltip = value;
                OnPropertyChanged();
            }
        }

        public DbscriptsDesigner()
        {
            this.InitializeComponent();
            string pathToFile = Package.Current.InstalledLocation.Path + "\\" + "dbscriptcommands.json";
            string jsonString = File.ReadAllText(pathToFile);
            Commands = JsonSerializer.Deserialize<List<DbscriptCommands>>(jsonString).OrderBy(p => p.Id).ToList();
            foreach (DbscriptCommands command in Commands)
            {
                CommandsBinding.Add((command.Name, command.Id));
            }
            UpdateSourceTarget();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CommandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var commandData = ((string,int))e.AddedItems[0];

            var dbscriptCommand = Commands[commandData.Item2];

            textBlockDatalong1.Text = dbscriptCommand.Datalong;
            Datalong1Tooltip = dbscriptCommand.DatalongTooltip;

            textBlockDatalong2.Text = dbscriptCommand.Datalong2;
            Datalong2Tooltip = dbscriptCommand.DatalongTooltip2;

            textBlockDatalong3.Text = dbscriptCommand.Datalong3;
            Datalong3Tooltip = dbscriptCommand.DatalongTooltip3;

            textBlockDataint1.Text = dbscriptCommand.Dataint;
            Dataint1Tooltip = dbscriptCommand.DataintTooltip;

            textBlockDataint2.Text = dbscriptCommand.Dataint2;
            Dataint2Tooltip = dbscriptCommand.DataintTooltip2;

            textBlockDataint3.Text = dbscriptCommand.Dataint3;
            Dataint3Tooltip = dbscriptCommand.DataintTooltip3;

            textBlockDataint4.Text = dbscriptCommand.Dataint4;
            Dataint4Tooltip = dbscriptCommand.DataintTooltip4;

            checkBoxBuddyCommandAdditional.Content = dbscriptCommand.CommandAdditional;
            CommandAdditionalTooltip = dbscriptCommand.CommandAdditionalTooltip;
        }

        private int computeDbscriptFlagsForTargeting()
        {
            int flags = 0;
            if (checkBoxBuddyAsTarget.IsChecked.Value)
                flags += 1;
            if (checkBoxBuddyReverseDirection.IsChecked.Value)
                flags += 2;
            if (checkBoxBuddySourceTargetsSelf.IsChecked.Value)
                flags += 4;
            return flags;
        }

        private void UpdateSourceTarget()
        {
            string source = "Source: ", target = "Target: ";
            string buddy = checkBoxBuddyAllEligible.IsChecked.Value ? "Buddies" : "Buddy";
            int flags = computeDbscriptFlagsForTargeting();
            if (flags == 0 || flags == 1 || flags == 4 || flags == 5)
                source += "Original Source ";
            if (flags == 0 || flags == 3 || flags == 4 || flags == 7)
                source += (source == "Source: " ? "" : "or ") + buddy;
            if (flags == 2 || flags == 6)
                source += "Original Target";
            if (flags == 0 || flags == 6)
                target += "Original Target";
            if (flags == 2 || flags == 3 || flags == 4 || flags == 5)
                target += "Original Source ";
            if (flags == 1 || flags == 2 || flags == 4 || flags == 7)
                target += (target == "Target: " ? "" : "or ") + buddy;
            textBlockResultingSource.Text = source;
            textBlockResultingTarget.Text = target;
        }

        private void checkBoxBuddies_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSourceTarget();
        }
    }
}
