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
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;

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

        public Converter()
        {
            this.InitializeComponent();

            SniffConverterBinding.Add("waypoint_path");
            SniffConverterBinding.Add("creature_movement");
            SniffConverterBinding.Add("creature_movement_template");

            sniffConverterComboBox.SelectedIndex = 0;
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
    }
}
