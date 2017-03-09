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
        public SpecialRequest()
        {
            InitializeComponent();
            RequestField.AcceptsReturn = true;
        }

        private void RequestField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

    }
}
