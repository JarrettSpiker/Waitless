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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Waitless.dragDropProofOfConcept;
using Waitless.model;

namespace Waitless.controls
{
    /// <summary>
    /// Interaction logic for billSplitterItemControl.xaml
    /// </summary>
    public partial class billSplitterItemControl : UserControl
    {


        //private int userTotal = itemPrice
        Boolean isUser;

        public billSplitterItemControl()
        {
             InitializeComponent();
        }



        public billSplitterItemControl(Boolean isUser)
        {
            this.isUser = isUser;
            InitializeComponent();
        }


        private void panel_Drop(object sender, DragEventArgs e)
        {
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    // Get the panel that the element currently belongs to,
                    // then remove it from that panel and add it the Children of
                    // the panel that its been dropped on.
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);


                    Circle circ = (Circle)_element;



                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);
                    if (!isUser)
                    {
                        foreach (Tuple<OrderedItem, List<string>> tuple in BillSplitter.nonUserItems)
                            if (tuple.Item1.itemDefinition.name.Equals(ItemName))
                            {
                                tuple.Item2.Add("currentUserId");
                            }

                    }
                    ItemPrice.Text = dataString;
                    Circle _circle = new Circle((Circle)_element);
                    DropArea.Children.Add(_circle);
                    // set the value to return to the DoDragDrop call
                    e.Effects = DragDropEffects.Copy;
               }

            }
         }



                public Boolean getIsUser()
                {
                    return isUser;
                }
        }


    }

            


        

