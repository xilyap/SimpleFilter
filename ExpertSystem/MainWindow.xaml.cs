using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SimpleFilter
{
    public partial class MainWindow : Window
    {
        ResultWindow resultWindow;
        public MainWindow()
        {
            InitializeComponent();
            InitializeStackPanels();
            string query = Generate_Query();
            Console.WriteLine(query);
            resultWindow = new ResultWindow(query);
            resultWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resultWindow.mainWindow = this;
            resultWindow.Show();
        }

        private void InitializeStackPanels()
        {
            headers_stackPanel = new StackPanel[]
        {
            Usage,
            RamSize,
            HddType,
            HddSize,
            OS,
            VideocardType,
            BatteryLife,
            ScreenResolution,
            ScreenDiagonal,
            RamReplace,
            DisplayFrequency,
            DisplayType,
            DiskDrive,
            GSM,
            canReplaceHDD
        };
            headers = new string[]
        {
            "Usage",
            "RAM",
            "HDD Type",
            "HDD Size",
            "OS",
            "Videocard type",
            "Battery",
            "Screen Resolution",
            "Screen Diagonal",
            "CanReplaceRAM",
            "Screen Frequency",
            "Display Type",
            "Has Optic Drive",
            "Has GSM",
            "CanReplaceHDD",
        };
        }

        string[] headers;
        StackPanel[] headers_stackPanel;

        private string Generate_Query()
        {
            string query = "SELECT * FROM Notebooks ";
            string result = "";
            for (int i = 0; i < headers.Length; i++)
            {
                string subResult = Form_Usage_CheckBox(headers_stackPanel[i], headers[i]);
                if (!string.IsNullOrEmpty(subResult))
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = subResult;
                        continue;
                    }
                    result += " AND " + subResult;
                }
            }
            if (!string.IsNullOrEmpty(result))
            {
                query += "WHERE " + result;
                if (!string.IsNullOrEmpty(CPU.Text.ToString()))
                {
                    query += string.Format(" AND CPU LIKE '%{0}%'", CPU.Text.ToString());
                }
                if (!string.IsNullOrEmpty(Videocard.Text.ToString()))
                {
                    query += string.Format(" AND Videocard LIKE '%{0}%'", Videocard.Text.ToString());
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(CPU.Text.ToString()) && !string.IsNullOrEmpty(Videocard.Text.ToString()))
                {
                    query += string.Format(" WHERE CPU LIKE '%{0}%' AND Videocard LIKE '%{1}%'", CPU.Text.ToString(), Videocard.Text.ToString());
                }
                if (!string.IsNullOrEmpty(CPU.Text.ToString()))
                {
                    query += string.Format(" WHERE CPU LIKE '%{0}%'", CPU.Text.ToString());
                }
                if (!string.IsNullOrEmpty(Videocard.Text.ToString()))
                {
                    query += string.Format(" WHERE Videocard LIKE '%{0}%'", Videocard.Text.ToString());
                }
            }

            return query;
        }
        /// <summary>
        /// Обход всех чекбоксов для получения запроса к базе
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        private string Form_Usage_CheckBox(StackPanel panel, string header)
        {
            string result = "";
            foreach (var child in panel.Children.OfType<CheckBox>())
            {
                if (child.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = String.Format("\"{0}\" = \"{1}\"", header, child.Content.ToString());
                        continue;
                    }
                    result = String.Format("{0} OR \"{1}\" = \"{2}\"", result, header, child.Content.ToString());
                }

            }
            if (!string.IsNullOrEmpty(result))
            {
                result = String.Format("({0})", result);
            }
            return result;
        }

        /// <summary>
        /// Функционал для обработки Radiobutton
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        private string Form_Usage_RadioButton(StackPanel panel, string header)
        {
            string result = "";
            foreach (var child in panel.Children.OfType<RadioButton>())
            {
                if (child.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = String.Format("\"{0}\" = \"{1}\"", header, child.Content.ToString());
                        continue;
                    }
                    result = String.Format("{0} OR \"{1}\" = \"{2}\"", result, header, child.Content.ToString());
                }

            }
            if (!string.IsNullOrEmpty(result))
            {
                result = String.Format("({0})", result);
            }
            return result;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string result = Generate_Query();
            Console.WriteLine(result);
            resultWindow.UpdateWindow(result);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            resultWindow.Close();
        }

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            resultWindow.Close();
        }

        private void CPU_TextChanged(object sender, TextChangedEventArgs e)
        {
            string result = Generate_Query();
            Console.WriteLine(result);
            resultWindow.UpdateWindow(result);
        }

        private void Videocard_TextChanged(object sender, TextChangedEventArgs e)
        {
            string result = Generate_Query();
            Console.WriteLine(result);
            resultWindow.UpdateWindow(result);
        }
    }

}
