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
using Label = System.Reflection.Emit.Label;

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
