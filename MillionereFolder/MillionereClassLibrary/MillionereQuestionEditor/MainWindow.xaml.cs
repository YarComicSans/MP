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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace MillionereQuestionEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreatePack_Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePackButton.Visibility = Visibility.Hidden;
            EditPackButton.Visibility = Visibility.Hidden;
            CreatePackLabel.Visibility = Visibility.Hidden;
            EditPackLabel.Visibility = Visibility.Hidden;
            PackNameTBox.Visibility = Visibility.Visible;
            PackName.Visibility = Visibility.Visible;
            CreateNamePack.Visibility = Visibility.Visible;

        }

        private void EditPack_Button_Click(object sender, RoutedEventArgs e)
        {
            QuestionPack pack = QuestionPackHandler.DeserializePack();
            if (pack != null)
            {
                QuestionEditorWindow window = new QuestionEditorWindow(pack);
                window.ShowDialog();
                this.Close();
            }
        }

        private void CreateNamePack_Click(object sender, RoutedEventArgs e)
        {
            if (PackNameTBox.Text=="")
            {
                MessageBox.Show("Введите название набора вопросов!");
            }
            else
            {
                if (PackNameTBox.Text[0].ToString() == " ")
                {
                    PackNameTBox.Text = "";
                    MessageBox.Show("Введите корректное название набора вопросов!");

                }
                else
                {
                    QuestionEditorWindow window = new QuestionEditorWindow(null, PackNameTBox.Text);
                    window.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
