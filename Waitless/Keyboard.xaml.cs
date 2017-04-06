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
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : Window
    {
        private static Boolean fixed_position = true;
        public Keyboard()
        {
            InitializeComponent();
            if (fixed_position)
            {
                this.Top = 526;
                this.Left = 0;
            }
            else
            {
                this.Top = Global.kb_Top;
                this.Left = Global.kb_Left;
            }
        }

        public Boolean closed = false;

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!closed) {
            Keyboard k = new Keyboard();
            k.Show();
                Global.kb = k;
        }
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (fixed_position)
            {
                this.Top = 526;
                this.Left = 0;
            }
            else
            {
                this.Top = Global.kb_Top;
                this.Left = Global.kb_Left;
            }
        }
    }
}
