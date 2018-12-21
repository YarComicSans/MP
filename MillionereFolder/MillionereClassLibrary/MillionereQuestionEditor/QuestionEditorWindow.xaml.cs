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
using System.Windows.Shapes;

namespace MillionereQuestionEditor
{
    /// <summary>
    /// Interaction logic for QuestionEditorWindow.xaml
    /// </summary>

    enum Constants
    {
        MaxQuestionNumber = 15
    }

    public partial class QuestionEditorWindow : Window
    {
        private readonly QuestionPack _pack;
        private int _currentQuestionNumber = 0;
        private readonly bool _isLoaded = false;

        public QuestionEditorWindow(QuestionPack p = null, string n = "")
        {
            if (p != null)
            {
                _pack = p;
                _isLoaded = true;
            }
            else
                _pack = new QuestionPack(new List<Question>(),n);
            InitializeComponent();
            NewQuestionSetUp();
        }

        private void NewQuestionSetUp()
        {
            ClearBoxes();
            if (CheckIfLastQuestion())
            {
                QuestionPackHandler.SerializePack(_pack);
                this.Close();
                MainWindow window = new MainWindow();
                window.Show();
                return;
            }
            if(_isLoaded)
                LoadQuestionFromPack();
        }

        public bool CheckIfLastQuestion()
        {
            return _currentQuestionNumber >= (int)Constants.MaxQuestionNumber;
        }

        private void LoadQuestionFromPack()
        {
            Question currentQuestion = _pack.Questions[_currentQuestionNumber];

            QuestionTextBox.Text = currentQuestion.GetQuestion();
            ATextBox.Text = currentQuestion.GetAnswerByIndex(0);
            BTextBox.Text = currentQuestion.GetAnswerByIndex(1);
            CTextBox.Text = currentQuestion.GetAnswerByIndex(2);
            DTextBox.Text = currentQuestion.GetAnswerByIndex(3);

            CATextBox.Text = currentQuestion.GetCorrectAnswer();

            
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            //change to proper checks in a class
            if (QuestionTextBox.Text == "" || ATextBox.Text == "" || BTextBox.Text == "" || CATextBox.Text == "" || CTextBox.Text == "" || DTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля, пожалуйста!");
            }
            else if(ATextBox.Text == BTextBox.Text || ATextBox.Text == CTextBox.Text || ATextBox.Text == DTextBox.Text || BTextBox.Text==CTextBox.Text || BTextBox.Text==DTextBox.Text || CTextBox.Text==DTextBox.Text)
            {
                MessageBox.Show("Варианты ответов совпадают!");
            }
            else
            {
                if (QuestionTextBox.Text[0].ToString() == " " || ATextBox.Text[0].ToString() == " " || BTextBox.Text[0].ToString() == " " || CATextBox.Text[0].ToString() == " " || CTextBox.Text[0].ToString() == " " || DTextBox.Text[0].ToString() == " ")
                {
                    MessageBox.Show("Поле не должно начинаться с пробела!");
                }
                else if (CATextBox.Text != ATextBox.Text && CATextBox.Text != BTextBox.Text && CATextBox.Text != CTextBox.Text && CATextBox.Text != DTextBox.Text)
                {
                    MessageBox.Show("Правильный ответ не совпадает ни с одним из варинтов ответа!");
                }
                else
                {
                    int current = Convert.ToInt32(NumberOfQuestion.Text);
                    current++;
                    Question question = new Question(QuestionTextBox.Text,
                        new List<Answer> { new Answer(ATextBox.Text), new Answer(BTextBox.Text), new Answer(CTextBox.Text), new Answer(DTextBox.Text) }, CATextBox.Text);

                    if (_isLoaded)
                        _pack.Questions[_currentQuestionNumber] = question;
                    else
                        _pack.Questions.Add(question);
                    _currentQuestionNumber++;
                    NumberOfQuestion.Text = current.ToString();
                    NewQuestionSetUp();
                }
            }
        }

        private void ClearBoxes()
        {
            if (QuestionTextBox.Text != "" && ATextBox.Text != "" && BTextBox.Text != "" && CATextBox.Text != "" && CTextBox.Text != "" && DTextBox.Text != "")
            {
                QuestionTextBox.Text = string.Empty;
                ATextBox.Text = string.Empty;
                BTextBox.Text = string.Empty;
                CTextBox.Text = string.Empty;
                DTextBox.Text = string.Empty;
                CATextBox.Text = string.Empty;
            }
        }
    }
}
