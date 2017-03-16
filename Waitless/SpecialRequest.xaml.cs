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
    /// Interaction logic for SpecialRequest.xaml
    /// </summary>
    public partial class SpecialRequest : Window
    {
        private Boolean Ready = false;
        private ItemProfile IP;
        public SpecialRequest(ItemProfile ip)
        {
            InitializeComponent();
            IP = ip;
            RequestField.AcceptsReturn = true;
            RequestField.Text = ip.SpecialRequest;
            Ready = true;
        }

        private void RequestField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Ready)
            IP.SpecialRequest = RequestField.Text;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
