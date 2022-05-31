using Data.Db;
using Data.Definitions;
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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Designers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EAIDesigner : Page, INotifyPropertyChanged
    {
        private List<string> EventBinding { get; set; } = new List<string>();
        private List<string> ActionBinding { get; set; } = new List<string>();
        private List<List<TextBlock>> ActionParamsPerAction { get; set; } = new List<List<TextBlock>>();
        private List<EventAIEvents> Events { get; set; }
        private Dictionary<string, int> EventsPairing { get; set; } = new Dictionary<string, int>();
        private List<EventAIActions> Actions { get; set; }
        private Dictionary<string, int> ActionsPairing { get; set; } = new Dictionary<string, int>();

        public string CastFlags { get; set; }
        public string Targets { get; set; }

        private EventAIScript? SelectedScript { get; set; } = null;
        private ObservableCollection<EventAIScript> EventAIScripts { get; set; } = new ObservableCollection<EventAIScript>();

        // tooltips
        private string _eventDescriptionTooltip;
        public string EventDescriptionTooltip
        {
            get { return _eventDescriptionTooltip; }
            set { _eventDescriptionTooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam1Tooltip;
        public string EventParam1Tooltip
        {
            get { return _eventParam1Tooltip; }
            set { _eventParam1Tooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam2Tooltip;
        public string EventParam2Tooltip
        {
            get { return _eventParam2Tooltip; }
            set { _eventParam2Tooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam3Tooltip;
        public string EventParam3Tooltip
        {
            get { return _eventParam3Tooltip; }
            set { _eventParam3Tooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam4Tooltip;
        public string EventParam4Tooltip
        {
            get { return _eventParam4Tooltip; }
            set { _eventParam4Tooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam5Tooltip;
        public string EventParam5Tooltip
        {
            get { return _eventParam5Tooltip; }
            set { _eventParam5Tooltip = value; OnPropertyChanged(); }
        }
        private string _eventParam6Tooltip;
        public string EventParam6Tooltip
        {
            get { return _eventParam6Tooltip; }
            set { _eventParam6Tooltip = value; OnPropertyChanged(); }
        }

        private string _action1TypeTooltip;
        public string Action1TypeTooltip
        {
            get { return _action1TypeTooltip; }
            set { _action1TypeTooltip = value; OnPropertyChanged(); }
        }
        private string _action1Param1Tooltip;
        public string Action1Param1Tooltip
        {
            get { return _action1Param1Tooltip; }
            set { _action1Param1Tooltip = value; OnPropertyChanged(); }
        }
        private string _action1Param2Tooltip;
        public string Action1Param2Tooltip
        {
            get { return _action1Param2Tooltip; }
            set { _action1Param2Tooltip = value; OnPropertyChanged(); }
        }
        private string _action1Param3Tooltip;
        public string Action1Param3Tooltip
        {
            get { return _action1Param3Tooltip; }
            set { _action1Param3Tooltip = value; OnPropertyChanged(); }
        }

        private string _action2TypeTooltip;
        public string Action2TypeTooltip
        {
            get { return _action2TypeTooltip; }
            set { _action2TypeTooltip = value; OnPropertyChanged(); }
        }
        private string _action2Param1Tooltip;
        public string Action2Param1Tooltip
        {
            get { return _action2Param1Tooltip; }
            set { _action2Param1Tooltip = value; OnPropertyChanged(); }
        }
        private string _action2Param2Tooltip;
        public string Action2Param2Tooltip
        {
            get { return _action2Param2Tooltip; }
            set { _action2Param2Tooltip = value; OnPropertyChanged(); }
        }
        private string _action2Param3Tooltip;
        public string Action2Param3Tooltip
        {
            get { return _action2Param3Tooltip; }
            set { _action2Param3Tooltip = value; OnPropertyChanged(); }
        }

        private string _action3TypeTooltip;
        public string Action3TypeTooltip
        {
            get { return _action3TypeTooltip; }
            set { _action3TypeTooltip = value; OnPropertyChanged(); }
        }
        private string _action3Param1Tooltip;
        public string Action3Param1Tooltip
        {
            get { return _action3Param1Tooltip; }
            set { _action3Param1Tooltip = value; OnPropertyChanged(); }
        }
        private string _action3Param2Tooltip;
        public string Action3Param2Tooltip
        {
            get { return _action3Param2Tooltip; }
            set { _action3Param2Tooltip = value; OnPropertyChanged(); }
        }
        private string _action3Param3Tooltip;
        public string Action3Param3Tooltip
        {
            get { return _action3Param3Tooltip; }
            set { _action3Param3Tooltip = value; OnPropertyChanged(); }
        }

        private string _castFlagsTooltip;
        public string CastFlagsTooltip
        {
            get { return _castFlagsTooltip; }
            set { _castFlagsTooltip = value; OnPropertyChanged(); }
        }
        private string _targetsTooltip;
        public string TargetsTooltip
        {
            get { return _targetsTooltip; }
            set { _targetsTooltip = value; OnPropertyChanged(); }
        }

        public EAIDesigner()
        {
            this.InitializeComponent();
            ActionParamsPerAction.Add(new List<TextBlock>());
            ActionParamsPerAction.Add(new List<TextBlock>());
            ActionParamsPerAction.Add(new List<TextBlock>());
            ActionParamsPerAction[0].Add(textBlockAction1Param1);
            ActionParamsPerAction[0].Add(textBlockAction1Param2);
            ActionParamsPerAction[0].Add(textBlockAction1Param3);
            ActionParamsPerAction[0].Add(textBlockAction2Param1);
            ActionParamsPerAction[0].Add(textBlockAction2Param2);
            ActionParamsPerAction[0].Add(textBlockAction2Param3);
            ActionParamsPerAction[0].Add(textBlockAction3Param1);
            ActionParamsPerAction[0].Add(textBlockAction3Param2);
            ActionParamsPerAction[0].Add(textBlockAction3Param3);
            {
                string pathToFile = Directory.GetCurrentDirectory() + "\\" + "eventAIEvents.json";
                string jsonString = File.ReadAllText(pathToFile);
                Events = JsonSerializer.Deserialize<List<EventAIEvents>>(jsonString).OrderBy(p => p.Id).ToList();
                foreach (EventAIEvents eventData in Events)
                {
                    var guiString = eventData.Id.ToString() + " - " + eventData.Name;
                    EventBinding.Add(guiString);
                    EventsPairing.Add(guiString, eventData.Id);
                }
            }
            {
                string pathToFile = Directory.GetCurrentDirectory() + "\\" + "eventAIActions.json";
                string jsonString = File.ReadAllText(pathToFile);
                Actions = JsonSerializer.Deserialize<List<EventAIActions>>(jsonString).OrderBy(p => p.Id).ToList();
                foreach (EventAIActions actionData in Actions)
                {
                    var guiString = actionData.Id.ToString() + " - " + actionData.Name;
                    ActionBinding.Add(guiString);
                    ActionsPairing.Add(guiString, actionData.Id);
                }
            }
            {
                string pathToFile = Directory.GetCurrentDirectory() + "\\" + "castFlags.json";
                string jsonString = File.ReadAllText(pathToFile);
                var castFlags = JsonSerializer.Deserialize<List<AICastFlags>>(jsonString).OrderBy(p => p.Flag).ToList();
                foreach (var castFlag in castFlags)
                    CastFlags += castFlag.Flag.ToString() + " - " + castFlag.Name.ToString() + " - " + castFlag.Description + "\n";
                CastFlagsTooltip = CastFlags;
            }
            {
                string pathToFile = Directory.GetCurrentDirectory() + "\\" + "eventAITargets.json";
                string jsonString = File.ReadAllText(pathToFile);
                var targets = JsonSerializer.Deserialize<List<EventAITargets>>(jsonString).OrderBy(p => p.Id).ToList();
                foreach (var target in targets)
                    Targets += target.Id.ToString() + " - " + target.Name.ToString() + " - " + target.Description + "\n";
                TargetsTooltip = Targets;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ComboEventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) // deselected
            {
                textBoxEventParam1.Text = "";
                textBoxEventParam2.Text = "";
                textBoxEventParam3.Text = "";
                textBoxEventParam4.Text = "";
                textBoxEventParam5.Text = "";
                textBoxEventParam6.Text = "";
                EventDescriptionTooltip = "";
                EventParam1Tooltip = "";
                EventParam2Tooltip = "";
                EventParam3Tooltip = "";
                EventParam4Tooltip = "";
                EventParam5Tooltip = "";
                EventParam6Tooltip = "";
                return;
            }

            var commandData = (string)e.AddedItems[0];

            var index = EventsPairing[commandData];
            var scriptEvent = Events[index];

            textBlockEventParam1.Text = scriptEvent.Param1;
            textBlockEventParam2.Text = scriptEvent.Param2;
            textBlockEventParam3.Text = scriptEvent.Param3;
            textBlockEventParam4.Text = scriptEvent.Param4;
            textBlockEventParam5.Text = scriptEvent.Param5;
            textBlockEventParam6.Text = scriptEvent.Param6;
            EventDescriptionTooltip = scriptEvent.Description;
            EventParam1Tooltip = scriptEvent.Param1Tooltip;
            EventParam2Tooltip = scriptEvent.Param2Tooltip;
            EventParam3Tooltip = scriptEvent.Param3Tooltip;
            EventParam4Tooltip = scriptEvent.Param4Tooltip;
            EventParam5Tooltip = scriptEvent.Param5Tooltip;
            EventParam6Tooltip = scriptEvent.Param6Tooltip;
        }

        private void ComboAction1Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int senderIndex = 0;
            if (sender == ComboAction2Type)
                senderIndex = 1;
            else if (sender == ComboAction3Type)
                senderIndex = 2;

            if (e.AddedItems.Count == 0) // deselected
            {
                if (senderIndex == 0)
                {
                    textBlockAction1Param1.Text = "";
                    textBlockAction1Param2.Text = "";
                    textBlockAction1Param3.Text = "";
                    Action1TypeTooltip = "";
                    Action1Param1Tooltip = "";
                    Action1Param2Tooltip = "";
                    Action1Param3Tooltip = "";
                }
                else if (senderIndex == 1)
                {
                    textBlockAction2Param1.Text = "";
                    textBlockAction2Param2.Text = "";
                    textBlockAction2Param3.Text = "";
                    Action1TypeTooltip = "";
                    Action2Param1Tooltip = "";
                    Action2Param2Tooltip = "";
                    Action2Param3Tooltip = "";
                }
                else
                {
                    textBlockAction3Param1.Text = "";
                    textBlockAction3Param2.Text = "";
                    textBlockAction3Param3.Text = "";
                    Action3TypeTooltip = "";
                    Action3Param1Tooltip = "";
                    Action3Param2Tooltip = "";
                    Action3Param3Tooltip = "";
                }
                return;
            }

            var commandData = (string)e.AddedItems[0];

            var index = ActionsPairing[commandData] - 1;
            var scriptAction = Actions[index];

            if (senderIndex == 0)
            {
                textBlockAction1Param1.Text = scriptAction.Param1;
                textBlockAction1Param2.Text = scriptAction.Param2;
                textBlockAction1Param3.Text = scriptAction.Param3;
                Action1TypeTooltip = scriptAction.Description;
                Action1Param1Tooltip = scriptAction.Param1Tooltip;
                Action1Param2Tooltip = scriptAction.Param2Tooltip;
                Action1Param3Tooltip = scriptAction.Param3Tooltip;
            }
            else if (senderIndex == 1)
            {
                textBlockAction2Param1.Text = scriptAction.Param1;
                textBlockAction2Param2.Text = scriptAction.Param2;
                textBlockAction2Param3.Text = scriptAction.Param3;
                Action2TypeTooltip = scriptAction.Description;
                Action2Param1Tooltip = scriptAction.Param1Tooltip;
                Action2Param2Tooltip = scriptAction.Param2Tooltip;
                Action2Param3Tooltip = scriptAction.Param3Tooltip;
            }
            else
            {
                textBlockAction3Param1.Text = scriptAction.Param1;
                textBlockAction3Param2.Text = scriptAction.Param2;
                textBoxAction3Param3.Text = scriptAction.Param3;
                Action3TypeTooltip = scriptAction.Description;
                Action3Param1Tooltip = scriptAction.Param1Tooltip;
                Action3Param2Tooltip = scriptAction.Param2Tooltip;
                Action3Param3Tooltip = scriptAction.Param3Tooltip;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                ClearTextBoxes();
                return;
            }

            SelectedScript = (EventAIScript)e.AddedItems[0];
            textBoxId.Text = SelectedScript.Id.ToString();
            textBoxCreatureId.Text = SelectedScript.Creature_id.ToString();
            ComboEventType.SelectedIndex = (int)SelectedScript.Event_type;
            textBoxInversePhaseMask.Text = SelectedScript.Event_inverse_phase_mask.ToString();
            uint flags = SelectedScript.Event_flags;
            checkBoxRepeatable.IsChecked = (flags & 0x1) == 1;
            checkBoxDifficulty0.IsChecked = (flags & 0x2) == 1;
            checkBoxDifficulty1.IsChecked = (flags & 0x4) == 1;
            checkBoxDifficulty2.IsChecked = (flags & 0x8) == 1;
            checkBoxDifficulty3.IsChecked = (flags & 0x10) == 1;
            checkBoxRandomAction.IsChecked = (flags & 0x20) == 1;
            checkBoxDebugOnly.IsChecked = (flags & 0x80) == 1;
            checkBoxRangedModeOnly.IsChecked = (flags & 0x100) == 1;
            checkBoxMeleeModeOnly.IsChecked = (flags & 0x200) == 1;
            checkBoxCombatAction.IsChecked = (flags & 0x400) == 1;
            textBoxEventChance.Text = SelectedScript.Event_chance.ToString();
            textBoxEventParam1.Text = SelectedScript.Event_param1.ToString();
            textBoxEventParam2.Text = SelectedScript.Event_param2.ToString();
            textBoxEventParam3.Text = SelectedScript.Event_param3.ToString();
            textBoxEventParam4.Text = SelectedScript.Event_param4.ToString();
            textBoxEventParam5.Text = SelectedScript.Event_param5.ToString();
            textBoxEventParam6.Text = SelectedScript.Event_param6.ToString();
            if (SelectedScript.Action1_type == 0)
                ComboAction1Type.SelectedIndex = -1;
            else
                ComboAction1Type.SelectedIndex = (int)SelectedScript.Action1_type - 1;
            textBoxAction1Param1.Text = SelectedScript.Action1_param1.ToString();
            textBoxAction1Param2.Text = SelectedScript.Action1_param2.ToString();
            textBoxAction1Param3.Text = SelectedScript.Action1_param3.ToString();
            if (SelectedScript.Action2_type == 0)
                ComboAction2Type.SelectedIndex = -1;
            else
                ComboAction2Type.SelectedIndex = (int)SelectedScript.Action2_type - 1;
            textBoxAction2Param1.Text = SelectedScript.Action2_param1.ToString();
            textBoxAction2Param2.Text = SelectedScript.Action2_param2.ToString();
            textBoxAction2Param3.Text = SelectedScript.Action2_param3.ToString();
            if (SelectedScript.Action3_type == 0)
                ComboAction3Type.SelectedIndex = -1;
            else
                ComboAction3Type.SelectedIndex = (int)SelectedScript.Action3_type - 1;
            textBoxAction3Param1.Text = SelectedScript.Action3_param1.ToString();
            textBoxAction3Param2.Text = SelectedScript.Action3_param2.ToString();
            textBoxAction3Param3.Text = SelectedScript.Action3_param3.ToString();
            textBoxComment.Text = SelectedScript.Comment;
        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO `creature_ai_scripts` (`id`,`creature_id`,`event_type`,`event_inverse_phase_mask`,`event_chance`,`event_flags`,`event_param1`,`event_param2`,`event_param3`,`event_param4`,`event_param5`,`event_param6`,`action1_type`,`action1_param1`,`action1_param2`,`action1_param3`,`action2_type`,`action2_param1`,`action2_param2`,`action2_param3`,`action3_type`,`action3_param1`,`action3_param2`,`action3_param3`,`comment`) VALUES\n";
            bool first = true;
            foreach (var script in EventAIScripts)
            {
                if (!first)
                    query += ",\n";
                else
                    first = false;
                query += "('";
                query += script.Id + "','" + script.Creature_id + "','" + script.Event_type + "','" + script.Event_inverse_phase_mask + "','" + script.Event_chance + "','" + script.Event_flags + "','";
                query += script.Event_param1 + "','" + script.Event_param2 + "','" + script.Event_param3 + "','" + script.Event_param4 + "','" + script.Event_param5 + "','";
                query += script.Event_param6 + "','" + script.Action1_type + "','" + script.Action1_param1 + "','" + script.Action1_param2 + "','" + script.Action1_param3 + "','";
                query += script.Action2_type + "','" + script.Action2_param1 + "','" + script.Action2_param2 + "','" + script.Action2_param3 + "','";
                query += script.Action3_type + "','" + script.Action3_param1 + "','" + script.Action3_param2 + "','" + script.Action3_param3 + "','" + script.Comment.Replace("'", "''") + "'";
                query += ")";
            }
            query += ";";
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(query);
            Clipboard.SetContent(dataPackage);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var script = new EventAIScript();
            FillScript(script);
            EventAIScripts.Add(script);
            OnPropertyChanged("EventAIScripts");
        }

        private void FillScript(EventAIScript script)
        {
            script.Id = uint.TryParse(textBoxId.Text, out uint u) ? u : 0;
            script.Creature_id = uint.TryParse(textBoxCreatureId.Text, out u) ? u : 0;
            script.Event_type = ComboEventType.SelectedIndex >= 0 ? (uint)ComboEventType.SelectedIndex : 0;
            script.Event_inverse_phase_mask = int.TryParse(textBoxInversePhaseMask.Text, out int i) ? i : 0;
            script.Event_chance = uint.TryParse(textBoxEventChance.Text, out u) ? u : 0;
            uint flags = 0;
            if (checkBoxRepeatable.IsChecked == true)
                flags |= 0x1;
            if (checkBoxDifficulty0.IsChecked == true)
                flags |= 0x2;
            if (checkBoxDifficulty1.IsChecked == true)
                flags |= 0x4;
            if (checkBoxDifficulty2.IsChecked == true)
                flags |= 0x8;
            if (checkBoxDifficulty3.IsChecked == true)
                flags |= 0x10;
            if (checkBoxRandomAction.IsChecked == true)
                flags |= 0x20;
            if (checkBoxDebugOnly.IsChecked == true)
                flags |= 0x80;
            if (checkBoxRangedModeOnly.IsChecked == true)
                flags |= 0x100;
            if (checkBoxMeleeModeOnly.IsChecked == true)
                flags |= 0x200;
            if (checkBoxCombatAction.IsChecked == true)
                flags |= 0x400;
            script.Event_flags = flags;
            script.Event_param1 = int.TryParse(textBoxEventParam1.Text, out i) ? i : 0;
            script.Event_param2 = int.TryParse(textBoxEventParam2.Text, out i) ? i : 0;
            script.Event_param3 = int.TryParse(textBoxEventParam3.Text, out i) ? i : 0;
            script.Event_param4 = int.TryParse(textBoxEventParam4.Text, out i) ? i : 0;
            script.Event_param5 = int.TryParse(textBoxEventParam5.Text, out i) ? i : 0;
            script.Event_param6 = int.TryParse(textBoxEventParam6.Text, out i) ? i : 0;
            script.Action1_type = ComboAction1Type.SelectedIndex >= 0 ? (uint)ComboAction1Type.SelectedIndex + 1 : 0;
            script.Action1_param1 = int.TryParse(textBoxAction1Param1.Text, out i) ? i : 0;
            script.Action1_param2 = int.TryParse(textBoxAction1Param2.Text, out i) ? i : 0;
            script.Action1_param3 = int.TryParse(textBoxAction1Param3.Text, out i) ? i : 0;
            script.Action2_type = ComboAction2Type.SelectedIndex >= 0 ? (uint)ComboAction2Type.SelectedIndex + 1 : 0;
            script.Action2_param1 = int.TryParse(textBoxAction2Param1.Text, out i) ? i : 0;
            script.Action2_param2 = int.TryParse(textBoxAction2Param2.Text, out i) ? i : 0;
            script.Action2_param3 = int.TryParse(textBoxAction2Param3.Text, out i) ? i : 0;
            script.Action3_type = ComboAction3Type.SelectedIndex >= 0 ? (uint)ComboAction3Type.SelectedIndex + 1 : 0;
            script.Action3_param1 = int.TryParse(textBoxAction3Param1.Text, out i) ? i : 0;
            script.Action3_param2 = int.TryParse(textBoxAction3Param2.Text, out i) ? i : 0;
            script.Action3_param3 = int.TryParse(textBoxAction3Param3.Text, out i) ? i : 0;
            script.Comment = textBoxComment.Text;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedScript != null)
            {
                FillScript(SelectedScript);
                OnPropertyChanged("EventAIScripts");
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            textBoxId.Text = "";
            textBoxCreatureId.Text = "";
            ComboEventType.SelectedIndex = -1;
            textBoxInversePhaseMask.Text = "";
            textBoxEventChance.Text = "";
            textBoxEventParam1.Text = "";
            textBoxEventParam2.Text = "";
            textBoxEventParam3.Text = "";
            textBoxEventParam4.Text = "";
            textBoxEventParam5.Text = "";
            textBoxEventParam6.Text = "";
            checkBoxRepeatable.IsChecked = false;
            checkBoxDifficulty0.IsChecked = false;
            checkBoxDifficulty1.IsChecked = false;
            checkBoxDifficulty2.IsChecked = false;
            checkBoxDifficulty3.IsChecked = false;
            checkBoxRandomAction.IsChecked = false;
            checkBoxDebugOnly.IsChecked = false;
            checkBoxRangedModeOnly.IsChecked = false;
            checkBoxMeleeModeOnly.IsChecked = false;
            checkBoxCombatAction.IsChecked = false;
            ComboAction1Type.SelectedIndex = -1;
            textBoxAction1Param1.Text = "";
            textBoxAction1Param2.Text = "";
            textBoxAction1Param2.Text = "";
            ComboAction2Type.SelectedIndex = -1;
            textBoxAction2Param1.Text = "";
            textBoxAction2Param2.Text = "";
            textBoxAction2Param2.Text = "";
            ComboAction2Type.SelectedIndex = -1;
            textBoxAction3Param1.Text = "";
            textBoxAction3Param2.Text = "";
            textBoxAction3Param2.Text = "";
            textBoxComment.Text = "";
        }

        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            EventAIScripts.Clear();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            var container = ((App)App.Current).Container;
            var mysql = (Mysql)container.GetService(typeof(Mysql));
            EventAIScripts.Clear();
            uint creatureId = uint.TryParse(textBoxCreatureId.Text, out uint u) ? u : 0;
            foreach (var script in mysql.EventAIScripts.Where(p => p.Creature_id == creatureId).ToList())
            {
                EventAIScripts.Add(script);
            }
        }
    }
}
