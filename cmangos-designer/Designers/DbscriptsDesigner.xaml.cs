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
    public sealed partial class DbscriptsDesigner : Page
    {
        private List<(string, int)> CommandsBinding { get; set; } = new List<(string, int)>();
        private List<DbscriptCommands> Commands { get; set; } = new List<DbscriptCommands>();

        // tooltips
        private string datalongTooltip { get; set; }

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

            Binding b = new Binding();
            b.Mode = BindingMode.OneWay;
            b.Source = datalongTooltip;
            ToolTip toolTip = new ToolTip();
            toolTip.Content = datalongTooltip;
            ToolTipService.SetToolTip(textBlockDatalong, toolTip);
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var commandData = ((string,int))e.AddedItems[0];

            var dbscriptCommand = Commands[commandData.Item2];

            textBlockDatalong.Text = dbscriptCommand.Datalong;
            datalongTooltip = dbscriptCommand.DatalongTooltip;
        }
    }
}
