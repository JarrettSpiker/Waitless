using System.Collections.Generic;
using System.Windows.Controls;
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

        List<OrderedItem> pendingItems;
        List<Tuple<OrderedItem,double>> confirmedItems;
        List<OrderedItem> othersItems;

        public ChequePage()
        {
            InitializeComponent();
            pendingItems = new List<OrderedItem>();
            confirmedItems = new List<Tuple<OrderedItem,double>>();
            othersItems = new List<OrderedItem>();

            //init fixed "others" items

            othersItems.Add(new OrderedItem(ItemDefinitionController.itemDefinitions["Rickards Red"], "otherUserId"));
            othersItems.Add(new OrderedItem(ItemDefinitionController.itemDefinitions["Classic Burger"], "otherUserId"));


            //TODO testing code, add some hard coded values

            pendingItems.Add(new OrderedItem(ItemDefinitionController.itemDefinitions["Western Burger"], "currentUserId"));
            pendingItems.Add(new OrderedItem(ItemDefinitionController.itemDefinitions["Nachos"], "currentUserId"));

            confirmedItems.Add(Tuple.Create(new OrderedItem(ItemDefinitionController.itemDefinitions["Alexander Keiths"], "currentUserId"),1.0));
            confirmedItems.Add(Tuple.Create(new OrderedItem(ItemDefinitionController.itemDefinitions["Jalapeno Poppers"], "currentUserId"), 0.25));


            confirmedItems.Add(Tuple.Create(new OrderedItem(ItemDefinitionController.itemDefinitions["Water"], "currentUserId"), 2.0));

            RedrawItems();
            initialized = true;
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
                
                component.Price.Text= (item.itemDefinition.cost / 100.0).ToString("F");

                PendingItemsComponent.Children.Add(component);
            }
            RecalculatePrice();
        }

        private void RedrawConfirmedItems()
        {
            ConfirmedItemsComponent.Children.Clear();


            foreach (Tuple<OrderedItem,double> item in confirmedItems)
            {
                ConfirmedItemControl component = new ConfirmedItemControl();
                component.ItemName.Text = item.Item1.itemDefinition.name;
                
                component.Price.Text = (item.Item2 * item.Item1.itemDefinition.cost / 100.0).ToString("F");

                if (item.Item1.itemDefinition.freeRefills)
                {
                    component.ReorderButton.Content = "Refill";
                }

                component.Quantity.Text = item.Item2.ToString("0.##");


                ConfirmedItemsComponent.Children.Add(component);
            }
            RecalculatePrice();
        }

        private void RedrawOthersItems()
        {
            OthersItemsComponent.Children.Clear();
            foreach(OrderedItem item in othersItems)
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
            foreach(OrderedItem item in pendingItems)
            {
                subtotal += item.itemDefinition.cost;
            }
            foreach(Tuple<OrderedItem,double> tuple in confirmedItems)
            {
                subtotal += tuple.Item2 * (tuple.Item1.itemDefinition.cost);
            }
            
            double amntTax = (Int32.Parse(((TaxAmount.SelectedItem as ComboBoxItem).Content as string).Split('%')[0])/100.0) +1;
            double grandTotal = subtotal * amntTax;

            Subtotal.Text = "$" + (subtotal / 100.0).ToString("F");

            GrandTotal.Text = "$" + (subtotal * amntTax / 100.0).ToString("F");

        }

        private void TaxAmount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (initialized)
            {
                RecalculatePrice();
            }
        }
    }
}
