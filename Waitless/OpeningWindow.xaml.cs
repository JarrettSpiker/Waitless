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
        public Boolean notHelping=true;
        private Login h;
        public OpeningWindow()
        {
            InitializeComponent();
            tableCodeField.Text = TABLECODE_TEXT;
            noTableCode = true;
            Global.kb_Top = 50;
            Global.kb_Left = 32;

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
                h = new Login(this);
            h.Show();
                
            
            
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {

            if (notHelping)
            {
                notHelping = false;
                image.Visibility = Visibility.Hidden;
                HelpText.Visibility = Visibility.Visible;
            }
            else
            {
                notHelping = true;
                image.Visibility = Visibility.Visible;
                HelpText.Visibility = Visibility.Hidden;

            }

        }

        private void tableCodeField_MouseEnter(object sender, MouseEventArgs e)
        {
            Global.showKeyboard();
        }

        private void tableCodeField_MouseLeave(object sender, MouseEventArgs e)
        {
            Global.hideKeyboard();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (loginButton.IsEnabled == false)
                h.Close();

        }
    }
}
