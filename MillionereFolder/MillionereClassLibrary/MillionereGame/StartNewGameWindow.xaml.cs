using Microsoft.Win32;
using MillionereClassLibrary;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Path = System.IO.Path;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for StartNewGameWindow.xaml
    /// </summary>
    public partial class StartNewGameWindow : Window
    {

        private Hoster _hoster;
        private List<QuestionStructure> _questionList;
        private Player _player;
        private List<int> _savePositions;
        public StartNewGameWindow()
        {
            InitializeComponent();
        }

        private void ChooseQuestionPackButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                InitialDirectory = Directory.GetCurrentDirectory() + @"\QuestionPacks"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string fullPath = Path.GetFullPath(openFileDialog.FileName);
                QuestionPackNameLabel.Content =
                    StartNewGameHelperFunctions.GetQuestionPackName(fullPath);
                _questionList = StartNewGameHelperFunctions.MakeQuestionList(fullPath);
                SetCorrectnessLabel(CorrectQuestionPackLabel,"Ok!","Green");
            }
        }

        private void SetSavePositions(List<int> positions = null)
        {
            _savePositions = positions ?? new List<int> {4, 9, 14};
        }
        private void GalkinCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DibrovCheckBox.IsChecked = false;
            _hoster = StartNewGameHelperFunctions.MakeHoster("Galkin");
            SetCorrectnessLabel(CorrectHosterLabel, "Ok!", "Green");
        }

        private void DibrovCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GalkinCheckBox.IsChecked = false;
            _hoster = StartNewGameHelperFunctions.MakeHoster("Dibrov");
            CorrectHosterLabel.Content = "";
            SetCorrectnessLabel(CorrectHosterLabel, "Ok!", "Green");
        }

        private void GalkinCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CorrectHosterLabel.Content = "";
        }
        private void DibrovCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CorrectHosterLabel.Content = "";
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayCorrectnessLabels();
            if (GameIsReady())
            {
                SetSavePositions();
                _player = StartNewGameHelperFunctions.MakePlayer(PlayersNameTextBox.Text);
                var game = new Game(_hoster, _questionList, _player, _savePositions);

                var window = new GameWindow(game);
                window.Show();
                this.Close();
            }
        }

        private void SetCorrectnessLabel(Label labelToChange, string message = "Bad!", string colorName = "Red")
        {
            labelToChange.Content = message;
            var color = (Color)ColorConverter.ConvertFromString(colorName);
            labelToChange.Foreground = new SolidColorBrush(color);
        }

        private void DisplayCorrectnessLabels()
        {
            if((bool)DibrovCheckBox.IsChecked || (bool)GalkinCheckBox.IsChecked)
                SetCorrectnessLabel(CorrectHosterLabel, "Ok!", "Green");
            else
                SetCorrectnessLabel(CorrectHosterLabel);

            if(PlayersNameTextBox.Text != "" && Validator.CheckPlayersName(PlayersNameTextBox.Text))
                SetCorrectnessLabel(CorrectPlayerNameLabel, "Ok!", "Green");
            else
                SetCorrectnessLabel(CorrectPlayerNameLabel);

            if((string)QuestionPackNameLabel.Content != "")
                SetCorrectnessLabel(CorrectQuestionPackLabel, "Ok!", "Green");
            else
                SetCorrectnessLabel(CorrectQuestionPackLabel);
        }

        private bool GameIsReady()
        {
            return CorrectPlayerNameLabel.Content == CorrectHosterLabel.Content &&
                   CorrectQuestionPackLabel.Content == CorrectPlayerNameLabel.Content && CorrectHosterLabel.Content != "Bad!";
        }
    }
}
