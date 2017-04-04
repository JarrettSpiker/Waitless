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
    /// Interaction logic for Icon_Legend.xaml
    /// </summary>
    public partial class Icon_Legend : Window
    {
        public Icon_Legend()
        {
            InitializeComponent();
        }

        private void OK_click(object sender, RoutedEventArgs e)
        {
            Global.Main.IsEnabled = true;
            this.Close();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 32;
            this.Left = 25;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Main.IsEnabled = true;
        }
    }
}
