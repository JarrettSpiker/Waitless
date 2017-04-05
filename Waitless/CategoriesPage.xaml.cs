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

namespace Waitless
{
    /// <summary>
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();

            HackyCommunicationClass.registerCategoriesPage(this);
        }


        public void OnCategorySelected(object sender, RoutedEventArgs e)
        {

            MenuPage.ScrollPosition = 0;
            HackyCommunicationClass.mainWindow.OnCategorySelected(((Button)sender).Name);
            
        }

        private void AppetizersToShare_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 142;
            Global.Main.gotoMenu();
        }

        private void Burgers_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 288;
            Global.Main.gotoMenu();
        }

        private void Steak_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 490;
            Global.Main.gotoMenu();
        }

        private void Seafood_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 635;
            Global.Main.gotoMenu();
        }

        private void Sandwiches_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 777;
            Global.Main.gotoMenu();
        }

        private void Pasta_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 922;
            Global.Main.gotoMenu();
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 1068;
            Global.Main.gotoMenu();
        }

        private void Sides_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 1212;
            Global.Main.gotoMenu();
        }


        private void Desserts_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 1475;
            Global.Main.gotoMenu();
        }

        private void NonAlcoholic_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 1618;
            Global.Main.gotoMenu();
        }

        private void Alcoholic_Click(object sender, RoutedEventArgs e)
        {
            MenuPage.ScrollPosition = 1752;
            Global.Main.gotoMenu();
        }
    }
}
