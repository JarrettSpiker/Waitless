using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System;
using Waitless.model;
using Waitless.controls;

namespace Waitless
{
    /// <summary>
    /// Interaction logic for ChequePage.xaml
    /// </summary>
    public partial class ChequePage : Page
    {

        bool initialized = false;

        public static List<OrderedItem> pendingItems = new List<OrderedItem>();
        public static List<Tuple<OrderedItem, double>> confirmedItems = new List<Tuple<OrderedItem, double>>();
        public static List<OrderedItem> othersItems = new List<OrderedItem>();

        public ChequePage()
        {
            InitializeComponent();
            RedrawItems();
            initialized = true;
            
        }

        public static void reset()
        {
            pendingItems = new List<OrderedItem>();
            confirmedItems = new List<Tuple<OrderedItem, double>>();
            othersItems = new List<OrderedItem>();
        }

        void addPendingItem(OrderedItem item)
        {
            pendingItems.Add(item);
            RedrawPendingItems();
        }

        private void RedrawItems()
        {
            RedrawPendingItems();
            RedrawConfirmedItems();
            RedrawOthersItems();
        }

        private void RedrawPendingItems()
        {
            PendingItemsComponent.Children.Clear();
            foreach (OrderedItem item in pendingItems)
            {
                PendingItemControl component = new PendingItemControl();
                component.ItemName.Text = item.itemDefinition.name;
                component.Price.Text = item.isRefill ? "0.00" : (item.itemDefinition.cost / 100.0).ToString("F");
                
                component.XButton.Click += (s, eArgs) =>
                {
                    if (initialized)
                    {
                        pendingItems.Remove(item);
                        RedrawPendingItems();
                    }
                };

                component.EditButton.Click += (s, args) =>
                {
                    Global.Main.Hide();
                    ItemProfile itemProfile = new ItemProfile(item);
                    itemProfile.EnterEditMode();
                    itemProfile.ShowDialog();
                    
                };
                PendingItemsComponent.Children.Add(component);
            }
            RecalculatePrice();
            UpdateAddToOrderButton();
        }

        private void RedrawConfirmedItems()
        {
            ConfirmedItemsComponent.Children.Clear();


            foreach (Tuple<OrderedItem, double> item in confirmedItems)
            {
                ConfirmedItemControl component = new ConfirmedItemControl();
                component.ItemName.Text = item.Item1.itemDefinition.name;

                component.Price.Text = (item.Item2 * item.Item1.itemDefinition.cost / 100.0).ToString("F");

                if (item.Item1.itemDefinition.freeRefills)
                {
                    component.ReorderButton.Content = "Refill";
                }

                component.Quantity.Text = item.Item2.ToString("0.##");

                
                component.ReorderButton.Click += (s, eArgs) =>
                {
                    if (initialized)
                    {
                        if (item.Item1.itemDefinition.freeRefills)
                        {
                            OrderedItem refill = item.Item1.CreateCopy();
                            refill.isRefill = true;
                            pendingItems.Add(refill);
                            RedrawPendingItems();
                        }else
                        {
                            pendingItems.Add(item.Item1.CreateCopy());
                            RedrawPendingItems();
                        }
                    }
                };
                ConfirmedItemsComponent.Children.Add(component);
            }
            RecalculatePrice();
        }

        private void RedrawOthersItems()
        {
            OthersItemsComponent.Children.Clear();
            foreach (OrderedItem item in othersItems)
            {
                OthersItemControl component = new OthersItemControl();

                component.ItemName.Text = item.itemDefinition.name;
                component.Price.Text = (item.itemDefinition.cost / 100.0).ToString("F");
                OthersItemsComponent.Children.Add(component);
            }

        }

        private void RecalculatePrice()
        {
            double subtotal = 0;
            foreach (OrderedItem item in pendingItems)
            {
                subtotal += item.isRefill ? 0 : item.itemDefinition.cost;
            }
            foreach (Tuple<OrderedItem, double> tuple in confirmedItems)
            {
                subtotal += tuple.Item2 * (tuple.Item1.itemDefinition.cost);
            }

            double amntTax = (Int32.Parse(((TaxAmount.SelectedItem as ComboBoxItem).Content as string).Split('%')[0]) / 100.0) + 1;
            double grandTotal = subtotal * amntTax;

            Subtotal.Text = "$" + (subtotal / 100.0).ToString("F");

            GrandTotal.Text = "$" + (subtotal * amntTax / 100.0).ToString("F");

        }

        private void UpdateAddToOrderButton()
        {
            if (pendingItems.Count == 1)
            {
                NumItemsPendingText.Text = "1 item pending";
            }
            else
            {
                NumItemsPendingText.Text = pendingItems.Count + " items pending";
            }
        }

        private void TaxAmount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (initialized)
            {
                RecalculatePrice();
            }
        }

        private void OnPlaceOrderClicked(object sender, RoutedEventArgs e)
        {
            if (initialized)
            {
                foreach (OrderedItem pending in pendingItems)
                {
                    Tuple<OrderedItem,double> found = null;
                    foreach (Tuple<OrderedItem, double> confirmedItem in confirmedItems)
                    {
                        if (pending.Equals(confirmedItem.Item1))
                        {
                            found = confirmedItem;
                        }
                    }
                    if (found!=null)
                    {
                        confirmedItems.Remove(found);
                        confirmedItems.Add(Tuple.Create(pending, found.Item2+ (pending.isRefill ? 0 : 1)));
                    }else
                    {
                        confirmedItems.Add(Tuple.Create(pending, 1.0));
                    }
                }
                pendingItems.Clear();
                RedrawItems();
            }
        }
    }
}
