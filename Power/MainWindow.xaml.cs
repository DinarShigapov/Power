using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Power
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindI_Click(object sender, RoutedEventArgs e)
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(TBR.Text) == true || TBR.Text.EndsWith(",") == true)
            {
                error += "Введите значение R\n";
            }
            if (string.IsNullOrWhiteSpace(TBU.Text) == true)
            {
                error += "Введите значение U\n";
            }
            if (string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error);
                return;
            }

            double U = Convert.ToDouble(TBU.Text);
            double R = Convert.ToDouble(TBR.Text);
            double I = Math.Round(U / R, 3);
            
            if (R == 0)
            {
                MessageBox.Show("Делить на 0 нельзя");
                return;
            }


            TBAnswer.Text = I.ToString();
        }

        private void TBU_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }

            if (TBU.Text.Length == 0 && e.Text == ",")
            {
                e.Handled = true;
            }

            if (TBU.Text.Contains(",") == true)
            {
                e.Handled = true;
            }
        }

        private void TBR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }

            if (TBU.Text.Length == 0 && e.Text == ",")
            {
                e.Handled = true;
            }

            if (TBR.Text.Contains(",") == true)
            {
                e.Handled = true;
            }
        }
    }
}
