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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OpeningWindow : Window
    {
        public OpeningWindow()
        {
            InitializeComponent();
           
        }

        public String TableCode = "";
     
        private void tableCodeButton_Click(object sender, RoutedEventArgs e)
        {   if (TableCode.Equals(""));
            else {
                this.Hide();
                MainWindow MaineWindow = new MainWindow();
                MaineWindow.Show();
                this.Close(); }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
      
            TableCode = tableCodeField.Text;
            
         
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
