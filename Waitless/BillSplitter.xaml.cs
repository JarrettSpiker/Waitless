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
        public BillSplitter()
        {
            InitializeComponent();


            billSplitterComponent.Children.Clear();
            foreach (Tuple<OrderedItem, double> tuple in ChequePage.confirmedItems){
                billSplitterItemControl control = new billSplitterItemControl();

                control.ItemName.Text = tuple.Item1.itemDefinition.name;
                // control.Price.Text = tuple.Item1.itemDefinition.cost;
                billSplitterComponent.Children.Add(control);
            }
        }
    }
}
