using System;
using System.Collections.Generic;
using System.Windows;


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
        public int _currentQuestionNumber = 0;
        private readonly bool _isLoaded = false;
        Checker checker = new Checker();
        bool flag = false;

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
                MessageBox.Show("Набор вопросов успешно создан");
                this.Close();
                MainWindow window = new MainWindow();
                window.Show();
                return;
            }
            if (_isLoaded)
            {
                if (flag == false)
                {
                    SelectQueastionGBox.Visibility = Visibility.Visible;
                    SelectQuestionLabel.Visibility = Visibility.Visible;
                    SelectQuestionTBox.Visibility = Visibility.Visible;
                }
                LoadQuestionFromPack();               
            }
        }

        public bool CheckIfLastQuestion()
        {
            return _currentQuestionNumber >= (int)Constants.MaxQuestionNumber;
        }

        private void LoadQuestionFromPack()
        {
            try
            {
                if (SelectQuestionTBox.Text != string.Empty)
                {
                    if ((Convert.ToInt32(SelectQuestionTBox.Text) - 1) < _pack.Questions.Count && Convert.ToInt32(SelectQuestionTBox.Text) > 0)
                    {
                        Question currentQuestion = _pack.Questions[Convert.ToInt32(SelectQuestionTBox.Text) - 1];

                        QuestionTextBox.Text = currentQuestion.GetQuestion();
                        ATextBox.Text = currentQuestion.GetAnswerByIndex(0);
                        BTextBox.Text = currentQuestion.GetAnswerByIndex(1);
                        CTextBox.Text = currentQuestion.GetAnswerByIndex(2);
                        DTextBox.Text = currentQuestion.GetAnswerByIndex(3);

                        CATextBox.Text = checker.RightAnswerForUser(ATextBox.Text, BTextBox.Text, CTextBox.Text, DTextBox.Text, currentQuestion.GetCorrectAnswer());
                        ReturnToSelectQuestion.Visibility = Visibility.Visible;
                        NumberOfQuestion.Text = SelectQuestionTBox.Text;
                        _currentQuestionNumber = Convert.ToInt32(NumberOfQuestion.Text) - 1;
                        SelectQuestionTBox.Text = string.Empty;
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        MessageBox.Show("Такого вопроса не существует!");
                    }

                }
                else if (_currentQuestionNumber < _pack.Questions.Count && flag != false)
                {
                    ReturnToSelectQuestion.Visibility = Visibility.Visible;
                    Question currentQuestion = _pack.Questions[_currentQuestionNumber];

                    QuestionTextBox.Text = currentQuestion.GetQuestion();
                    ATextBox.Text = currentQuestion.GetAnswerByIndex(0);
                    BTextBox.Text = currentQuestion.GetAnswerByIndex(1);
                    CTextBox.Text = currentQuestion.GetAnswerByIndex(2);
                    DTextBox.Text = currentQuestion.GetAnswerByIndex(3);

                    CATextBox.Text = checker.RightAnswerForUser(ATextBox.Text, BTextBox.Text, CTextBox.Text, DTextBox.Text, currentQuestion.GetCorrectAnswer());
                }
            }
            catch(FormatException)
            {
                flag = false;
                MessageBox.Show("Введите число, а не букву, пожалуйста!");
            }
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            if (checker.CheckAllField(QuestionTextBox.Text, ATextBox.Text, BTextBox.Text, CTextBox.Text, DTextBox.Text, CATextBox.Text))
            {
                int current = Convert.ToInt32(NumberOfQuestion.Text);
                current++;
                Question question = new Question(QuestionTextBox.Text,
                        new List<Answer> { new Answer(ATextBox.Text), new Answer(BTextBox.Text), new Answer(CTextBox.Text), new Answer(DTextBox.Text) }, checker.RightAnswer(ATextBox.Text, BTextBox.Text, CTextBox.Text, DTextBox.Text, CATextBox.Text));
                if (_isLoaded && _currentQuestionNumber < _pack.Questions.Count)
                {
                    _pack.Questions[_currentQuestionNumber] = question;
                }
                else
                    _pack.Questions.Add(question);
                QuestionPackHandler.AutoSavePack(_pack);
                _currentQuestionNumber++;
                NumberOfQuestion.Text = current.ToString();
                NewQuestionSetUp();
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

        private void SelectQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadQuestionFromPack();
            if (flag == true)
            {
                SelectQueastionGBox.Visibility = Visibility.Hidden;
                SelectQuestionLabel.Visibility = Visibility.Hidden;
                SelectQuestionTBox.Visibility = Visibility.Hidden;
            
            }
            
        }

        private void ReturnToSelectQuestion_Click(object sender, RoutedEventArgs e)
        {
           
            SelectQueastionGBox.Visibility = Visibility.Visible;
            SelectQuestionLabel.Visibility = Visibility.Visible;
            SelectQuestionTBox.Visibility = Visibility.Visible;
            ReturnToSelectQuestion.Visibility = Visibility.Hidden;
        }

    }
}
