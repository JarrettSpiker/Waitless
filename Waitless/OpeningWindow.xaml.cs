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
        private String TABLECODE_TEXT = "Enter Table Code";
        private Boolean noTableCode;
        public OpeningWindow()
        {
            InitializeComponent();
            tableCodeField.Text = TABLECODE_TEXT;
            noTableCode = true;

        }

        public void CheckNoTableCode()
        {
            if (tableCodeField.Text.Equals(""))
            {
                tableCodeField.Text = TABLECODE_TEXT;
                noTableCode = true;
            }
        }

        public void setLoggedInUser(String user)
        {
            LoggedInUser.Text = "Currently logged in as: "+user;
      
        }

        public String TableCode = "";
        private void tableCodeButton_Click(object sender, RoutedEventArgs e)
        {
            CheckNoTableCode();
            if (noTableCode==false)
             {
                this.Hide();
                MainWindow MaineWindow = new MainWindow();
                MaineWindow.Show();
                Global.tablecode = TableCode;
                
                this.Close(); }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (noTableCode)
            { tableCodeField.Text = Global.ChangeFromDefault(TABLECODE_TEXT, tableCodeField.Text); tableCodeField.Focus(); tableCodeField.Select(1, 0); noTableCode = false; }
            TableCode = tableCodeField.Text;
            
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            CheckNoTableCode();
            loginButton.IsEnabled = false;
                tableCodeButton.IsEnabled = false;
                tableCodeField.IsEnabled = false;
                helpButton.IsEnabled = false;
                Login h = new Login(this);
                h.Show();
            
            
        }
    }
}
