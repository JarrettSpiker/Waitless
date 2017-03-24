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
using Waitless.model;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for ItemProfile.xaml
    /// </summary>
    public partial class ItemProfile : Window
    {
 
        OrderedItem menuItem;

        public ItemProfile(OrderedItem item)
        {
            InitializeComponent();
            menuItem = item;
            UpdateHeaders();
            UpdateImage();
            UpdateDescription();
            //UpdateNutritionalInfo(); TODO
            UpdateExpandables();
            //UpdateButtonStates(); //TODO

        }

        private void UpdateHeaders()
        {
            ItemName.Text = menuItem.itemDefinition.name;
            ItemPrice.Text = "$" + (menuItem.itemDefinition.cost / 100.0).ToString();
            string starString = "";
            for (int i = 0; i < menuItem.itemDefinition.numStars; i++)
            {
                starString += "✰";
            }
            ItemStars.Text = starString;
        }

        private void UpdateImage()
        {
            string imageUri = System.IO.Directory.GetCurrentDirectory() +menuItem.itemDefinition.imageRef;
            ItemImage.Source =new BitmapImage(new Uri(imageUri));
        }

        private void UpdateDescription()
        {
            ItemDescription.Text = menuItem.itemDefinition.description;
        }


        private void UpdateExpandables()
        {
            Xprep.Visibility = menuItem.itemDefinition.needsPreparation ? Visibility.Visible : Visibility.Collapsed;
            Xsides.Visibility = menuItem.itemDefinition.hasSides ? Visibility.Visible : Visibility.Collapsed;
            Xsize.Visibility = menuItem.itemDefinition.hasSize ? Visibility.Visible : Visibility.Collapsed;

            CustomizeButton.IsEnabled = menuItem.itemDefinition.isCustomizable;

            //Add the sizes to the expandable
            if (menuItem.itemDefinition.hasSize)
            {
                SizeOptions.Children.Clear();
                List<string> sizes = menuItem.itemDefinition.possibleSizes;
                for(int i = 0; i<sizes.Count; i++)
                {
                    string size = sizes[i];
                    RadioButton button = new RadioButton();
                    button.FontSize = 14;
                    button.Margin = new Thickness(3);
                    button.Content = size;
                    Grid.SetColumn(button, i % 2);
                    Grid.SetRow(button, i / 2);
                    button.Click += (s, eArgs) =>
                    {
                        menuItem.selectedSize = size;
                    };

                    SizeOptions.Children.Add(button);
                }
            }

            //Add the preperations to the expandable
            if (menuItem.itemDefinition.needsPreparation)
            {
                PreperationOptions.Children.Clear();
                List<string> preperations = menuItem.itemDefinition.possiblePreparations;
                for (int i = 0; i < preperations.Count; i++)
                {
                    string prep = preperations[i];
                    RadioButton button = new RadioButton();
                    button.FontSize = 14;
                    button.Margin = new Thickness(3);
                    button.Content = prep;
                    Grid.SetColumn(button, i % 2);
                    Grid.SetRow(button, i / 2);
                    button.Click += (s, eArgs) =>
                    {
                        menuItem.selectedPreparation = prep;
                    };

                    PreperationOptions.Children.Add(button);
                }
            }

            //Add the sides to the expandable
            //make sure to do checked and unchecked
            if (menuItem.itemDefinition.hasSides)
            {
                SidesOptions.Children.Clear();
                List<string> sides = menuItem.itemDefinition.possibleSides;
                for (int i = 0; i < sides.Count; i++)
                {
                    string side = sides[i];
                    CheckBox button = new CheckBox();
                    button.FontSize = 14;
                    button.Margin = new Thickness(3);
                    button.Content = side;
                    Grid.SetColumn(button, i % 2);
                    Grid.SetRow(button, i / 2);

                    button.Checked += (s, eArgs) =>
                    {
                        menuItem.customizations[side] = true;
                    };

                    button.Unchecked += (s, eArgs) =>
                    {
                        menuItem.customizations[side] = false;
                    };

                    SidesOptions.Children.Add(button);
                }
            }


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
            CustomizeButton.IsEnabled = b;
            AddToOrderButton.IsEnabled = b;
            CustomizeButton.IsEnabled = b;
            backButton.IsEnabled = b;
            btnRightMenuHide.IsEnabled = b;
            btnRightMenuShow.IsEnabled = b;
            SpecialRequestButton.IsEnabled = b;
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

