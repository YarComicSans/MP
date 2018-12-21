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
using System.IO;

namespace Redactor
{
    /// <summary>
    /// Логика взаимодействия для DeletePack.xaml
    /// </summary>
    

        //___________________УДАЛЕНИЕ НАБОРА ВОПРОСОВ__________________________
    public partial class DeletePack : Window
    {
        string path = "C:\\Users\\User\\source\\repos\\Redactor\\Redactor\\bin\\Debug";
        string[] files2 = Directory.GetFiles("C:\\Users\\User\\source\\repos\\Redactor\\Redactor\\bin\\Debug", "*.xml");
        
        public DeletePack()
        {
            InitializeComponent();
            foreach (string item in files2)
            {
                int index = item.LastIndexOf("\\");
                string completeItem = item.Substring(index + 1);
                PackList.Items.Add(completeItem);
            }
        }

        private void DeletePackButton_Click(object sender, RoutedEventArgs e)
        {
            string index = PackList.SelectedItem.ToString();
            
            for (int i = 0; i < files2.Length; i++)
            {
                if (files2[i].EndsWith(index))
                {
                    File.Delete(files2[i]);
                }
            }
            PackList.Items.Remove(PackList.SelectedItem);
        }

        private void BackInMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
