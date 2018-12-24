using System.Windows;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for ConfirmationScreen.xaml
    /// </summary>
    public partial class ConfirmationScreen : Window
    {
        public bool IsFinalAnswer;
        public ConfirmationScreen(string line)
        {
            InitializeComponent();
            QuestionLabel.Content = line;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            IsFinalAnswer = false;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            IsFinalAnswer = true;
            this.Close();
        }
    }
}
