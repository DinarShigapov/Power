using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

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
            TBAccuracy.Text = defaultAccuracy.ToString();
        }

        private const int defaultAccuracy = 2;


        private void FindI_Click(object sender, RoutedEventArgs e)
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(TBR.Text) == true || TBR.Text.EndsWith(",") == true)
            {
                error += "Введите корректное значение R\n";
            }
            if (string.IsNullOrWhiteSpace(TBU.Text) == true || TBU.Text.EndsWith(",") == true)
            {
                error += "Введите корректное значение U\n";
            }
            if (string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error);
                return;
            }
            if (int.Parse(TBAccuracy.Text) > 15)
            {
                MessageBox.Show("Точность (0 - 15)");
                return;
            }

            double U = Convert.ToDouble(TBU.Text);
            double R = Convert.ToDouble(TBR.Text);
            double I = Math.Round(U / R, TBAccuracy.Text != "" ? int.Parse(TBAccuracy.Text) : defaultAccuracy);
            
            if (R == 0)
            {
                MessageBox.Show("Делить на 0 нельзя");
                return;
            }
            if (TBAccuracy.Text == "")
            {
                MessageBox.Show("Точность была указана по умолчанию");
                TBAccuracy.Text = defaultAccuracy.ToString();
            }

            TBAnswer.Text = I.ToString();


        }

        private void TB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;

            if (Regex.IsMatch(e.Text, @"[0-9,,]") == false)
                e.Handled = true;

            if (textBox.Text.Length == 0 && e.Text == ",")
                e.Handled = true;

            if (e.Text == "," && textBox.Text.Contains(','))
                e.Handled = true;
        }

        private void TBAccuracy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
                e.Handled = true;
        }
    }
}
