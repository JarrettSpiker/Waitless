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
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public static int choice = 0;
        public static Boolean paying;
        public PaymentPage()
        {
            InitializeComponent();
            Global.Main.PaymentMode();
            if (choice == 1) Cash.IsEnabled = false;
            if (choice == 2) Credit.IsEnabled = false;
            if (choice == 3) Debit.IsEnabled = false;
            if (choice == 4) PayPal.IsEnabled = false;
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            choice = 1;
            if (paying)
                Global.paid();
            Global.Main.gotoOptions();
            
        }

        private void Credit_Click(object sender, RoutedEventArgs e)
        {
            choice = 2;
            if (paying)
                Global.paid();
            Global.Main.gotoOptions();
        }

        private void Debit_Click(object sender, RoutedEventArgs e)
        {
            choice = 3;
            if (paying)
                Global.paid();
            Global.Main.gotoOptions();
        }

        private void PayPal_Click(object sender, RoutedEventArgs e)
        {
            choice = 4;
            if (paying)
                Global.paid();
            Global.Main.gotoOptions();
        }
    }
}
