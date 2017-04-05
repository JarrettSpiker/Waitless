using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Waitless.model;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for OrderConfirmationWindow.xaml
    /// </summary>
    public partial class OrderConfirmationWindow : Window
    {

        public bool confirmed = false;

        public OrderConfirmationWindow()
        {
            InitializeComponent();
            PopulateList();
        }

        private void PopulateList()
        {
            foreach(OrderedItem item in ChequePage.pendingItems)
            {
                TextBlock text = new TextBlock();
                Thickness m = text.Margin;
                m.Left = 2;
                text.Margin = m;
                text.Text = item.itemDefinition.name;
                text.Foreground = new SolidColorBrush(Colors.Blue);
                ItemsToConfirm.Children.Add(text);
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Confirm_Clicked(object sender, RoutedEventArgs e)
        {
            confirmed = true;
            Close();
        }

        private void Window_LocationChanged(object sender, System.EventArgs e)
        {
            this.Top = 75;
            this.Left = 75;
        }
    }
}
