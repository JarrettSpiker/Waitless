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
    /// Interaction logic for Paid.xaml
    /// </summary>
    public partial class Paid : Window
    {
        public Paid()
        {
            InitializeComponent();
            ChequePage.reset();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }
             private void timer_tick(object sender, EventArgs e)
        {
            Close();

        }
    }
    }

