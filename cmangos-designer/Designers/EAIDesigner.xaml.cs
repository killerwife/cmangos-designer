using Data.Db;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
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

        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
