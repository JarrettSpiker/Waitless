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
using System.Windows.Navigation;
using System.Windows.Media.Animation;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for ItemProfile.xaml
    /// </summary>
    public partial class ItemProfile : Window
    {
        public ItemProfile(List<String> sides, List<String> customisations)
        {
            Sides = sides;
            Customisations = customisations;
            if (sides.Contains("Yukon Fries")) YukonFries.IsChecked = true;
            if (sides.Contains("Caesar Salad")) CaesarSalad.IsChecked = true;
            if (sides.Contains("Mashed Potatoes")) MashedPotatoes.IsChecked = true;
            if (sides.Contains("Yam Fries")) YamFries.IsChecked = true;
            Ready = true;
            InitializeComponent();
        }

        public ItemProfile()
        {
            InitializeComponent();
            Customisations = new List<string>();
            Sides = new List<string>();
            Ready = true;
        }
        public Boolean Ready = false;
        public List<String> Customisations;
        public String SpecialRequest="";
        public String Preparation = "";
        public List<String> Sides;

        public void SetEnabled(Boolean b)
        {
            Xdescription.IsEnabled = b;
            Xprep.IsEnabled = b;
            Xsides.IsEnabled = b;
            Customise.IsEnabled = b;
            AddToOrder.IsEnabled = b;
            Customise.IsEnabled = b;
            backButton.IsEnabled = b;
            btnRightMenuHide.IsEnabled = b;
            btnRightMenuShow.IsEnabled = b;
            SR.IsEnabled = b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRightMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }

        private void btnRightMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SpecialRequestClicked(object sender, RoutedEventArgs e)
        {
            SetEnabled(false);
            SpecialRequest h = new SpecialRequest(this);
            h.Show();
        }

        private void CustomizeClicked(object sender, RoutedEventArgs e)
        {
            SetEnabled(false);
            Customize customizeDialog = new Customize(this);
            customizeDialog.Show();
        }

        private void Rare_Checked(object sender, RoutedEventArgs e)
        {  
            Preparation = "Rare";
        }

        private void Medium_Rare_Checked(object sender, RoutedEventArgs e)
        {  
            Preparation = "Medium-Rare";
        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {  
            Preparation = "Medium";
        }

        private void Well_Done_Checked(object sender, RoutedEventArgs e)
        {
            Preparation = "Well-Done";
        }

        private void YukonFries_Checked(object sender, RoutedEventArgs e)
        {
            if (Ready)
                Sides.Add("Yukon Fries");
        }

        private void YukonFries_Unchecked(object sender, RoutedEventArgs e)
        {
            Sides.Remove("Yokon Fries");
        }

        private void YamFries_Checked(object sender, RoutedEventArgs e)
        {
            if (Ready)
                Sides.Add("Yam Fries");
        }

        private void YamFries_Unchecked(object sender, RoutedEventArgs e)
        {
            Sides.Remove("Yam Fries");
        }

        private void MashedPotatoes_Checked(object sender, RoutedEventArgs e)
        {
            if (Ready)
                Sides.Add("Mashed Potatoes");
        }

        private void MashedPotatoes_Unchecked(object sender, RoutedEventArgs e)
        {
            Sides.Remove("Mashed Potatoes");

        }

        private void CaesarSalad_Checked(object sender, RoutedEventArgs e)
        {
            if (Ready)
                Sides.Add("Caesar Salad");
        }

        private void CaesarSalad_Unchecked(object sender, RoutedEventArgs e)
        {
            Sides.Remove("Caesar Salad");
        }
    }
}

