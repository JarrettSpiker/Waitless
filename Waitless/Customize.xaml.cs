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
    /// Interaction logic for Customize.xaml
    /// </summary>
    public partial class Customize : Window
    {
        private ItemProfile IP;
        private Boolean Ready = false;
        public Customize(ItemProfile ip)
        {

            InitializeComponent();
            IP = ip;
            if (IP.options.Contains("Peppercorn"))
                peppercorn.IsChecked = true;
            if (IP.options.Contains("Steak Sauce"))
                steaksauce.IsChecked = true;
            Ready = true;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Ready)
            IP.options.Add("Steak Sauce");
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (Ready)
            IP.options.Add("Peppercorn");
           
        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void steaksauce_Unchecked(object sender, RoutedEventArgs e)
        {
            IP.options.Remove("Steak Sauce");
           
        }

        private void peppercorn_Unchecked(object sender, RoutedEventArgs e)
        {
            IP.options.Remove("Peppercorn");
           
        }

        
    }
}
