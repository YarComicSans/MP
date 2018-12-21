using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using MillionereClassLibrary;
using MillionereClassLibrary.Hints;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>

    public partial class GameWindow : Window
    {
        private Game _game;
        private readonly List<string> _scores = GetScoresList();
        public GameWindow(Game g)
        {
            _game = g;
            InitializeComponent();
            StartNewRound(_game.CurrentRound == null);
        }
        
        private static List<string> GetScoresList()
        {
            return new List<string>
            {
                "500",
                "1 000",
                "2 000",
                "3 000",
                "5 000",
                "10 000",
                "15 000",
                "25 000",
                "50 000",
                "100 000",
                "200 000",
                "400 000",
                "800 000",
                "1 500 000",
                "3 000 000"
            };
        }

        private void DisplayScore(int currentPositionInScoreboard)
        {
            var scoresList = GetScoresList();
            ScoreRichTextBox.Document.Blocks.Clear();
            for (int i = 0; i < scoresList.Count; i++)
            {
                if (i == currentPositionInScoreboard)
                {
                    TextRange tr = new TextRange(ScoreRichTextBox.Document.ContentEnd,
                        ScoreRichTextBox.Document.ContentEnd);
                    tr.Text = scoresList[i] + "\n";
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DarkOrange);
                }
                else
                {
                    ScoreRichTextBox.AppendText(scoresList[i] + '\n');
                }

            }
        }

        private void StartNewRound(bool isNewRound = false)
        {
            if (isNewRound)
            {
                _game.CurrentRound = new Round(_game.CurrentPlayer,
                    _game.GetQuestionStructure(_game.CurrentScorePosition));
                SaveProgress();
            }

        SetGUI();
        }

        private void SetGUI()
        {
            var question = _game.CurrentRound.GetQuestion();
            var answersList = _game.CurrentRound.GetAnswers();
            var availableHintsList = _game.CurrentRound.GetAvalibaleHints();

            QuestionLabel.Content = question;

            var answerButtonList = CreateButtonList();
            for (int i = 0; i < answerButtonList.Count; i++)
            {
                answerButtonList[i].Visibility = Visibility.Visible;
                answerButtonList[i].Content = answersList[i];
                answerButtonList[i].Background = Brushes.White;
            }

            foreach (var hint in availableHintsList)
            {
                switch (hint)
                {
                    case FiftyHint _:
                        {
                            FiftyFiftyHintButton.Visibility = Visibility.Visible;
                            continue;
                        }
                    case CallFriendHint _:
                        {
                            CallHintButton.Visibility = Visibility.Visible;
                            continue;
                        }
                    case AudienceHelpHint _:
                        AudienceHelpButton.Visibility = Visibility.Hidden;
                        continue;
                }
            }

            if (_game.CurrentRound.UsedHints.FiftyFiftyPositions.Count != 0)
                RemoveFiftyFiftyHint();
            if (_game.CurrentRound.UsedHints.CallFriendPosition != -1)
                RemoveCallHint();

            HosterImage.Source = new BitmapImage(new Uri( _game._hoster.PathToIcon));

            DisplayScore(_game.CurrentScorePosition);

        }

        private List<Button> CreateButtonList()
        {
            return new List<Button> {FirstAnswerButton , SecondAnswerButton, ThirdAnswerButton, FourthAnswerButton};
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            var isFinalAnswer = ConfirmAnswer("Is this your final decision?");
            if (isFinalAnswer)
            {
                _game.GameIsWon = true;
                EndGame(_game.GameIsWon);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveProgress();
        }

        private void FirstAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            FirstAnswerButton.Background = Brushes.Yellow;
            var isFinalAnswer = ConfirmAnswer("Is this your final answer?");
            if (isFinalAnswer)
            {
                EndRound(ref FirstAnswerButton);
            }
            else
                FirstAnswerButton.Background = Brushes.White;
        }

        private bool ConfirmAnswer(string line)
        {
            ConfirmationScreen scr = new ConfirmationScreen(line);
            scr.ShowDialog();
            return scr.IsFinalAnswer;
        }

        private void EndRound(ref Button clickedButton)
        {
            var isCorrectAnswer = _game.CurrentRound.CheckAnswer(clickedButton.Content.ToString());
            SetButtonsColorAfterAnswer(clickedButton, isCorrectAnswer);
            CalculateRoundResults(isCorrectAnswer);
            SaveProgress();
            StartNewRound(true);
        }

        private void CalculateRoundResults(bool isCorrectAnswer)
        {
            if(isCorrectAnswer)
                _game.RoundWon();
            if (!isCorrectAnswer || _game.GameIsWon)
                EndGame(_game.GameIsWon);
        }

        private void EndGame(bool gameIsWon)
        {
            var result = "";
            if (gameIsWon)
            {
                result = "You answered "+ _game.CurrentScorePosition + "out of 15 questions and got this much money : " +
                         _scores[_game.CurrentScorePosition - 1];
            }
            else
            {
                bool isFound = false;
                int scorePosition = -1;
                foreach (var position in _game.SafePositionsSet)
                {
                    if (position < _game.CurrentScorePosition)
                    {
                        isFound = true;
                        scorePosition = position;
                        continue;
                    }
                    if (isFound && position >= _game.CurrentScorePosition)
                        break;
                }

                if (scorePosition == -1)
                    result = "You lost";
                else
                    result = "You answered " + scorePosition + " questions and got some money : " +
                         _scores[scorePosition];
            }

            if (File.Exists(_game.CurrentPlayer.Name + "_gameProgress.xml"))
                File.Delete(_game.CurrentPlayer.Name + "_gameProgress.xml");

            var resultsWindow = new EndGameWindow(result);
            resultsWindow.Show();
            this.Close();
        }

        private void SetButtonsColorAfterAnswer(Button clickedButton, bool isCorrectAnswer)
        {
            //wait for a moment or two
            if (isCorrectAnswer)
                clickedButton.Background = Brushes.LawnGreen;
            else
            {
                clickedButton.Background = Brushes.Red;
                var buttonList = CreateButtonList();
                string correctAnswer = _game.CurrentRound.GetCorrectAnswer();
                var correctAnswerButton = buttonList.Find(x => (string)x.Content == correctAnswer);
                correctAnswerButton.Background = Brushes.LawnGreen;
            }
        }

        private void SecondAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            SecondAnswerButton.Background = Brushes.Yellow;
            var isFinalAnswer = ConfirmAnswer("Is this your final answer?");
            if (isFinalAnswer)
            {
                EndRound(ref SecondAnswerButton);
            }
            else
                SecondAnswerButton.Background = Brushes.White;
        }

        private void FourAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            FourthAnswerButton.Background = Brushes.Yellow;
            var isFinalAnswer = ConfirmAnswer("Is this your final answer?");
            if (isFinalAnswer)
            {
                EndRound(ref FourthAnswerButton);
            }
            else
                FourthAnswerButton.Background = Brushes.White;
        }

        private void ThirdAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            ThirdAnswerButton.Background = Brushes.Yellow;
            var isFinalAnswer = ConfirmAnswer("Is this your final answer?");
            if (isFinalAnswer)
            {
                EndRound(ref ThirdAnswerButton);
            }
            else
                ThirdAnswerButton.Background = Brushes.White;
        }

        private void FiftyFiftyHintButton_Click(object sender, RoutedEventArgs e)
        {
            var answers =_game.CurrentRound.UseHint(_game.CurrentPlayer.Hints[0], _game.CurrentRound.GetAnswers(),
                _game.CurrentRound.GetCorrectAnswer());

            var buttonList = CreateButtonList();

            var answersToRemovePositions = new List<int>();
            for(int i = 0; i < buttonList.Count; i++)
            {
                if (!answers.Contains(buttonList[i].Content.ToString()))
                {
                    answersToRemovePositions.Add(i);
                }
            }
            _game.CurrentRound.SetFiftyFiftyPositions(answersToRemovePositions);
            RemoveFiftyFiftyHint();
            SaveProgress();
        }

        private void RemoveFiftyFiftyHint()
        {
            FiftyFiftyHintButton.Visibility = Visibility.Hidden;

            var buttonsList = CreateButtonList();
            foreach (var position in _game.CurrentRound.UsedHints.FiftyFiftyPositions)
            {
                buttonsList[position].Visibility = Visibility.Hidden;
            }
        }

        private void RemoveCallHint()
        {
            CallHintButton.Visibility = Visibility.Hidden;

            var buttonsList = CreateButtonList();
            buttonsList[_game.CurrentRound.UsedHints.CallFriendPosition].Background = Brushes.CadetBlue;
        }
        private void CallHintButton_Click(object sender, RoutedEventArgs e)
        {
            var requiredPossibility = SetPossibility();

            var answer = _game.CurrentRound.UseHint(_game.CurrentPlayer.Hints[1], _game.CurrentRound.GetAnswers(),
                _game.CurrentRound.GetCorrectAnswer(), requiredPossibility);

            var buttonList = CreateButtonList();
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (answer[0] == (string)buttonList[i].Content)
                {
                    _game.CurrentRound.SetCallHintsPosition(i);
                    break;
                }
            }
            RemoveCallHint();
            SaveProgress();
        }

        private void AudienceHelpButton_Click(object sender, RoutedEventArgs e)
        {
            var requiredPossibility = SetPossibility();

            var answers = _game.CurrentRound.UseHint(_game.CurrentPlayer.Hints[2], _game.CurrentRound.GetAnswers(),
                _game.CurrentRound.GetCorrectAnswer(), requiredPossibility);

            var currentCountOfAnswers = _game.CurrentRound.GetAnswers().Count;
            var answerPossibilities =
                ((AudienceHelpHint) _game.CurrentPlayer.Hints[2]).CalculateProbability(currentCountOfAnswers);

            var window = new ChartWindow(answers, answerPossibilities);
            window.ShowDialog();
        }

        private int SetPossibility()
        {
            if (_game.CurrentScorePosition < 5)
                return 99;
            if (_game.CurrentScorePosition < 10)
                return 66;
            return 33;
        }
        private void SaveProgress()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(_game.CurrentPlayer.Name + "_gameProgress.dat",
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _game);

            }
        }

        

        
    }
}
