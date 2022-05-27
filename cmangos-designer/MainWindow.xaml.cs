using cmangos_designer.Designers;
using cmangos_designer.Helpers;
using Microsoft.UI.Xaml;

using System;
using System.Runtime.InteropServices;
using WinRT;
using Windows.ApplicationModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace cmangos_designer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private IntPtr m_windowHandle;
        public IntPtr WindowHandle { get { return m_windowHandle; } }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }

        public MainWindow()
        {
            this.InitializeComponent();
            if (Content is FrameworkElement rootElement) // designed it in dark theme - remove this if someone adds light theme design - also change App
                rootElement.RequestedTheme = ElementTheme.Dark;
            contentFrame.Navigate(typeof(EAIDesigner));

            var windowNative = this.As<IWindowNative>();
            m_windowHandle = windowNative.WindowHandle;
            SetWindowSize(m_windowHandle, 1300, 850);
        }

        private void SetWindowSize(IntPtr hwnd, int width, int height)
        {
            var dpi = PInvoke.User32.GetDpiForWindow(hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
                                        0, 0, width, height,
                                        PInvoke.User32.SetWindowPosFlags.SWP_NOMOVE);
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(About));
        }

        private void buttonWaypoints_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(About));
        }

        private void buttonDbscripts_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(DbscriptsDesigner));
        }

        private void buttonEventAI_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(EAIDesigner));
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(About));
        }

        private void buttonConverters_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Converter));
        }
    }
}
