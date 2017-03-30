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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
      
        public OpeningWindow theWindow;

        public Login(OpeningWindow ow)
        {
            InitializeComponent();
            theWindow = ow;
            Global.kb_Top = 256;
            Global.kb_Left = 50;
          //  Global.showKeyboard();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            closure();
            this.Close();
              }

        private void closure()
        {
            if (UsernameField.Text.Equals(""))
                UsernameField.Text = "Guest";
            Global.username = UsernameField.Text;
            theWindow.setLoggedInUser(UsernameField.Text);
            theWindow.loginButton.IsEnabled = true;
            theWindow.tableCodeButton.IsEnabled = true;
            theWindow.tableCodeField.IsEnabled = true;
            theWindow.helpButton.IsEnabled = theWindow.notHelping;
            Global.hideKeyboard();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closure();  
        }
        private String old_username;
        private void UsernameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UsernameField.Text.Length < 14)
                old_username = UsernameField.Text;
            else
                UsernameField.Text = old_username;
            
        }

        private void UsernameField_MouseEnter(object sender, MouseEventArgs e)
        {
            Global.showKeyboard();
        }

        private void UsernameField_MouseLeave(object sender, MouseEventArgs e)
        {
            Global.hideKeyboard();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 32;
            this.Left = 50;
        }
    }
}
