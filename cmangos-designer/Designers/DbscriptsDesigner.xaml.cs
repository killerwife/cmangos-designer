using Data;
using Data.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Designers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DbscriptsDesigner : Page, INotifyPropertyChanged
    {
        private List<string> CommandsBinding { get; set; } = new List<string>();
        private List<string> TablesBinding { get; set; } = new List<string>();
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

        private string _datafloat1Tooltip;
        public string Datafloat1Tooltip
        {
            get { return _datafloat1Tooltip; }
            set
            {
                _datafloat1Tooltip = value;
                OnPropertyChanged();
            }
        }

        private string _xTooltip;
        public string XTooltip
        {
            get { return _xTooltip; }
            set
            {
                _xTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _yTooltip;
        public string YTooltip
        {
            get { return _yTooltip; }
            set
            {
                _yTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _zTooltip;
        public string ZTooltip
        {
            get { return _zTooltip; }
            set
            {
                _zTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _oriTooltip;
        public string OriTooltip
        {
            get { return _oriTooltip; }
            set
            {
                _oriTooltip = value;
                OnPropertyChanged();
            }
        }

        private string _speedTooltip;
        public string SpeedTooltip
        {
            get { return _speedTooltip; }
            set
            {
                _speedTooltip = value;
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

        public string SelectedTable { get; set; }
        public int SelectedCommand { get; set; } = -1;
        private Dbscripts? SelectedScript { get; set; } = null;

        public ObservableCollection<Dbscripts> Dbscripts { get; set; } = new ObservableCollection<Dbscripts>();

        public Dictionary<string, int> CommandStringPairing = new Dictionary<string, int>();

        public DbscriptsDesigner()
        {
            this.InitializeComponent();
            string pathToFile = Directory.GetCurrentDirectory() + "\\" + "dbscriptcommands.json";
            string jsonString = File.ReadAllText(pathToFile);
            Commands = JsonSerializer.Deserialize<List<DbscriptCommands>>(jsonString).OrderBy(p => p.Id).ToList();
            foreach (DbscriptCommands command in Commands)
            {
                var guiString = command.Id.ToString() + " - " + command.Name;
                CommandsBinding.Add(guiString);
                CommandStringPairing.Add(guiString, command.Id);
            }
            TablesBinding.Add("dbscripts_on_creature_death");
            TablesBinding.Add("dbscripts_on_creature_movement");
            TablesBinding.Add("dbscripts_on_event");
            TablesBinding.Add("dbscripts_on_gossip");
            TablesBinding.Add("dbscripts_on_go_template_use");
            TablesBinding.Add("dbscripts_on_go_use");
            TablesBinding.Add("dbscripts_on_quest_end");
            TablesBinding.Add("dbscripts_on_quest_start");
            TablesBinding.Add("dbscripts_on_relay");
            TablesBinding.Add("dbscripts_on_spell");
            UpdateSourceTarget();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CommandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) // deselected
            {
                textBlockDescription.Text = "";

                textBlockDatalong1.Text = "Datalong";
                Datalong1Tooltip = "";

                textBlockDatalong2.Text = "Datalong2";
                Datalong2Tooltip = "";

                textBlockDatalong3.Text = "Datalong3";
                Datalong3Tooltip = "";

                textBlockDataint1.Text = "Dataint";
                Dataint1Tooltip = "";

                textBlockDataint2.Text = "Dataint2";
                Dataint2Tooltip = "";

                textBlockDataint3.Text = "Dataint3";
                Dataint3Tooltip = "";

                textBlockDataint4.Text = "Dataint4";
                Dataint4Tooltip = "";

                textBlockDatafloat1.Text = "Datafloat";
                Datafloat1Tooltip = "";

                textBlockSpeed.Text = "Speed";
                SpeedTooltip = "";

                checkBoxBuddyCommandAdditional.Content = "Command Additional";
                CommandAdditionalTooltip = "";

                SelectedCommand = -1;
                return;
            }

            var commandData = (string)e.AddedItems[0];

            var index = CommandStringPairing[commandData];
            var dbscriptCommand = Commands[index];

            textBlockDescription.Text = dbscriptCommand.Description;

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

            textBlockDatafloat1.Text = dbscriptCommand.Datafloat;
            Datafloat1Tooltip = dbscriptCommand.DatafloatTooltip1;

            textBlockX.Text = dbscriptCommand.X;
            XTooltip = dbscriptCommand.XTooltip;

            textBlockY.Text = dbscriptCommand.Y;
            YTooltip = dbscriptCommand.YTooltip;

            textBlockZ.Text = dbscriptCommand.Z;
            ZTooltip = dbscriptCommand.ZTooltip;

            textBlockO.Text = dbscriptCommand.Ori;
            OriTooltip = dbscriptCommand.OriTooltip;

            textBlockSpeed.Text = dbscriptCommand.Speed;
            SpeedTooltip = dbscriptCommand.SpeedTooltip;

            checkBoxBuddyCommandAdditional.Content = dbscriptCommand.CommandAdditional;
            CommandAdditionalTooltip = dbscriptCommand.CommandAdditionalTooltip;

            SelectedCommand = index;
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

        public void AddDbscript(Dbscripts dbscript)
        {
            Dbscripts.Add(dbscript);
            OnPropertyChanged("Dbscripts");
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTable = (string)e.AddedItems[0];
        }

        private void DbscriptDatagrid_SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            SelectedScript = (Dbscripts)e.AddedItems[0];
            textBoxId.Text = SelectedScript.Id.ToString();
            textBoxDelay.Text = SelectedScript.Delay.ToString();
            textBoxPriority.Text = SelectedScript.Priority.ToString();
            ComboCommands.SelectedIndex = SelectedScript.Command;
            textBoxDatalong1.Text = SelectedScript.Datalong.ToString();
            textBoxDatalong2.Text = SelectedScript.Datalong2.ToString();
            textBoxDatalong3.Text = SelectedScript.Datalong3.ToString();
            textBoxBuddyEntry.Text = SelectedScript.Buddy_entry.ToString();
            textBoxSearchRadius.Text = SelectedScript.Search_radius.ToString();
            checkBoxBuddyAsTarget.IsChecked = (SelectedScript.Data_Flags & 0x1) == 1;
            checkBoxBuddyReverseDirection.IsChecked = (SelectedScript.Data_Flags & 0x2) == 1;
            checkBoxBuddySourceTargetsSelf.IsChecked = (SelectedScript.Data_Flags & 0x4) == 1;
            checkBoxBuddyCommandAdditional.IsChecked = (SelectedScript.Data_Flags & 0x8) == 1;
            checkBoxBuddyBuddyByGuid.IsChecked = (SelectedScript.Data_Flags & 0x10) == 1;
            checkBoxBuddyIsPet.IsChecked = (SelectedScript.Data_Flags & 0x20) == 1;
            checkBoxBuddyIsDespawned.IsChecked = (SelectedScript.Data_Flags & 0x40) == 1;
            checkBoxBuddyByPool.IsChecked = (SelectedScript.Data_Flags & 0x80) == 1;
            checkBoxBuddyBySpawnGroup.IsChecked = (SelectedScript.Data_Flags & 0x100) == 1;
            checkBoxBuddyAllEligible.IsChecked = (SelectedScript.Data_Flags & 0x200) == 1;
            checkBoxBuddyByGO.IsChecked = (SelectedScript.Data_Flags & 0x400) == 1;
            textBoxDataint1.Text = SelectedScript.Dataint.ToString();
            textBoxDataint2.Text = SelectedScript.Dataint2.ToString();
            textBoxDataint3.Text = SelectedScript.Dataint3.ToString();
            textBoxDataint4.Text = SelectedScript.Dataint4.ToString();
            textBoxDatafloat1.Text = SelectedScript.Datafloat.ToString();
            textBoxX.Text = SelectedScript.X.ToString();
            textBoxY.Text = SelectedScript.Y.ToString();
            textBoxZ.Text = SelectedScript.Z.ToString();
            textBoxO.Text = SelectedScript.O.ToString();
            textBoxSpeed.Text = SelectedScript.Speed.ToString();
            textBoxConditionId.Text = SelectedScript.Condition_id.ToString();
            textBoxComments.Text = SelectedScript.Comments.ToString();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var dbscript = new Dbscripts();
            FillDbscript(dbscript);
            Dbscripts.Add(dbscript);
            OnPropertyChanged("Dbscripts");
        }

        private void FillDbscript(Dbscripts dbscript)
        {
            dbscript.Id = uint.TryParse(textBoxId.Text, out uint u) ? u : (ushort)0;
            dbscript.Delay = uint.TryParse(textBoxDelay.Text, out u) ? u : (uint)0; ;
            dbscript.Priority = uint.TryParse(textBoxPriority.Text, out u) ? u : (uint)0; ;
            dbscript.Command = (ushort)((SelectedCommand != -1) ? SelectedCommand : 0);
            dbscript.Datalong = uint.TryParse(textBoxDatalong1.Text, out u) ? u : (uint)0; ;
            dbscript.Datalong2 = uint.TryParse(textBoxDatalong2.Text, out u) ? u : (uint)0; ;
            dbscript.Datalong3 = uint.TryParse(textBoxDatalong3.Text, out u) ? u : (uint)0; ;
            dbscript.Buddy_entry = ushort.TryParse(textBoxBuddyEntry.Text, out ushort s) ? s : (ushort)0;
            dbscript.Search_radius = ushort.TryParse(textBoxSearchRadius.Text, out s) ? s : (ushort)0;
            uint flags = checkBoxBuddyAsTarget.IsChecked ?? true ? 1u : 0u;
            flags += checkBoxBuddyReverseDirection.IsChecked ?? true ? 2u : 0u;
            flags += checkBoxBuddySourceTargetsSelf.IsChecked ?? true ? 4u : 0u;
            flags += checkBoxBuddyCommandAdditional.IsChecked ?? true ? 8u : 0u;
            flags += checkBoxBuddyBuddyByGuid.IsChecked ?? true ? 16u : 0u;
            flags += checkBoxBuddyIsPet.IsChecked ?? true ? 32u : 0u;
            flags += checkBoxBuddyIsDespawned.IsChecked ?? true ? 64u : 0u;
            flags += checkBoxBuddyByPool.IsChecked ?? true ? 128u : 0u;
            flags += checkBoxBuddyBySpawnGroup.IsChecked ?? true ? 256u : 0u;
            flags += checkBoxBuddyAllEligible.IsChecked ?? true ? 512u : 0u;
            flags += checkBoxBuddyByGO.IsChecked ?? true ? 1024u : 0u;
            dbscript.Data_Flags = flags;
            dbscript.Dataint = int.TryParse(textBoxDataint1.Text, out int i) ? i : (int)0;
            dbscript.Dataint2 = int.TryParse(textBoxDataint2.Text, out i) ? i : (int)0;
            dbscript.Dataint3 = int.TryParse(textBoxDataint3.Text, out i) ? i : (int)0;
            dbscript.Dataint4 = int.TryParse(textBoxDataint4.Text, out i) ? i : (int)0;
            dbscript.Datafloat = float.TryParse(textBoxDatafloat1.Text, out float f) ? f : (float)0;
            dbscript.X = float.TryParse(textBoxX.Text, out f) ? f : (float)0;
            dbscript.Y = float.TryParse(textBoxY.Text, out f) ? f : (float)0;
            dbscript.Z = float.TryParse(textBoxZ.Text, out f) ? f : (float)0;
            dbscript.O = float.TryParse(textBoxO.Text, out f) ? f : (float)0;
            dbscript.Speed = float.TryParse(textBoxSpeed.Text, out f) ? f : (float)0;
            dbscript.Condition_id = ushort.TryParse(textBoxConditionId.Text, out s) ? s : (ushort)0;
            dbscript.Comments = textBoxComments.Text;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxId.Text = "";
            textBoxDelay.Text = "";
            textBoxPriority.Text = "";
            ComboCommands.SelectedIndex = -1;
            textBoxDatalong1.Text = "";
            textBoxDatalong2.Text = "";
            textBoxDatalong3.Text = "";
            textBoxBuddyEntry.Text = "";
            textBoxSearchRadius.Text = "";
            checkBoxBuddyAsTarget.IsChecked = false;
            checkBoxBuddyReverseDirection.IsChecked = false;
            checkBoxBuddySourceTargetsSelf.IsChecked = false;
            checkBoxBuddyCommandAdditional.IsChecked = false;
            checkBoxBuddyBuddyByGuid.IsChecked = false;
            checkBoxBuddyIsPet.IsChecked = false;
            checkBoxBuddyIsDespawned.IsChecked = false;
            checkBoxBuddyByPool.IsChecked = false;
            checkBoxBuddyBySpawnGroup.IsChecked = false;
            checkBoxBuddyAllEligible.IsChecked = false;
            checkBoxBuddyByGO.IsChecked = false;
            textBoxDataint1.Text = "";
            textBoxDataint2.Text = "";
            textBoxDataint3.Text = "";
            textBoxDataint4.Text = "";
            textBoxDatafloat1.Text = "";
            textBoxX.Text = "";
            textBoxY.Text = "";
            textBoxZ.Text = "";
            textBoxO.Text = "";
            textBoxSpeed.Text = "";
            textBoxConditionId.Text = "";
            textBoxComments.Text = "";
        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO " + SelectedTable + "(id, delay, priority, command, datalong, datalong2, datalong3, buddy_entry, search_radius, data_flags, dataint, dataint2, dataint3, dataint4, datafloat, x, y, z, o, speed, condition_id, comments) VALUES\n";
            bool first = true;
            foreach (var dbscript in Dbscripts)
            {
                if (!first)
                    query += ",\n";
                else
                    first = false;
                query += "(";
                query += dbscript.Id + "," + dbscript.Delay + "," + dbscript.Priority + "," + dbscript.Command + "," + dbscript.Datalong + "," + dbscript.Datalong2 + ",";
                query += dbscript.Datalong3 + "," + dbscript.Buddy_entry + "," + dbscript.Search_radius + "," + dbscript.Data_Flags + "," + dbscript.Dataint + ",";
                query += dbscript.Dataint2 + "," + dbscript.Dataint3 + "," + dbscript.Dataint4 + "," + dbscript.Datafloat + "," + dbscript.X + "," + dbscript.Y + ",";
                query += dbscript.Z + "," + dbscript.O + "," + dbscript.Speed + "," + dbscript.Condition_id + ",'" + dbscript.Comments + "'";
                query += ")";
            }
            query += ";";
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(query);
            Clipboard.SetContent(dataPackage);
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedScript != null)
            {
                FillDbscript(SelectedScript);
                OnPropertyChanged("Dbscripts");
            }
        }

        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            Dbscripts.Clear();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTable == null || SelectedTable.Length == 0)
                return;

            var container = ((App)App.Current).Container;
            var mysql = (WorldDbContext)container.GetService(typeof(WorldDbContext));
            Dbscripts.Clear();
            uint Id = uint.TryParse(textBoxId.Text, out uint u) ? u : 0;
            var results = mysql.Dbscripts.FromSqlRaw("SELECT * FROM " + SelectedTable + " WHERE Id ='" + Id.ToString() + "'").ToList();
            foreach (var result in results)
                Dbscripts.Add(result);
        }
    }
}
