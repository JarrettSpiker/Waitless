using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
            //UpdateNutritionalInfo(); TODO once the nutritional info is working again
            UpdateExpandables();
            UpdateButtonStates();

        }

        public void setEnabled(Boolean state)
        {
            if (menuItem.itemDefinition.isCustomizable)
            CustomizeButton.IsEnabled = state;
            AddToOrderButton.IsEnabled = state;
            SpecialRequestButton.IsEnabled = state;
            Xdescription.IsEnabled = state;
            Xprep.IsEnabled = state;
            Xsides.IsEnabled = state;
            Xsize.IsEnabled = state;
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
            string imageUri = System.IO.Directory.GetCurrentDirectory() + menuItem.itemDefinition.imageRef;
            ItemImage.Source = new BitmapImage(new Uri(imageUri));
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
                for (int i = 0; i < sizes.Count; i++)
                {
                    string size = sizes[i];
                    RadioButton button = new RadioButton();
                    button.FontSize = 14;
                    button.Margin = new Thickness(3);
                    button.Content = size;
                    Grid.SetColumn(button, i % 2);
                    Grid.SetRow(button, i / 2);
                    button.Tag = size;
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
                    button.Tag = prep;
                    button.Click += (s, eArgs) =>
                    {
                        menuItem.selectedPreparation = prep;
                    };

                    PreperationOptions.Children.Add(button);
                }
            }

            //Add the sides to the expandable
            if (menuItem.itemDefinition.hasSides)
            {
                SidesOptions.Children.Clear();
                List<string> sides = menuItem.itemDefinition.possibleSides;
                for (int i = 0; i < sides.Count; i++)
                {
                    string side = sides[i];
                    RadioButton button = new RadioButton();
                    button.FontSize = 14;
                    button.Margin = new Thickness(3);
                    button.Content = side;
                    Grid.SetColumn(button, i % 2);
                    Grid.SetRow(button, i / 2);
                    button.Tag = side;
                    button.Checked += (s, eArgs) =>
                    {
                        menuItem.selectedSide = side;
                    };

                    SidesOptions.Children.Add(button);
                }
            }


        }

        private void UpdateButtonStates()
        {
            //set the preperation
            if (menuItem.itemDefinition.needsPreparation)
            {
                foreach (object o in PreperationOptions.Children)
                {
                    RadioButton button = o as RadioButton;
                    string prep = button.Tag as string;
                    button.IsChecked = prep.Equals(menuItem.selectedPreparation);
                }
            }

            //set the side
            if (menuItem.itemDefinition.hasSides)
            {
                foreach (object o in SidesOptions.Children)
                {
                    RadioButton button = o as RadioButton;
                    string side = button.Tag as string;
                    button.IsChecked = side.Equals(menuItem.selectedSide);
                }
            }

            //set the size
            if (menuItem.itemDefinition.hasSize)
            {
                foreach (object o in SizeOptions.Children)
                {
                    RadioButton button = o as RadioButton;
                    string size = button.Tag as string;
                    button.IsChecked = size.Equals(menuItem.selectedSize);
                }
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Global.Main.Show();
            Close();
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

        private void SpecialRequestClicked(object sender, RoutedEventArgs e)
        {
            SpecialRequest h = new SpecialRequest(menuItem,this);
            h.ShowDialog();
        }

        private void CustomizeClicked(object sender, RoutedEventArgs e)
        {
            Customize customizeDialog = new Customize(menuItem,this);
            customizeDialog.ShowDialog();
        }

        private void OnAddToOrderClicked(object sender, RoutedEventArgs e)
        {
            ChequePage.pendingItems.Add(menuItem);
            Global.Main.Show();
            Close();
        }

        public void EnterEditMode()
        {
            
            AddToOrderButton.Content = "Update Item";
            //backButton.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Main.Show();
        }
    }
}

