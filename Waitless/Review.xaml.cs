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

namespace Waitless
{
    /// <summary>
    /// Interaction logic for Review.xaml
    /// </summary>
    public partial class Review : Window
    {
        public static String text = "";
        public static int stars = 0;

        public static void reset()
        {
            text = "";
            stars = 0;
        }

        public Review()
        {
            InitializeComponent();
            if (stars == 1) one.IsEnabled = false;
            if (stars == 2) two.IsEnabled = false;
            if (stars == 3) three.IsEnabled = false;
            if (stars == 4) four.IsEnabled = false;
            if (stars == 5) five.IsEnabled = false;
            RequestField.Text = text;
            Global.showKeyboard();
            
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = false;
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            stars = 1;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = true;
            two.IsEnabled = false;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            stars = 2;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = true;
            two.IsEnabled = true;
            three.IsEnabled = false;
            four.IsEnabled = true;
            five.IsEnabled = true;
            stars = 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = true;
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = false;
            five.IsEnabled = true;
            stars = 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = true;
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = false;
            stars = 5; 
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Global.hideKeyboard();
            Global.Main.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Main.Show();
            Global.hideKeyboard();
        }

        private void RequestField_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = RequestField.Text;
        }
    }
}
