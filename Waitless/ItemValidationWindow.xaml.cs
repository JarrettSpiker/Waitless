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
    /// Interaction logic for ItemValidationWindow.xaml
    /// </summary>
    public partial class ItemValidationWindow : Window
    {
        public ItemValidationWindow(bool sideErr, bool sizeErr, bool prepError)
        {
            InitializeComponent();
            SidesErrorMessage.Visibility = sideErr ? Visibility.Visible : Visibility.Collapsed;
            SizeErrorMessage.Visibility = sizeErr ? Visibility.Visible : Visibility.Collapsed;
            PrepErrorMessage.Visibility = prepError ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
