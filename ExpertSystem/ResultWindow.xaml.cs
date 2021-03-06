using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace SimpleFilter
{
    public partial class ResultWindow : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        List<Notebook> notebooks;
        public MainWindow mainWindow;


        private void ResultWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        public ResultWindow(string query)
        {
            InitializeComponent();
            UpdateWindow(query);
            Loaded += ResultWindow_Loaded;
        }

        public void UpdateWindow(string query)
        {
            DatabaseManager manager = new DatabaseManager("my.db");
            notebooks = manager.GetALLNotebooks(query);
            Populate(notebooks);
        }

        public void Populate(List<Notebook> list)
        {
            myListView.ItemsSource = list;
            myListView.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myListView.SelectedIndex != -1 && !string.IsNullOrEmpty(notebooks[myListView.SelectedIndex].URL))
            {
                System.Diagnostics.Process.Start(notebooks[myListView.SelectedIndex].URL);
            }

        }

        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void Window_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }
    }
}
