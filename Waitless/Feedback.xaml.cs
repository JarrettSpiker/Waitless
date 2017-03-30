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
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        public static String text = "";
        public Feedback()
        {
            InitializeComponent();
            RequestField.Text = text;
            Global.kb_Left = 400;
            Global.kb_Top = 0;
            Global.showKeyboard();
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

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Global.Main.Show();
            Global.hideKeyboard();
            Close();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }
    }
}
