using System.Windows;
using System.Windows.Controls;
using Waitless.model;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

       
        public MenuPage()
        {
            InitializeComponent();
            HackyCommunicationClass.registerMenuPage(this);
            HideNewItemFlyout();
            ShowNewItemFlyout("foo");
        }

        public void OnBackToCategories(object sender, RoutedEventArgs e)
        {
            HackyCommunicationClass.mainWindow.OnBackToCategoriesEvent();
        }

        public void OnMenuItemSelected(object sender, RoutedEventArgs e)
        {
            OrderedItem menuItem = new OrderedItem(ItemDefinitionController.itemDefinitions[(sender as Button).Tag as string], "currentUserId");
            ItemProfile profile = new ItemProfile(menuItem);
            profile.ShowDialog();
        }


        public void HideNewItemFlyout()
        {
            MainGrid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
        }


        public void ShowNewItemFlyout(string itemName)
        {
            MainGrid.RowDefinitions[2].Height = new GridLength(25, GridUnitType.Pixel);
            AddedToOrderText.Text = itemName + " added to order...";
        }

        public void OnPlaceOrderClicked(object sender, RoutedEventArgs args)
        {
            HackyCommunicationClass.mainWindow.SwitchToCheque();
        }
    }
}
