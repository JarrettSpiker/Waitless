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
                component.ItemName.Inlines.Clear();
                component.ItemName.Inlines.Add(item.itemDefinition.name);
                component.Price.Inlines.Clear();
                component.Price.Inlines.Add((item.itemDefinition.cost / 100.0).ToString("F"));

                PendingItemsComponent.Children.Add(component);
            }
        }

        private void RedrawConfirmedItems()
        {
            ConfirmedItemsComponent.Children.Clear();


            foreach (Tuple<OrderedItem,double> item in confirmedItems)
            {
                ConfirmedItemControl component = new ConfirmedItemControl();
                component.ItemName.Inlines.Clear();
                component.ItemName.Inlines.Add(item.Item1.itemDefinition.name);
                component.Price.Inlines.Clear();
                component.Price.Inlines.Add((item.Item2 * item.Item1.itemDefinition.cost / 100.0).ToString("F"));

                if (item.Item1.itemDefinition.freeRefills)
                {
                    component.ReorderButton.Content = "Refill";
                }

                component.Quantity.Inlines.Clear();
                component.Quantity.Inlines.Add(item.Item2.ToString("0.##"));


                ConfirmedItemsComponent.Children.Add(component);
            }
        }

        private void RedrawOthersItems()
        {
            OthersItemsComponent.Children.Clear();
            foreach(OrderedItem item in othersItems)
            {
                OthersItemControl component = new OthersItemControl();
                component.ItemName.Inlines.Clear();
                component.ItemName.Inlines.Add(item.itemDefinition.name);
                component.Price.Inlines.Clear();                    
                component.Price.Inlines.Add((item.itemDefinition.cost / 100.0).ToString("F"));
                OthersItemsComponent.Children.Add(component);
            }
            
        }
    }
}
