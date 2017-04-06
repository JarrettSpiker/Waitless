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
    /// Interaction logic for PaymentErrorDialog.xaml
    /// </summary>
    public partial class PaymentErrorDialog : Window
    {
        public PaymentErrorDialog(string message)
        {
            InitializeComponent();
            ErrorMessage.Text = message;
        }

        public void ConfirmButton_Click(object sender, EventArgs args)
        {
            Close();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 32;
            this.Left = 25;
        }
    }
}
