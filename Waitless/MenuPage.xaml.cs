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

    }
}
