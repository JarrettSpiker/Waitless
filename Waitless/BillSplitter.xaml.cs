using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Waitless.controls;
using Waitless.model;

namespace Waitless
{

    /// <summary>
    /// Interaction logic for BillSplitter.xaml
    /// </summary>
    public partial class BillSplitter : Window
    {

        public BillSplitter()
        {
            InitializeComponent();

            HackyCommunicationClass.RegisterBillSplitter(this);
            recalculateBillSplitterTotals();

            Circle currentUserCircle = new Circle("currentUserId", new SolidColorBrush(Colors.Blue), "Me");
            Circle otherUserCircle = new Circle("otherUserId", new SolidColorBrush(Colors.Red), "TG");
            Circle otherUser2Circle = new Circle("otherUserId2", new SolidColorBrush(Colors.Green), "CD");
            CircleDock.Children.Insert(0, new Circle(currentUserCircle));
            CircleDock.Children.Insert(1, otherUserCircle);
            CircleDock.Children.Insert(2, otherUser2Circle);

            billSplitterComponent.Children.Clear();


            if (ChequePage.confirmedItems.Count() > 0)
            {

                foreach (Tuple<OrderedItem, List<string>> tuple in ChequePage.confirmedItems)
                {
                    billSplitterItemControl control = new billSplitterItemControl(tuple);
                    control.ItemName.Text = tuple.Item1.itemDefinition.name;
                    control.ItemPrice.Text = "$" + (tuple.Item1.EffectiveCost() / 100.0).ToString("F");

                    if (tuple.Item2.Contains("currentUserId"))
                    {
                        control.DropArea.Children.Add(new Circle(currentUserCircle));
                    }
                    if (tuple.Item2.Contains("otherUserId"))
                    {
                        control.DropArea.Children.Add(new Circle(otherUserCircle));
                    }
                    if (tuple.Item2.Contains("otherUserId2"))
                    {
                        control.DropArea.Children.Add(new Circle(otherUser2Circle));
                    }

                    billSplitterComponent.Children.Add(control);
                }

            }


        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Global.Main.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Global.Main.Show();
        }



        private void Garbage_Drop(object sender, DragEventArgs e)
        {
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (sender != null && _element != null)
                {
                    StackPanel parent = (StackPanel)VisualTreeHelper.GetParent(_element);
                    if (parent.Name.Equals("DropArea"))
                    {
                        Circle circ = (Circle)_element;
                        billSplitterItemControl control = (billSplitterItemControl)((ContentPresenter)VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(parent))).TemplatedParent;
                        control.itemReference.Item2.Remove(circ.userId);
                        parent.Children.Remove(circ);
                        recalculateBillSplitterTotals();
                    }


                }
            }
        }

        public void recalculateBillSplitterTotals()
        { 

            int userIntTotal = 0;
            int otherUserIntTotal = 0;
            int otherUser2IntTotal = 0;
            int k;
            foreach (Tuple<OrderedItem, List<string>> tuple in ChequePage.confirmedItems)
                {


                    int itemSplitCost;

                try
                {
                    itemSplitCost = tuple.Item1.EffectiveCost() / (tuple.Item2).Count();
                }
                catch (DivideByZeroException)
                {
                    itemSplitCost = 0;
                }

                    if (tuple.Item2.Contains("currentUserId"))
                    {
                    userIntTotal += itemSplitCost;
                    }
                    if (tuple.Item2.Contains("otherUserId"))
                    {
                    otherUserIntTotal += itemSplitCost;
                    }
                    if (tuple.Item2.Contains("otherUserId2"))
                    {
                    otherUser2IntTotal += itemSplitCost;
                    }

            }
            //currently giving errors below to references , commented out to avoid build errors
            currentUserTotal.Text = "$" + (userIntTotal / 100.0).ToString("F");
            otherUserId.Text = "$" + (otherUserIntTotal / 100.0).ToString("F");
            otherUserId2.Text = "$" + (otherUser2IntTotal / 100.0).ToString("F");
        }
    }
}
