using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Media.Imaging;

namespace Redactor
{
    /// <summary>
    /// Логика взаимодействия для AddPack.xaml
    /// </summary>
    public partial class AddPack : Window
    {
        List<Question> Pack = new List<Question>();
        string path = "C:\\Users\\User\\source\\repos\\Redactor\\Redactor\\bin\\Debug";
        public AddPack()
        {
            InitializeComponent();
        }

        //________________________СОЗДАНИЕ НОВОГО ПАКА________________________________
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerA.Text == "" || AnswerB.Text == "" || AnswerC.Text == "" || AnswerD.Text == "" || Question.Text == "")
                MessageBox.Show("Заполните все поля, пожалуйста!");
            if (AnswerA.Text != "" & AnswerB.Text != "" & AnswerC.Text != "" & AnswerD.Text != "" & Question.Text != "")
            {
            AnswerA.Text = "";
            AnswerB.Text = "";
            AnswerC.Text = "";
            AnswerD.Text = "";
            Question.Text = "";
            string FileName = path + "\\" + PackName.Text + ".xml";
            Question elem = new Question(Question.Text, AnswerA.Text, AnswerB.Text, AnswerC.Text, AnswerD.Text);
            Pack.Add(elem);
                if (CurrentNumberLabel.Content.ToString() == "1")
                {
                    //FileStream fs = new FileStream("Players.xml", FileMode.OpenOrCreate);

                    //List<Question> CreatePack = new List<Question>();
                    //XmlSerializer formatter = new XmlSerializer(typeof(List<Question>));
                    //CreatePack = (List<Question>)formatter.Deserialize(fs);
                    //fs.Close();

                    //foreach (Question item in CreatePack)
                    //{
                    //    if (item.name == Name.Text)
                    //    {
                    //        item.name = Name.Text;
                    //        item.balance = Balance.Text;
                    //    }
                    //}
                    //File.WriteAllText("Players.xml", string.Empty);
                    //FileStream sf = new FileStream("Players.xml", FileMode.OpenOrCreate);
                    //formatter.Serialize(sf, swap);
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Question>));
                    //string SaveName = PackName.Text + ".xml";
                    //File.Create(SaveName);
                    FileStream sf = new FileStream("Question.xml", FileMode.OpenOrCreate);
                    formatter.Serialize(sf, Pack);
                    sf.Close();
                    if (File.Exists(@"C:\Users\User\source\repos\Redactor\Redactor\bin\Debug\Question.xml"))
                    {
                        File.Move(@"C:\Users\User\source\repos\Redactor\Redactor\bin\Debug\Question.xml", FileName);
                        File.Delete(@"C:\Users\User\source\repos\Redactor\Redactor\bin\Debug\Question.xml");
                    }
                    CompleteAddPackLabel.Visibility = Visibility.Visible;
                    ReturnInMenuFromAddPack.Visibility = Visibility.Visible;
                    Second.Visibility = Visibility.Hidden;
                    CurrentNumberLabel.Visibility = Visibility.Hidden;
                    SeparatorLabel.Visibility = Visibility.Hidden;
                    MaxNumberLabel.Visibility = Visibility.Hidden;
                    Question.Visibility = Visibility.Hidden;
                    AddQuestion.Visibility = Visibility.Hidden;

                    AnswerA.Visibility = Visibility.Hidden;
                    AnswerB.Visibility = Visibility.Hidden;
                    AnswerC.Visibility = Visibility.Hidden;
                    AnswerD.Visibility = Visibility.Hidden;
                    WriteQuestionLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (AnswerA.Text != "" & AnswerB.Text != "" & AnswerC.Text != "" & AnswerD.Text != "" & Question.Text != "")
                {
                    int current = Convert.ToInt32(CurrentNumberLabel.Content);
                    current++;
                    CurrentNumberLabel.Content = current.ToString();
                }
            }
        }

        private void StartCreate_Click(object sender, RoutedEventArgs e)
        {
            if (PackName.Text == "")
                MessageBox.Show("Заполните поле, пожалуйста!");
            if (PackName.Text != "")
            { StartCreate.Visibility = Visibility.Hidden;
                PackName.Visibility = Visibility.Hidden;
                Second.Visibility = Visibility.Visible;
                First.Visibility = Visibility.Hidden;
                CurrentNumberLabel.Visibility = Visibility.Visible;
                SeparatorLabel.Visibility = Visibility.Visible;
                MaxNumberLabel.Visibility = Visibility.Hidden;
                Question.Visibility = Visibility.Visible;
                AddQuestion.Visibility = Visibility.Visible;

                AnswerA.Visibility = Visibility.Visible;
                AnswerB.Visibility = Visibility.Visible;
                AnswerC.Visibility = Visibility.Visible;
                AnswerD.Visibility = Visibility.Visible;
                WriteQuestionLabel.Visibility = Visibility.Visible;
            }
        }

        private void ReturnInMenuFromAddPack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
