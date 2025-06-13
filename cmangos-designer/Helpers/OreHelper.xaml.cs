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
using Repository;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Data.Model.World;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Helpers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OreHelper : Page
    {
        private List<string> ProfilesBinding { get; set; } = new List<string>();
        private string SelectedProfile { get; set; }

        private WorldDbContext _dbContext;

        private List<TextBox> _textEntries = new();
        private List<TextBox> _textNumbers = new();

        public OreHelper()
        {
            this.InitializeComponent();

            var container = ((App)App.Current).Container;
            _dbContext = (WorldDbContext)container.GetService(typeof(WorldDbContext));

            SelectedProfile = "1"; // TODO: Save

            ProfilesBinding.Add("1");
            ProfilesBinding.Add("2");
            ProfilesBinding.Add("3");
            ProfilesBinding.Add("4");
            ProfilesBinding.Add("5");

            _textEntries.Add(textBoxEntries0);
            _textEntries.Add(textBoxEntries1);
            _textEntries.Add(textBoxEntries2);
            _textEntries.Add(textBoxEntries3);
            _textEntries.Add(textBoxEntries4);
            _textEntries.Add(textBoxEntries5);
            _textEntries.Add(textBoxEntries6);
            _textEntries.Add(textBoxEntries7);
            _textEntries.Add(textBoxEntries8);
            _textEntries.Add(textBoxEntries9);
            _textEntries.Add(textBoxEntries10);
            _textEntries.Add(textBoxEntries11);
            _textEntries.Add(textBoxEntries12);
            _textEntries.Add(textBoxEntries13);
            _textEntries.Add(textBoxEntries14);
            _textEntries.Add(textBoxEntries15);
            _textEntries.Add(textBoxEntries16);
            _textEntries.Add(textBoxEntries17);
            _textEntries.Add(textBoxEntries18);
            _textEntries.Add(textBoxEntries19);
            _textEntries.Add(textBoxEntries20);
            _textEntries.Add(textBoxEntries21);
            _textEntries.Add(textBoxEntries22);
            _textEntries.Add(textBoxEntries23);
            _textEntries.Add(textBoxEntries24);
            _textEntries.Add(textBoxEntries25);
            _textEntries.Add(textBoxEntries26);
            _textEntries.Add(textBoxEntries27);

            _textNumbers.Add(textBoxNumber0);
            _textNumbers.Add(textBoxNumber1);
            _textNumbers.Add(textBoxNumber2);
            _textNumbers.Add(textBoxNumber3);
            _textNumbers.Add(textBoxNumber4);
            _textNumbers.Add(textBoxNumber5);
            _textNumbers.Add(textBoxNumber6);
            _textNumbers.Add(textBoxNumber7);
            _textNumbers.Add(textBoxNumber8);
            _textNumbers.Add(textBoxNumber9);
            _textNumbers.Add(textBoxNumber10);
            _textNumbers.Add(textBoxNumber11);
            _textNumbers.Add(textBoxNumber12);
            _textNumbers.Add(textBoxNumber13);
            _textNumbers.Add(textBoxNumber14);
            _textNumbers.Add(textBoxNumber15);
            _textNumbers.Add(textBoxNumber16);
            _textNumbers.Add(textBoxNumber17);
            _textNumbers.Add(textBoxNumber18);
            _textNumbers.Add(textBoxNumber19);
            _textNumbers.Add(textBoxNumber20);
            _textNumbers.Add(textBoxNumber21);
            _textNumbers.Add(textBoxNumber22);
            _textNumbers.Add(textBoxNumber23);
            _textNumbers.Add(textBoxNumber24);
            _textNumbers.Add(textBoxNumber25);
            _textNumbers.Add(textBoxNumber26);
            _textNumbers.Add(textBoxNumber27);

            readFile();
        }

        private const string fileName = "oreHelperData";

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
            fileOutput += textBoxEntries21.Text + ";" + textBoxNumber21.Text + "\n";
            fileOutput += textBoxEntries22.Text + ";" + textBoxNumber22.Text + "\n";
            fileOutput += textBoxEntries23.Text + ";" + textBoxNumber23.Text + "\n";
            fileOutput += textBoxEntries24.Text + ";" + textBoxNumber24.Text + "\n";
            fileOutput += textBoxEntries25.Text + ";" + textBoxNumber25.Text + "\n";
            fileOutput += textBoxEntries26.Text + ";" + textBoxNumber26.Text + "\n";
            fileOutput += textBoxEntries27.Text + ";" + textBoxNumber27.Text + "\n";
            File.WriteAllText(fileName + SelectedProfile + ".txt", fileOutput);
        }

        private void readFile()
        {
            if (!File.Exists(fileName + SelectedProfile + ".txt"))
            {
                foreach (var box in _textEntries)
                    box.Text = "";
                foreach (var box in _textNumbers)
                    box.Text = "";
                return;
            }

            string[] text = System.IO.File.ReadAllLines(fileName + SelectedProfile + ".txt");
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
            checkArrayAndSet(text, 21, textBoxEntries21, textBoxNumber21);
            checkArrayAndSet(text, 22, textBoxEntries22, textBoxNumber22);
            checkArrayAndSet(text, 23, textBoxEntries23, textBoxNumber23);
            checkArrayAndSet(text, 24, textBoxEntries24, textBoxNumber24);
            checkArrayAndSet(text, 25, textBoxEntries25, textBoxNumber25);
            checkArrayAndSet(text, 26, textBoxEntries26, textBoxNumber26);
            checkArrayAndSet(text, 27, textBoxEntries27, textBoxNumber27);
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
                await ChangeColorIfHasData(buttonCopyToClipboard21, textBoxEntries21.Text, textBoxNumber21.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard22, textBoxEntries22.Text, textBoxNumber22.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard23, textBoxEntries23.Text, textBoxNumber23.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard24, textBoxEntries24.Text, textBoxNumber24.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard25, textBoxEntries25.Text, textBoxNumber25.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard26, textBoxEntries26.Text, textBoxNumber26.Text);
                await ChangeColorIfHasData(buttonCopyToClipboard27, textBoxEntries27.Text, textBoxNumber27.Text);

                await ReadFileIfExistsAndUpdateIndices(textBoxChosenFileSql.Text);
            }
        }

        private async void buttonPickFileForSql_Click(object sender, RoutedEventArgs e)
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
                textBoxChosenFileSql.Text = file.Path;
                await ReadFileIfExistsAndUpdateIndices(textBoxChosenFileSql.Text);
            }
        }

        private async Task ReadFileIfExistsAndUpdateIndices(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            string[] text = System.IO.File.ReadAllLines(path);

            await ChangeIndexIfHasData(buttonCopyToClipboard0, textBoxEntries0.Text, textBoxNumber0, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard1, textBoxEntries1.Text, textBoxNumber1, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard2, textBoxEntries2.Text, textBoxNumber2, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard3, textBoxEntries3.Text, textBoxNumber3, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard4, textBoxEntries4.Text, textBoxNumber4, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard5, textBoxEntries5.Text, textBoxNumber5, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard6, textBoxEntries6.Text, textBoxNumber6, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard7, textBoxEntries7.Text, textBoxNumber7, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard8, textBoxEntries8.Text, textBoxNumber8, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard9, textBoxEntries9.Text, textBoxNumber9, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard10, textBoxEntries10.Text, textBoxNumber10, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard11, textBoxEntries11.Text, textBoxNumber11, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard12, textBoxEntries12.Text, textBoxNumber12, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard13, textBoxEntries13.Text, textBoxNumber13, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard14, textBoxEntries14.Text, textBoxNumber14, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard15, textBoxEntries15.Text, textBoxNumber15, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard16, textBoxEntries16.Text, textBoxNumber16, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard17, textBoxEntries17.Text, textBoxNumber17, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard18, textBoxEntries18.Text, textBoxNumber18, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard19, textBoxEntries19.Text, textBoxNumber19, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard20, textBoxEntries20.Text, textBoxNumber20, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard21, textBoxEntries21.Text, textBoxNumber21, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard22, textBoxEntries22.Text, textBoxNumber22, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard23, textBoxEntries23.Text, textBoxNumber23, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard24, textBoxEntries24.Text, textBoxNumber24, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard25, textBoxEntries25.Text, textBoxNumber25, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard26, textBoxEntries26.Text, textBoxNumber26, text);
            await ChangeIndexIfHasData(buttonCopyToClipboard27, textBoxEntries27.Text, textBoxNumber27, text);
        }

        private async Task ChangeIndexIfHasData(Button button, string entriesText, TextBox indexBox, string[] text)
        {
            var entriesSplit = entriesText.Split(',');
            int newIndex = -1;
            foreach (var line in text)
            {
                var split = line.Split(',');
                if (split.Length < 2)
                    continue;
                if (entriesSplit.Contains(split[1]))
                {
                    var firstIndex = split[0];
                    firstIndex = firstIndex.Replace("(@GGUID+", "");
                    var result = int.TryParse(firstIndex, out int curNum);
                    if (result && newIndex < curNum)
                        newIndex = curNum;
                }
            }
            if (newIndex != -1)
                indexBox.Text = (newIndex + 1).ToString();
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
            processButtonClick(textBoxEntries0.Text, textBoxNumber0.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard1_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries1.Text, textBoxNumber1.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard2_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries2.Text, textBoxNumber2.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard3_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries3.Text, textBoxNumber3.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard4_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries4.Text, textBoxNumber4.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard5_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries5.Text, textBoxNumber5.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard6_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries6.Text, textBoxNumber6.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard7_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries7.Text, textBoxNumber7.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard8_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries8.Text, textBoxNumber8.Text, (Button)sender);
        }
        private async void buttonCopyToClipboard9_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries9.Text, textBoxNumber9.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard10_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries10.Text, textBoxNumber10.Text, (Button)sender);
        }


        private async void buttonCopyToClipboard11_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries11.Text, textBoxNumber11.Text, (Button) sender);
        }

        private async void buttonCopyToClipboard12_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries12.Text, textBoxNumber12.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard13_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries13.Text, textBoxNumber13.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard14_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries14.Text, textBoxNumber14.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard15_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries15.Text, textBoxNumber15.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard16_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries16.Text, textBoxNumber16.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard17_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries17.Text, textBoxNumber17.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard18_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries18.Text, textBoxNumber18.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard19_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries19.Text, textBoxNumber19.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard20_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries20.Text, textBoxNumber20.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard21_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries21.Text, textBoxNumber21.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard22_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries22.Text, textBoxNumber22.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard23_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries23.Text, textBoxNumber23.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard24_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries24.Text, textBoxNumber24.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard25_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries25.Text, textBoxNumber25.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard26_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries26.Text, textBoxNumber26.Text, (Button)sender);
        }

        private async void buttonCopyToClipboard27_Click(object sender, RoutedEventArgs e)
        {
            processButtonClick(textBoxEntries27.Text, textBoxNumber27.Text, (Button)sender);
        }

        private async void processButtonClick(string entriesText, string indexText, Button button)
        {
            saveFile();

            string output = await ProcessData(entriesText, indexText, true);

            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(output);
            Clipboard.SetContent(dataPackage);

            if (button.Background is SolidColorBrush)
            {
                SolidColorBrush color = (SolidColorBrush)button.Background;
                if (color.Color.B == 66)
                    button.Background = new SolidColorBrush(Color.FromArgb(255, 100, 200, 66));
                else
                    button.Background = new SolidColorBrush(Color.FromArgb(255, 200, 80, 20));
            }
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

            List<uint> mapId = new List<uint>();
            var mapsplit = textBoxMapId.Text.Split(',');
            foreach (var segment in mapsplit)
            {
                success = uint.TryParse(segment, out uint map);
                if (!success)
                {
                    if (errors)
                        await showWrongDataFilledDialog("Couldnt parse mapId");
                    return null;
                }
                mapId.Add(map);
            }

            double precision = 0.000002d; // warning - some zones shifted by 0.2 in some cases between later expansions

            var allGos = _dbContext.GameObjects.Where(p => mapId.Contains(p.map)).ToList();

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
                    {
                        cleanedLine = cleanedLine.Substring(3);
                    }

                    if (cleanedLine[0] != '@')
                        continue;

                    var split = cleanedLine.Split(',');
                    var gameObject = new GameObjectParser();
                    gameObject.Guid = "@GGUID+" + startingIndex;
                    var id = int.Parse(split[1]);
                    gameObject.Id = id;
                    if (!entries.Contains(id))
                        continue;
                    gameObject.Map = uint.Parse(split[2]);
                    if (!mapId.Contains(gameObject.Map))
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

                    var posXDec = double.Parse(gameObject.PositionX, CultureInfo.InvariantCulture);
                    var posYDec = double.Parse(gameObject.PositionY, CultureInfo.InvariantCulture);
                    var posZDec = double.Parse(gameObject.PositionZ, CultureInfo.InvariantCulture);
                    var parsedOri = double.Parse(gameObject.Orientation, CultureInfo.InvariantCulture);
                    var oriDec = PositionHelpers.DeNormalizeOrientation(parsedOri);
                    var normalOri = PositionHelpers.NormalizeOrientation(parsedOri);
                    var rot0Dec = double.Parse(gameObject.Rotation0, CultureInfo.InvariantCulture);
                    var rot1Dec = double.Parse(gameObject.Rotation1, CultureInfo.InvariantCulture);
                    var rot2Dec = double.Parse(gameObject.Rotation2, CultureInfo.InvariantCulture);
                    var rot3Dec = double.Parse(gameObject.Rotation3, CultureInfo.InvariantCulture);

                    var result = allGos.Any(p => (p.id == 0 || p.id == gameObject.Id) && p.map == gameObject.Map
                        && Math.Abs((double)p.position_x - posXDec) < precision
                        && Math.Abs((double)p.position_y - posYDec) < precision
                        && Math.Abs((double)p.position_z - posZDec) < precision
                        && (Math.Abs((double)p.orientation - oriDec) < precision || Math.Abs((double)p.orientation - normalOri) < precision)
                        && Math.Abs((double)p.rotation0 - rot0Dec) < precision
                        && Math.Abs((double)p.rotation1 - rot1Dec) < precision
                        && (Math.Abs((double)p.rotation2 - rot2Dec) < precision || Math.Abs((double)p.rotation2 - (-rot2Dec)) < precision)
                        && (Math.Abs((double)p.rotation3 - rot3Dec) < precision || Math.Abs((double)p.rotation3 - (-rot3Dec)) < precision)
                        );

                    if (result == true)
                        continue;

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

        private void ProfileComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProfile = (string)e.AddedItems[0];
            readFile();
        }
    }
}
