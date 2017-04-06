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
        public static double ScrollPosition = 0;
        int k;
       
        public MenuPage()
        {
            InitializeComponent();
            HackyCommunicationClass.registerMenuPage(this);
            ScrollTo(ScrollPosition);
            HideNewItemFlyout();
            UpdateItemFlyout();
            if (false)
            {
                ScrollDebugger sd = new ScrollDebugger(this);
                sd.Show();
            }
            
        }

        public void UpdateItemFlyout()
        {
            if(ChequePage.pendingItems.Count == 0)
            {
                HideNewItemFlyout();
            }
            else
            {
                string itemName = ChequePage.pendingItems[ChequePage.pendingItems.Count - 1].itemDefinition.name;
                ShowNewItemFlyout(itemName);
            }
        }

        public void ScrollTo(double value)
        {
            Scroll.ScrollToVerticalOffset(value);
        }

        public void OnBackToCategories(object sender, RoutedEventArgs e)
        {
            HackyCommunicationClass.mainWindow.OnBackToCategoriesEvent();
        }

        public void OnMenuItemSelected(object sender, RoutedEventArgs e)
        {
            OrderedItem menuItem = new OrderedItem(ItemDefinitionController.itemDefinitions[(sender as Button).Tag as string], "currentUserId");
            ItemProfile profile = new ItemProfile(menuItem);
            Global.Main.Hide();
            profile.ShowDialog();
            
        }


        public void HideNewItemFlyout()
        {
            MainGrid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
        }


        public void ShowNewItemFlyout(string itemName)
        {
            MainGrid.RowDefinitions[2].Height = new GridLength(25, GridUnitType.Pixel);
            if (itemName.Length>15)
            {
                char[] chars = itemName.ToCharArray();
                char[] newString = new char[18];
                for (int i = 0; i < 15; i++)
                    newString[i] = chars[i];
                for (int i = 15; i < 18; i++)
                    newString[i] = '.';
                itemName = new string(newString);
            }
            AddedToOrderText.Text = itemName + " added to pending items...";
        }

        public void OnPlaceOrderClicked(object sender, RoutedEventArgs args)
        {
            HackyCommunicationClass.mainWindow.SwitchToChequeWithOrder();
        }

        private void Scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollPosition = Scroll.VerticalOffset;
        }

        private void IconLegend_Click(object sender, RoutedEventArgs e)
        {
            Global.Main.IsEnabled = false;
            Icon_Legend i = new Icon_Legend();
            i.ShowDialog();
        }
    }
}
