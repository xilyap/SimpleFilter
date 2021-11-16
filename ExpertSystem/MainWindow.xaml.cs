using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpertSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Filter filter;
        DatabaseManager manager;
        List<Question> questions;
        int currentPos;
        const int OFFSET = 1;
        ResultWindow resultWindow;
        public MainWindow()
        {
            
            InitializeComponent();

            manager = new DatabaseManager("my.db");
            questions = manager.GetALLQuestions();
            filter = new Filter(questions.Count);
            currentPos = 3;
            //UpdateLayout(3);
            MakeQuestions("Пиво,Снеки,Водка,Чай");
            InitializeStackPanels();
            string result = Generate_Query();
            Console.WriteLine(result);
            resultWindow = new ResultWindow(result);
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

        public void MakeQuestions(string str)
        {
            string[] arr = str.Split(',');
            List<string> answers = new List<string>(arr);
            string finalStr = "";
            foreach (var item in answers)
            {
                finalStr += item + "\n";
            }
            Console.WriteLine(finalStr);
        }

        string[] headers;

        StackPanel[] headers_stackPanel;
        private string Generate_Query()
        {
            
            string query = "SELECT * FROM Notebooks_new_new ";
            string result = "";
            for(int i = 0; i < headers.Length; i++)
            {
                string subResult = Form_Usage_CheckBox(headers_stackPanel[i], headers[i]);
                if (!string.IsNullOrEmpty(subResult))
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = subResult;
                        continue;
                    }
                    result += " AND "+ subResult;
                }
            }
            if (!string.IsNullOrEmpty(result))
            {
                query += "WHERE "+result;
            }
            return query;
        }

        private string Form_Usage_CheckBox(StackPanel name, string header)
        {
            string result = "";
            foreach (var child in name.Children.OfType<CheckBox>())
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


        private string Form_Usage_RadioButton(StackPanel name, string header)
        {
            string result = "";
            foreach (var child in name.Children.OfType<RadioButton>())
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
        /*
private void UpdateLayout(int position)
{
QuestionLabel.Content = questions[position].Name;
HintLabel.Content = questions[position].LeftAnswer + " " + questions[position].RightAnswer;
HintLabel.Visibility = Visibility.Hidden;
InputBox.Clear();
}

private void UpdateLayout(Question question)
{
QuestionLabel.Content = question.Name;
HintLabel.Content = question.LeftAnswer + " " + question.RightAnswer;
HintLabel.Visibility = Visibility.Hidden;
InputBox.Clear();
}

private void Terminal(Filter filter)
{
ResultWindow window = new ResultWindow(filter);
window.Show();
this.Close();
}

private void Button_Click(object sender, RoutedEventArgs e)
{
InputCheck();
}

private void InputCheck()
{
string answer = InputBox.Text.ToLower().Trim();
if (answer.Equals(questions[currentPos].LeftAnswer.ToLower()))
{
filter.Answers[currentPos] = true;
if (questions[currentPos].LeftPath == -1)
{
Terminal(filter);
return;
}
UpdateLayout(questions[currentPos].LeftPath - OFFSET);
currentPos = questions[currentPos].LeftPath - OFFSET;
}
else if (answer.Equals(questions[currentPos].RightAnswer.ToLower()))
{
filter.Answers[currentPos] = false;
if (questions[currentPos].RightPath == -1)
{
Terminal(filter);
return;
}
UpdateLayout(questions[currentPos].RightPath - OFFSET);
currentPos = questions[currentPos].RightPath - OFFSET;
}
else
{
HintLabel.Visibility = Visibility.Visible;
}
}

private void InputBox_KeyDown(object sender, KeyEventArgs e)
{
if (e.Key == Key.Return)
{
InputCheck();
}
}
*/
    }

}
