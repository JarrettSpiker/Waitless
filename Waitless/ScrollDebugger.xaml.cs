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
    /// Interaction logic for ScrollDebugger.xaml
    /// </summary>
    public partial class ScrollDebugger : Window
    {
        private MenuPage MP;
        
        public ScrollDebugger(MenuPage mp)
        {
            InitializeComponent();
            MP = mp;
        }

        private void ScrollPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MP.ScrollTo(Convert.ToDouble(ScrollPosition.Text));
            } catch(System.FormatException fjwi) { }
        }
    }
}
