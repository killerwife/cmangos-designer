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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using WinRT.Interop;
using Data.Db;
using Microsoft.UI.Xaml.Shapes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.Extensions.Logging;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Helpers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OreHelper : Page
    {
        public OreHelper()
        {
            this.InitializeComponent();
            readFile();
        }

        private const string fileName = "oreHelperData.txt";

        private void saveFile()
        {
            string fileOutput = "";
            fileOutput += textBoxMapId.Text + "\n";
            fileOutput += textBoxEntries0.Text + ";" + textBoxNumber0.Text + "\n";
            fileOutput += textBoxEntries1.Text + ";" + textBoxNumber1.Text + "\n";
            fileOutput += textBoxEntries2.Text + ";" + textBoxNumber2.Text + "\n";
            fileOutput += textBoxEntries3.Text + ";" + textBoxNumber3.Text + "\n";
            fileOutput += textBoxEntries4.Text + ";" + textBoxNumber4.Text + "\n";
            fileOutput += textBoxEntries5.Text + ";" + textBoxNumber5.Text + "\n";
            fileOutput += textBoxEntries6.Text + ";" + textBoxNumber6.Text + "\n";
            fileOutput += textBoxEntries7.Text + ";" + textBoxNumber7.Text + "\n";
            fileOutput += textBoxEntries8.Text + ";" + textBoxNumber8.Text + "\n";
            fileOutput += textBoxEntries9.Text + ";" + textBoxNumber9.Text + "\n";
            fileOutput += textBoxEntries10.Text + ";" + textBoxNumber10.Text + "\n";
            fileOutput += textBoxEntries11.Text + ";" + textBoxNumber11.Text + "\n";
            fileOutput += textBoxEntries12.Text + ";" + textBoxNumber12.Text + "\n";
            fileOutput += textBoxEntries13.Text + ";" + textBoxNumber13.Text + "\n";
            fileOutput += textBoxEntries14.Text + ";" + textBoxNumber14.Text + "\n";
            fileOutput += textBoxEntries15.Text + ";" + textBoxNumber15.Text + "\n";
            fileOutput += textBoxEntries16.Text + ";" + textBoxNumber16.Text + "\n";
            fileOutput += textBoxEntries17.Text + ";" + textBoxNumber17.Text + "\n";
            fileOutput += textBoxEntries18.Text + ";" + textBoxNumber18.Text + "\n";
            fileOutput += textBoxEntries19.Text + ";" + textBoxNumber19.Text + "\n";
            fileOutput += textBoxEntries20.Text + ";" + textBoxNumber20.Text + "\n";
            File.WriteAllText(fileName, fileOutput);
        }

        private void readFile()
        {
            if (!File.Exists(fileName))
                return;

            string[] text = System.IO.File.ReadAllLines(fileName);
            textBoxMapId.Text = CleanLine(text[0]);
            checkArrayAndSet(text, 0, textBoxEntries0, textBoxNumber0);
            checkArrayAndSet(text, 1, textBoxEntries1, textBoxNumber1);
            checkArrayAndSet(text, 2, textBoxEntries2, textBoxNumber2);
            checkArrayAndSet(text, 3, textBoxEntries3, textBoxNumber3);
            checkArrayAndSet(text, 4, textBoxEntries4, textBoxNumber4);
            checkArrayAndSet(text, 5, textBoxEntries5, textBoxNumber5);
            checkArrayAndSet(text, 6, textBoxEntries6, textBoxNumber6);
            checkArrayAndSet(text, 7, textBoxEntries7, textBoxNumber7);
            checkArrayAndSet(text, 8, textBoxEntries8, textBoxNumber8);
            checkArrayAndSet(text, 9, textBoxEntries9, textBoxNumber9);
            checkArrayAndSet(text, 10, textBoxEntries10, textBoxNumber10);
            checkArrayAndSet(text, 11, textBoxEntries11, textBoxNumber11);
            checkArrayAndSet(text, 12, textBoxEntries12, textBoxNumber12);
            checkArrayAndSet(text, 13, textBoxEntries13, textBoxNumber13);
            checkArrayAndSet(text, 14, textBoxEntries14, textBoxNumber14);
            checkArrayAndSet(text, 15, textBoxEntries15, textBoxNumber15);
            checkArrayAndSet(text, 16, textBoxEntries16, textBoxNumber16);
            checkArrayAndSet(text, 17, textBoxEntries17, textBoxNumber17);
            checkArrayAndSet(text, 18, textBoxEntries18, textBoxNumber18);
            checkArrayAndSet(text, 19, textBoxEntries19, textBoxNumber19);
            checkArrayAndSet(text, 20, textBoxEntries20, textBoxNumber20);
        }

        private void splitLineAndSet(TextBox entries, TextBox number, string line)
        {
            string[] split = line.Split(';');
            entries.Text = split[0];
            number.Text = split[1];
        }

        private void checkArrayAndSet(string[] text, int index, TextBox entries, TextBox number)
        {
            index++;
            if (text.Count() > index)
                splitLineAndSet(entries, number, text[index]);
        }

        private async void buttonPickFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fileOpenPicker = new()
            {
                ViewMode = PickerViewMode.Thumbnail,
                FileTypeFilter = { ".sql" },
            };

            var window = (Microsoft.UI.Xaml.Application.Current as App)?.m_window as MainWindow;
            nint windowHandle = WindowNative.GetWindowHandle(window);
            InitializeWithWindow.Initialize(fileOpenPicker, windowHandle);

            StorageFile file = await fileOpenPicker.PickSingleFileAsync();

            if (file != null)
            {
                textBoxChosenFile.Text = file.Path;
                await ChangeColorIfHasData(buttonCopyToClipboard0, textBoxEntries0.Text, textBoxNumber0.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard1, textBoxEntries1.Text, textBoxNumber1.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard2, textBoxEntries2.Text, textBoxNumber2.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard3, textBoxEntries3.Text, textBoxNumber3.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard4, textBoxEntries4.Text, textBoxNumber4.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard5, textBoxEntries5.Text, textBoxNumber5.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard6, textBoxEntries6.Text, textBoxNumber6.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard7, textBoxEntries7.Text, textBoxNumber7.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard8, textBoxEntries8.Text, textBoxNumber8.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard9, textBoxEntries9.Text, textBoxNumber9.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard10, textBoxEntries10.Text, textBoxNumber10.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard11, textBoxEntries11.Text, textBoxNumber11.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard12, textBoxEntries12.Text, textBoxNumber12.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard13, textBoxEntries13.Text, textBoxNumber13.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard14, textBoxEntries14.Text, textBoxNumber14.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard15, textBoxEntries15.Text, textBoxNumber15.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard16, textBoxEntries16.Text, textBoxNumber16.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard17, textBoxEntries17.Text, textBoxNumber17.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard18, textBoxEntries18.Text, textBoxNumber18.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard19, textBoxEntries19.Text, textBoxNumber19.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard20, textBoxEntries20.Text, textBoxNumber20.Text);
            }
        }

        private async Task showWrongDataFilledDialog(string message)
        {
            ContentDialog dialog = new()
            {
                Title = "Warning",
                Content = message,
                PrimaryButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            var result = await dialog.ShowAsync();
        }

        private string CleanLine(string line)
        {
            var trimChars = new char[] { '(', ')', '\n', '\r', '\'' };
            foreach (var character in trimChars)
            {
                line = line.Replace(character.ToString(), string.Empty);
            }
            return line;
        }

        private async void buttonCopyToClipboard0_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries0.Text, textBoxNumber0.Text);
        }

        private async void buttonCopyToClipboard1_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries1.Text, textBoxNumber1.Text);
        }

        private async void buttonCopyToClipboard2_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries2.Text, textBoxNumber2.Text);
        }

        private async void buttonCopyToClipboard3_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries3.Text, textBoxNumber3.Text);
        }

        private async void buttonCopyToClipboard4_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries4.Text, textBoxNumber4.Text);
        }

        private async void buttonCopyToClipboard5_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries5.Text, textBoxNumber5.Text);
        }

        private async void buttonCopyToClipboard6_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries6.Text, textBoxNumber6.Text);
        }

        private async void buttonCopyToClipboard7_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries7.Text, textBoxNumber7.Text);
        }

        private async void buttonCopyToClipboard8_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries8.Text, textBoxNumber8.Text);
        }
        private async void buttonCopyToClipboard9_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries9.Text, textBoxNumber9.Text);
        }

        private async void buttonCopyToClipboard10_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries10.Text, textBoxNumber10.Text);
        }


        private async void buttonCopyToClipboard11_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries11.Text, textBoxNumber11.Text);
        }

        private async void buttonCopyToClipboard12_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries12.Text, textBoxNumber12.Text);
        }

        private async void buttonCopyToClipboard13_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries13.Text, textBoxNumber13.Text);
        }

        private async void buttonCopyToClipboard14_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries14.Text, textBoxNumber14.Text);
        }

        private async void buttonCopyToClipboard15_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries15.Text, textBoxNumber15.Text);
        }

        private async void buttonCopyToClipboard16_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries16.Text, textBoxNumber16.Text);
        }

        private async void buttonCopyToClipboard17_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries17.Text, textBoxNumber17.Text);
        }

        private async void buttonCopyToClipboard18_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries18.Text, textBoxNumber18.Text);
        }

        private async void buttonCopyToClipboard19_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries19.Text, textBoxNumber19.Text);
        }

        private async void buttonCopyToClipboard20_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries20.Text, textBoxNumber20.Text);
        }

        private async void processButtonClick(string entriesText, string indexText)
        {
            string output = await ProcessData(entriesText, indexText, true);

            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(output);
            Clipboard.SetContent(dataPackage);

            saveFile();
        }

        private async Task ChangeColorIfHasData(Button button, string entriesText, string indexText)
        {
            if (await HasData(entriesText, indexText))
                button.Background = new SolidColorBrush(Color.FromArgb(255, 79, 121, 66));
            else
                button.Background = new SolidColorBrush(Color.FromArgb(255, 136, 8, 8));
        }

        private async Task<bool> HasData(string entriesText, string indexText)
        {
            var output = await ProcessData(entriesText, indexText, false);
            if (output == null)
                return false;
            return output.Length > 2;
        }

        private async Task<string?> ProcessData(string entriesText, string indexText, bool errors)
        {
            string output = "";
            string[] lines = null;
            bool success;

            if (!System.IO.File.Exists(textBoxChosenFile.Text))
            {
                if (errors)
                    await showWrongDataFilledDialog("File does not exist");
                return null;
            }

            int mapId = 0;
            success = int.TryParse(textBoxMapId.Text, out mapId);
            if (!success)
            {
                if (errors)
                    await showWrongDataFilledDialog("Couldnt parse mapId");
                return null;
            }

            string text = System.IO.File.ReadAllText(textBoxChosenFile.Text);
            lines = text.Split(new char[] { '\n' });
            {
                List<int> entries = new();
                var entriesSplit = entriesText.Split(',');

                foreach (var entryText in entriesSplit)
                {
                    success = int.TryParse(entryText, out int entry);
                    if (!success)
                    {
                        if (errors)
                            await showWrongDataFilledDialog("Entries are wrongly formatted");
                        return null;
                    }
                    entries.Add(entry);
                }

                int startingIndex;
                success = int.TryParse(indexText, out startingIndex);
                if (!success)
                {
                    if (errors)
                        await showWrongDataFilledDialog("Could not parse starting index");
                    return null;
                }
                var gameObjects = new List<GameObjectParser>();
                foreach (var line in lines)
                {
                    var cleanedLine = CleanLine(line);
                    if (cleanedLine.Length == 0)
                        continue;

                    if (cleanedLine[0] == '-' && cleanedLine[1] == '-' && cleanedLine[2] == ' ')
                        continue;

                    if (cleanedLine[0] != '@')
                        continue;

                    var split = cleanedLine.Split(',');
                    var gameObject = new GameObjectParser();
                    gameObject.Guid = "@GGUID+" + startingIndex;
                    var id = int.Parse(split[1]);
                    gameObject.Id = entries.Count > 1 ? 0 : id;
                    if (!entries.Contains(id))
                        continue;
                    gameObject.Map = int.Parse(split[2]);
                    if (mapId != -1 && gameObject.Map != mapId)
                        continue;
                    gameObject.SpawnMask = int.Parse(split[5]);
                    gameObject.PositionX = split[6];
                    gameObject.PositionY = split[7];
                    gameObject.PositionZ = split[8];
                    gameObject.Orientation = split[9];
                    gameObject.Rotation0 = split[10];
                    gameObject.Rotation1 = split[11];
                    gameObject.Rotation2 = split[12];
                    gameObject.Rotation3 = split[13];
                    gameObject.SpawnTimeSecsMin = 600;
                    gameObject.SpawnTimeSecsMax = 600;
                    gameObjects.Add(gameObject);

                    ++startingIndex;
                }

                bool isPhaseMask = false;
                if (gameObjects.Count() > 0)
                {
                    if (checkBoxFirstLine.IsChecked == true)
                        output = "INSERT INTO gameobject(guid, id, map, spawnMask" + (isPhaseMask ? ", phaseMask" : "") + ", position_x, position_y, position_z, orientation, rotation0, rotation1, rotation2, rotation3, spawntimesecsmin, spawntimesecsmax) VALUES\n";
                    else
                        output = ",\n";
                }
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
            }

            return output;
        }
    }
}
