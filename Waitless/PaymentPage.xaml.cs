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
    public partial class PaymentPage : Window
    {
        private DispatcherTimer timer;
        public bool paid = false;
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            PaymentMade();
        }

        private void PaymentMade()
        {
            paid = true;
            SuccessString.Visibility = Visibility.Visible;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        public void TimerTick(object sender, EventArgs args)
        {
            paid = true;
            timer.Stop();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(timer != null)
            {
                timer.Stop();
            }
            Close();
        }

        private void Window_LocationChanged(object sender, System.EventArgs e)
        {
            this.Top = HackyCommunicationClass.mainWindow.Top;
            this.Left = HackyCommunicationClass.mainWindow.Left;
        }
    }
}
