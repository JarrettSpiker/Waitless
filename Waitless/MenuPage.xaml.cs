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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            profile.Show();
        }

    }
}
