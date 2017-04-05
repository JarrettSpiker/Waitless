using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

            Circle currentUserCircle = new Circle("currentUserId", new SolidColorBrush( Colors.Blue));
            Circle otherUserCircle = new Circle("otherUserId", new SolidColorBrush(Colors.Red));
            Circle otherUser2Circle = new Circle("otherUserId2", new SolidColorBrush(Colors.Green));
            CircleDock.Children.Insert(0, currentUserCircle);
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
    }
}
