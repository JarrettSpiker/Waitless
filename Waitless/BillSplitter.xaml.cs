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

using Waitless.controls;
using Waitless.model;

namespace Waitless
{ 

    /// <summary>
    /// Interaction logic for BillSplitter.xaml
    /// </summary>
    public partial class BillSplitter : Window
    {

        private List<Tuple<OrderedItem, List<String>>> nonUserItems = new List<Tuple<OrderedItem, List<String>>>();

        public BillSplitter()
        {
            InitializeComponent();

            if (ChequePage.confirmedItems.Count() > 0)
            {
                billSplitterComponent.Children.Clear();
                foreach (Tuple<OrderedItem, List<string>> tuple in ChequePage.confirmedItems)
                {
                    billSplitterItemControl control = new billSplitterItemControl();

                    if (tuple.Item2.Contains("currentUserId"))
                    {

                        control.ItemName.Text = tuple.Item1.itemDefinition.name;
                        control.ItemPrice.Text = "$" + (tuple.Item1.EffectiveCost() / 100.0).ToString("F");
                        billSplitterComponent.Children.Add(control);
                    }

                    else
                    {
                        nonUserItems.Add(tuple);
                    }

                }


                foreach (Tuple<OrderedItem, List<string>> tuple in nonUserItems)
                {
                    billSplitterItemControl control = new billSplitterItemControl();


                    control.ItemName.Text = tuple.Item1.itemDefinition.name;
                    control.ItemPrice.Text = "$" + (tuple.Item1.EffectiveCost() / 100.0).ToString("F");
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
