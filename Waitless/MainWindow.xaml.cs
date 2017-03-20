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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ItemDefinitionController.CreateSerialization();
            ItemDefinitionController.InitializeItemDefinitions();
        }

        private void request_Click(object sender, RoutedEventArgs e)
        {
            request.Visibility = Visibility.Hidden;
            requested.Visibility = Visibility.Visible;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();
        }
            
            private void timer_tick(object sender, EventArgs e)
        {
            requested.Visibility = Visibility.Hidden;
            request.Visibility = Visibility.Visible;

        }

    }



    }


