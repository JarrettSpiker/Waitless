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
    /// Interaction logic for PaymentConfirmationDialog.xaml
    /// </summary>
    public partial class PaymentConfirmationDialog : Window
    {

        public bool confirmed = false;
        public PaymentConfirmationDialog(string price)
        {
            InitializeComponent();
            Price.Text = price;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Confirm_Clicked(object sender, RoutedEventArgs e)
        {
            confirmed = true;
            Close();
        }

        private void Window_LocationChanged(object sender, System.EventArgs e)
        {
            this.Top = 75;
            this.Left = 75;
        }
    }
}
