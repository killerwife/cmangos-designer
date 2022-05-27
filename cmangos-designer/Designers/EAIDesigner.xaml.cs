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

        private EventAIScript? SelectedScript { get; set; } = null;
        private ObservableCollection<EventAIScript> EventAIScripts { get; set; } = new ObservableCollection<EventAIScript>();

        // tooltips
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ComboEventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboAction1Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboAction3Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboAction2Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checkBoxBuddies_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedScript = (EventAIScript)e.AddedItems[0];
            textBoxId.Text = SelectedScript.Id.ToString();
            textBoxCreatureId.Text = SelectedScript.Creature_id.ToString();
            ComboEventType.SelectedIndex = (int)SelectedScript.Event_type;
            textBoxInversePhaseMask.Text = SelectedScript.Event_inverse_phase_mask.ToString();
            textBoxEventChance.Text = SelectedScript.Event_chance.ToString();
            textBoxEventParam1.Text = SelectedScript.Event_param1.ToString();
            textBoxEventParam2.Text = SelectedScript.Event_param2.ToString();
            textBoxEventParam3.Text = SelectedScript.Event_param3.ToString();
            textBoxEventParam4.Text = SelectedScript.Event_param4.ToString();
            textBoxEventParam5.Text = SelectedScript.Event_param5.ToString();
            textBoxEventParam6.Text = SelectedScript.Event_param6.ToString();
            ComboAction1Type.SelectedIndex = (int)SelectedScript.Action1_type - 1;
            textBoxAction1Param1.Text = SelectedScript.Action1_param1.ToString();
            textBoxAction1Param2.Text = SelectedScript.Action1_param2.ToString();
            textBoxAction1Param2.Text = SelectedScript.Action1_param3.ToString();
            ComboAction2Type.SelectedIndex = (int)SelectedScript.Action2_type - 1;
            textBoxAction2Param1.Text = SelectedScript.Action2_param1.ToString();
            textBoxAction2Param2.Text = SelectedScript.Action2_param2.ToString();
            textBoxAction2Param2.Text = SelectedScript.Action2_param3.ToString();
            ComboAction2Type.SelectedIndex = (int)SelectedScript.Action3_type - 1;
            textBoxAction3Param1.Text = SelectedScript.Action3_param1.ToString();
            textBoxAction3Param2.Text = SelectedScript.Action3_param2.ToString();
            textBoxAction3Param2.Text = SelectedScript.Action3_param3.ToString();
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
                query += "(";
                query += script.Id + "," + script.Creature_id + "," + script.Event_type + "," + script.Event_inverse_phase_mask + "," + script.Event_chance + "," + script.Event_flags + ",";
                query += script.Event_param1 + "," + script.Event_param2 + "," + script.Event_param3 + "," + script.Event_param4 + "," + script.Event_param5 + ",";
                query += script.Event_param6 + "," + script.Action1_type + "," + script.Action1_param1 + "," + script.Action1_param2 + "," + script.Action1_param3 + ",";
                query += script.Action2_type + "," + script.Action2_param1 + "," + script.Action2_param2 + "," + script.Action2_param3 + ",";
                query += script.Action3_type + "," + script.Action3_param1 + "," + script.Action3_param2 + "," + script.Action3_param3 + ",'" + script.Comment + "'";
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
            script.Event_flags = uint.TryParse(textBoxId.Text, out u) ? u : 0;
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
