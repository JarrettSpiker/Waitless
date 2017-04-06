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
        //the list of strings is the users associated with the item
        public static List<Tuple<OrderedItem, List<string>>> confirmedItems = new List<Tuple<OrderedItem, List<string>>>();
        private double confirmedItemCost = 0.0;//storing this seperately to avoid repeating costly operations

        static ChequePage()
        {
            //add some fake "others" items
            confirmedItems.Add( new Tuple<OrderedItem, List<string>>(new OrderedItem(ItemDefinitionController.itemDefinitions["T-Bone Steak"], "otherUserId"), new List<string>() {"otherUserId"}));
            confirmedItems.Add(new Tuple<OrderedItem, List<string>>(new OrderedItem(ItemDefinitionController.itemDefinitions["Alexander Keiths"], "otherUserId"), new List<string>() { "otherUserId" }));
            
        }

        public ChequePage()
        {
            HackyCommunicationClass.RegisterChequePage(this);
            InitializeComponent();
            RedrawItems();
            initialized = true;
            Loaded += MyWindow_Loaded;
        }


        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (HackyCommunicationClass.shouldChequePageShowDialog)
            {
                HackyCommunicationClass.shouldChequePageShowDialog = false;
                PlaceOrder();
            }
        }

        public static void reset()
        {
            pendingItems = new List<OrderedItem>();
            confirmedItems = new List<Tuple<OrderedItem, List<string>>>();
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
                component.Price.Text = item.isRefill ? "0.00" : (item.EffectiveCost() / 100.0).ToString("F");
                
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
                    RedrawPendingItems();
                    
                };
                PendingItemsComponent.Children.Add(component);
            }
            RecalculatePrice();
            UpdateAddToOrderButton();
        }

        private void RedrawConfirmedItems()
        {
            ConfirmedItemsComponent.Children.Clear();

            List<OrderedItem> foundItems = new List<OrderedItem>();
            List<double> amounts = new List<double>();

            //create the foundItems and amounts lists from the confirmed item list
            for(int i = 0; i<confirmedItems.Count; i++)
            {
                Tuple<OrderedItem, List<string>> item = confirmedItems[i];
                if (!foundItems.Contains(item.Item1) && item.Item2.Contains("currentUserId"))
                {
                    double amnt = 1.0 / item.Item2.Count;
                    for(int j = i+1; j<confirmedItems.Count; j++)
                    {
                        if(confirmedItems[j].Item1.Equals(item.Item1) && confirmedItems[j].Item2.Contains("currentUserId"))
                        {
                            amnt += 1.0 / confirmedItems[j].Item2.Count;
                        }
                    }
                    foundItems.Add(item.Item1);
                    amounts.Add(amnt);
                }
            }

            confirmedItemCost = 0.0;
            //create new components from each foundItem
            for(int i = 0; i<foundItems.Count; i++)
            {
                //update the cost of the confirmed items, since I have that info available,
                //and I dont want to do all that shit above in the RecalculatePrice method.
                confirmedItemCost += (amounts[i] * foundItems[i].EffectiveCost());

                ConfirmedItemControl component = new ConfirmedItemControl();
                component.ItemName.Text = foundItems[i].itemDefinition.name;

                component.Price.Text = (amounts[i] * foundItems[i].EffectiveCost() / 100.0).ToString("F");

                if (foundItems[i].itemDefinition.freeRefills)
                {
                    component.ReorderButton.Content = "Refill";
                }

                component.Quantity.Text = amounts[i].ToString("0.##");

                OrderedItem itemRef = foundItems[i];
                component.ReorderButton.Click += (s, eArgs) =>
                {
                    if (initialized)
                    {
                        if (itemRef.itemDefinition.freeRefills)
                        {
                            OrderedItem refill = itemRef.CreateCopy();
                            refill.isRefill = true;
                            refill.paidAlready = refill.itemDefinition.cost;
                            pendingItems.Add(refill);
                            RedrawPendingItems();
                        }else
                        {
                            pendingItems.Add(itemRef.CreateCopy());
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

            List<OrderedItem> foundItems = new List<OrderedItem>();
            foreach (Tuple<OrderedItem,List<string>> item in confirmedItems)
            {
                if(!item.Item2.Contains("currentUserId"))
                {
                    OthersItemControl component = new OthersItemControl();

                    component.ItemName.Text = item.Item1.itemDefinition.name;
                    component.Price.Text = (item.Item1.EffectiveCost() / 100.0).ToString("F");
                    OthersItemsComponent.Children.Add(component);
                }
            }

        }

        private void RecalculatePrice()
        {
            double subtotal = 0;
            foreach (OrderedItem item in pendingItems)
            {
                subtotal += item.isRefill ? 0 : item.EffectiveCost();
            }

            subtotal += confirmedItemCost;

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
            PlaceOrder();
        }

        public void PlaceOrder()
        {
            if (initialized)
            {
                OrderConfirmationWindow confirmationDialog = new OrderConfirmationWindow();
                confirmationDialog.ShowDialog();
                if (confirmationDialog.confirmed)
                {
                    foreach (OrderedItem pending in pendingItems)
                    {
                        confirmedItems.Add(new Tuple<OrderedItem, List<string>>(pending, new List<string>() { "currentUserId" }));
                    }
                    pendingItems.Clear();
                    RedrawItems();
                }
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if(pendingItems.Count > 0)
            {
                new PaymentErrorDialog("You still have pending orders. Please confirm all pending items, or remove them from the order, before paying your tab.").ShowDialog();
                return;
            }

            if (GrandTotal.Text.Equals("$0.00"))
            {
                new PaymentErrorDialog("You have nothing to pay for! If you are finished, please select Leave Table in the Options Tab").ShowDialog();
                return;
            }

            PaymentConfirmationDialog confirmationDialog = new PaymentConfirmationDialog(GrandTotal.Text);
            confirmationDialog.ShowDialog();
            if (confirmationDialog.confirmed)
            {

                PaymentPage paymentPage = new PaymentPage();
                paymentPage.ShowDialog();
                if (paymentPage.paid)
                {
                    //remove currentUser from all items
                    foreach (Tuple<OrderedItem, List<string>> item in confirmedItems)
                    {
                        if (item.Item2.Contains("currentUserId"))
                        {

                            item.Item1.paidAlready += item.Item1.EffectiveCost() / item.Item2.Count;

                            item.Item2.Remove("currentUserId");
                            RedrawItems();
                        }
                    }
                    Global.Main.gotoOptions();
                }
            }

        }

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            BillSplitter bs = new BillSplitter();
            bs.ShowDialog();
            RedrawItems();
        }
    }
}
