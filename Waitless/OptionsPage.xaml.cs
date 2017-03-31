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
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private void LeaveTable_Click(object sender, RoutedEventArgs e)
        {
            ChequePage.reset();
            Review.reset();
            Feedback.text = "";
            PaymentPage.choice = 0;
            MenuPage.ScrollPosition = 0;
            OpeningWindow ow = new OpeningWindow();
            Global.Main.Hide();
            ow.Show();
            Global.Main.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.Main.Hide();
            Review r = new Review();
            r.Show();
        }

        private void feedback_Click(object sender, RoutedEventArgs e)
        {
            Feedback fwijl = new Feedback();
            fwijl.Show();
            Global.Main.Hide();
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistory owf = new OrderHistory();
            owf.Show();
            Global.Main.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PaymentPage.paying = false;
            Global.Main.PaymentPage();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpViewer wijg = new HelpViewer();
            wijg.Show();
            Global.Main.Hide();
        }
    }
}
