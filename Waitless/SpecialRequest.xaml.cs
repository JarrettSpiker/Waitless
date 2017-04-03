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
using Waitless.model;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for SpecialRequest.xaml
    /// </summary>
    public partial class SpecialRequest : Window
    {
        private ItemProfile IP;
        OrderedItem menuItem;
        public SpecialRequest(OrderedItem item, ItemProfile ip)
        {
            InitializeComponent();
            menuItem = item;
            RequestField.Text = item.specialRequest;
            IP = ip;
            IP.setEnabled(false);
            Global.kb_Left = 400;
            Global.kb_Top = 0;
            Global.showKeyboard();
        }

        private void RequestField_TextChanged(object sender, TextChangedEventArgs e)
        {
            menuItem.specialRequest = RequestField.Text;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            menuItem.specialRequest = RequestField.Text;
            IP.setEnabled(true);
            Global.hideKeyboard();
            this.Close();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuItem.specialRequest = RequestField.Text;
            IP.setEnabled(true);
            Global.hideKeyboard();
            
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 32;
            this.Left = 14;
        }
    }
}
