using Data.Db;
using Microsoft.UI;
using Microsoft.UI.Dispatching;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel.DataTransfer;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Helpers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Converter : Page
    {
        public ObservableCollection<string> SniffConverterBinding { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> TCToCmangosConverterBinding { get; set; } = new ObservableCollection<string>();

        private Timer timer;

        public Converter()
        {
            this.InitializeComponent();

            SniffConverterBinding.Add("waypoint_path");
            SniffConverterBinding.Add("creature_movement");
            SniffConverterBinding.Add("creature_movement_template");

            TCToCmangosConverterBinding.Add("creature");
            TCToCmangosConverterBinding.Add("gameobject");
            TCToCmangosConverterBinding.Add("waypoint");

            sniffConverterComboBox.SelectedIndex = 0;

            timer = null;
        }

        private async void timerCallback(object state)
        {
            // do some work not connected with UI
            ((App)App.Current).m_window.DispatcherQueue.TryEnqueue(new DispatcherQueueHandler(() =>
            {
                var redBrush = new SolidColorBrush();
                redBrush.Color = Colors.White;
                buttonConvertTcToCmangos.Foreground = redBrush;
            }));
        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = null;
            lines = textBoxWaypointSniff.Text.Split(new char[] { '\r' }); // why the fuck textbox in winui 3 uses \r line separator is beyond me
            int point = 1;

            string output = "";
            if (((string)sniffConverterComboBox.SelectedItem) == "creature_movement_template")
                output = "INSERT INTO `creature_movement_template` (`Entry`, `PathId`, `Point`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `WaitTime`, `ScriptId`) VALUES\n";
            else if (((string)sniffConverterComboBox.SelectedItem) == "waypoint_path")
                output = "INSERT INTO `waypoint_path` (`PathId`, `Point`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `WaitTime`, `ScriptId`) VALUES\n";
            else if (((string)sniffConverterComboBox.SelectedItem) == "creature_movement")
                output = "INSERT INTO `creature_movement` (`Id`, `Point`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `WaitTime`, `ScriptId`) VALUES\n";
            string secondParam = textBoxSecondParam.Text;
            if (secondParam == "")
                secondParam = "0";

            bool first = true;
            for (int i = 0; i < lines.Length; i++)
            {
                double x = 0;
                double y = 0;
                double z = 0;
                double o = 0;

                if (first)
                    first = false;
                else
                    output += ",\n";

                if (lines[i].Contains("X:"))
                {
                    string[] xLine = lines[i].Split('X');
                    string[] xCoord = xLine[1].Split(' ');
                    x = double.Parse(xCoord[1], CultureInfo.InvariantCulture.NumberFormat);
                }

                if (lines[i].Contains("Y:"))
                {
                    string[] yLine = lines[i].Split('Y');
                    string[] yCoord = yLine[1].Split(' ');
                    y = double.Parse(yCoord[1], CultureInfo.InvariantCulture.NumberFormat);
                }

                if (lines[i].Contains("Z:"))
                {
                    string[] zLine = lines[i].Split('Z');
                    string[] zCoord = zLine[1].Split(' ');
                    z = double.Parse(zCoord[1], CultureInfo.InvariantCulture.NumberFormat);
                }

                if (((string)sniffConverterComboBox.SelectedItem) == "creature_movement_template")
                    output += "(" + textBoxEntry.Text + "," + secondParam + "," + point + "," + x.ToString(CultureInfo.InvariantCulture) + "," + y.ToString(CultureInfo.InvariantCulture) + "," + z.ToString(CultureInfo.InvariantCulture) + ",100,0,0)";
                else
                    output += "(" + textBoxEntry.Text + "," + point + "," + x.ToString(CultureInfo.InvariantCulture) + "," + y.ToString(CultureInfo.InvariantCulture) + "," + z.ToString(CultureInfo.InvariantCulture) + ",100,0,0)";
                point++;
            }

            output += ";";

            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(output);
            Clipboard.SetContent(dataPackage);
        }

        private string CleanLine(string line)
        {
            var trimChars = new char[] { '(', ')', '\n', '\r', '\'' };
            foreach (var character in trimChars)
            {
                line = line.Replace(character.ToString(), String.Empty);
            }
            return line;
        }

        private void buttonConvertTcToCmangos_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = null;
            lines = textBoxTCToCmangos.Text.Split(new char[] { '\r' }); // why the fuck textbox in winui 3 uses \r line separator is beyond me
            if (((string)comboBoxTCToCmangos.SelectedItem) == "creature")
            {
                var creatures = new List<Creature>();
                foreach (var line in lines)
                {
                    var cleanedLine = CleanLine(line);
                    if (cleanedLine.Length == 0)
                        continue;

                    var split = cleanedLine.Split(',');
                    var creature = new Creature();
                    creature.Guid = int.Parse(split[0]);
                    creature.Id = int.Parse(split[1]);
                    creature.Map = int.Parse(split[2]);
                    creature.SpawnMask = int.Parse(split[5]);
                    creature.PhaseMask = int.Parse(split[6]);                    
                    creature.PositionX = float.Parse(split[9], CultureInfo.InvariantCulture);
                    creature.PositionY = float.Parse(split[10], CultureInfo.InvariantCulture);
                    creature.PositionZ = float.Parse(split[11], CultureInfo.InvariantCulture);
                    creature.Orientation = float.Parse(split[12], CultureInfo.InvariantCulture);
                    creature.SpawnTimeSecsMin = int.Parse(split[13]);
                    creature.SpawnTimeSecsMax = int.Parse(split[13]);
                    creature.SpawnDist = float.Parse(split[14], CultureInfo.InvariantCulture);
                    creature.MovementType = int.Parse(split[18]);
                    creatures.Add(creature);
                }

                bool isPhaseMask = checkBoxParameter.IsChecked.Value;
                string output = "INSERT INTO creature(guid, id, map, spawnMask" + (isPhaseMask ? ", phaseMask" : "") + ", position_x, position_y, position_z, orientation, spawntimesecsmin, spawntimesecsmax, spawndist, MovementType) VALUES\n";
                bool first = true;
                foreach (var creature in creatures)
                {
                    if (first)
                        first = false;
                    else
                        output += ",\n";
                    output += creature.GenerateSQL(isPhaseMask);
                }

                output += ";";

                DataPackage dataPackage = new DataPackage();
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
                dataPackage.SetText(output);
                Clipboard.SetContent(dataPackage);
            }
            else if (((string)comboBoxTCToCmangos.SelectedItem) == "gameobject")
            {
                var gameObjects = new List<GameObject>();
                foreach (var line in lines)
                {
                    var cleanedLine = CleanLine(line);
                    if (cleanedLine.Length == 0)
                        continue;

                    var split = cleanedLine.Split(',');
                    var gameObject = new GameObject();
                    gameObject.Guid = int.Parse(split[0]);
                    gameObject.Id = int.Parse(split[1]);
                    gameObject.Map = int.Parse(split[2]);
                    gameObject.SpawnMask = int.Parse(split[5]);
                    gameObject.PhaseMask = int.Parse(split[6]);
                    gameObject.PositionX = float.Parse(split[7], CultureInfo.InvariantCulture);
                    gameObject.PositionY = float.Parse(split[8], CultureInfo.InvariantCulture);
                    gameObject.PositionZ = float.Parse(split[9], CultureInfo.InvariantCulture);
                    gameObject.Orientation = float.Parse(split[10], CultureInfo.InvariantCulture);
                    gameObject.Rotation0 = float.Parse(split[11], CultureInfo.InvariantCulture);
                    gameObject.Rotation1 = float.Parse(split[12], CultureInfo.InvariantCulture);
                    gameObject.Rotation2 = float.Parse(split[13], CultureInfo.InvariantCulture);
                    gameObject.Rotation3 = float.Parse(split[14], CultureInfo.InvariantCulture);
                    gameObject.SpawnTimeSecsMin = int.Parse(split[15]);
                    gameObject.SpawnTimeSecsMax = int.Parse(split[15]);
                    gameObject.AnimProgress = int.Parse(split[16]);
                    gameObject.State = int.Parse(split[17]);
                    gameObjects.Add(gameObject);
                }

                bool isPhaseMask = checkBoxParameter.IsChecked.Value;
                string output = "INSERT INTO gameobject(guid, id, map, spawnMask" + (isPhaseMask ? ", phaseMask" : "") + ", position_x, position_y, position_z, orientation, rotation0, rotation1, rotation2, rotation3, spawntimesecsmin, spawntimesecsmax, animprogress, state) VALUES\n";
                bool first = true;
                foreach (var gameObject in gameObjects)
                {
                    if (first)
                        first = false;
                    else
                        output += ",\n";
                    output += gameObject.GenerateSQL(isPhaseMask);
                }

                output += ";";

                DataPackage dataPackage = new DataPackage();
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
                dataPackage.SetText(output);
                Clipboard.SetContent(dataPackage);
            }
            else if (((string)comboBoxTCToCmangos.SelectedItem) == "waypoint")
            {
                var waypointPath = new List<WaypointPath>();
                foreach (var line in lines)
                {
                    var cleanedLine = CleanLine(line);
                    if (cleanedLine.Length == 0)
                        continue;

                    var split = cleanedLine.Split(',');
                    var waypoints = new WaypointPath();
                    waypoints.PathId = int.Parse(split[0]);
                    waypoints.Point = int.Parse(split[1]);
                    waypoints.PositionX = float.Parse(split[2], CultureInfo.InvariantCulture);
                    waypoints.PositionY = float.Parse(split[3], CultureInfo.InvariantCulture);
                    waypoints.PositionZ = float.Parse(split[4], CultureInfo.InvariantCulture);
                    waypoints.Orientation = float.Parse(split[5], CultureInfo.InvariantCulture);
                    if (waypoints.Orientation == 0)
                        waypoints.Orientation = 100;
                    waypoints.WaitTime = int.Parse(split[6]);
                    waypoints.ScriptId = 0;
                    waypoints.Comment = split[7];
                    waypointPath.Add(waypoints);
                }

                string output = "INSERT INTO waypoint_path(PathId, Point, PositionX, PositionY, PositionZ, Orientation, WaitTime, ScriptId, Comment) VALUES\n";
                bool first = true;
                foreach (var waypoints in waypointPath)
                {
                    if (first)
                        first = false;
                    else
                        output += ",\n";
                    output += waypoints.GenerateSQL();
                }

                output += ";";

                DataPackage dataPackage = new DataPackage();
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
                dataPackage.SetText(output);
                Clipboard.SetContent(dataPackage);
            }

            var redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            buttonConvertTcToCmangos.Foreground = redBrush;
            timer = new Timer(timerCallback, null, (int)TimeSpan.FromMilliseconds(5000).TotalMilliseconds, Timeout.Infinite);
        }

        private void comboBoxTCToCmangos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) // deselected
                return;

            var table = (string)e.AddedItems[0];
            if (table == "creature" || table == "gameobject")
                checkBoxParameter.Content = "PhaseMask";
            else
                checkBoxParameter.Content = "";
        }
    }
}
