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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer.Designers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EAIDesigner : Page
    {
        private List<string> EventBinding { get; set; } = new List<string>();
        private List<string> ActionBinding { get; set; } = new List<string>();

        public EAIDesigner()
        {
            this.InitializeComponent();
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
    }
}
