using System.Windows;
using System.Windows.Controls;
using Waitless.model;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for Customize.xaml
    /// </summary>
    public partial class Customize : Window
    {

        OrderedItem menuItem;
        ItemProfile IP;
        public Customize(OrderedItem item, ItemProfile ip)
        {

            InitializeComponent();
            menuItem = item;
            UpdateCustomItems();
            IP = ip;
            IP.setEnabled(false);
        }

        private void UpdateCustomItems()
        {
            CustomizationOptions.Children.Clear();
            foreach(string customization in menuItem.itemDefinition.possibleCustomizations)
            {
                CheckBox button = new CheckBox();
                button.Height = 40;
                button.VerticalAlignment = VerticalAlignment.Center;
                button.Content = customization;
                button.IsChecked = menuItem.customizations[customization];
                button.Checked += (s, args) =>
                {
                    menuItem.customizations[customization] = true;
                };
                button.Unchecked += (s, args) =>
                {
                    menuItem.customizations[customization] = false;
                };

                CustomizationOptions.Children.Add(button);
            }
        }

       
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            IP.setEnabled(true);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IP.setEnabled(true);
        }

        private void Window_LocationChanged(object sender, System.EventArgs e)
        {
            this.Top = 32;
            this.Left = 14;
        }
    }
}
