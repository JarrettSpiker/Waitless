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
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
                if (UsernameField.Text.Equals(""))
                    UsernameField.Text = "Guest";
            Global.username = UsernameField.Text;
                theWindow.setLoggedInUser(UsernameField.Text);
                theWindow.loginButton.IsEnabled = true;
                theWindow.tableCodeButton.IsEnabled = true;
                theWindow.tableCodeField.IsEnabled = true;
                theWindow.helpButton.IsEnabled = true;
                this.Close(); 
        }
    }
}
