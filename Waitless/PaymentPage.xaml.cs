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
using System.Windows.Threading;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        private DispatcherTimer timer;
        public PaymentPage()
        {
            InitializeComponent();
            Global.Main.PaymentMode();
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            PaymentMade();
        }

        private void PaymentMade()
        {
            SuccessString.Visibility = Visibility.Visible;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        public void TimerTick(object sender, EventArgs args)
        {
            Global.Main.gotoOptions();
            timer.Stop();
        }
    }
}
