﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Waitless
{

    /// Interaction logic for Circle.xaml
    /// </summary>
    public partial class Circle : UserControl
    {

            public Brush _previousFill = null;
            public string userId;    


            public Circle(string _userId, Brush colour)
            {
                InitializeComponent();
                userId = _userId;
                _previousFill = colour;
                circleUI.Fill = colour;
            }


            public Circle(Circle c)
            {
                InitializeComponent();
                this.circleUI.Height = c.circleUI.Height;
                this.circleUI.Width = c.circleUI.Height;
                this.circleUI.Fill = c.circleUI.Fill;
                userId = c.userId;
                circleUI.Fill = c._previousFill;
            }


            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    // Package the data.
                    DataObject data = new DataObject();
                    data.SetData(DataFormats.StringFormat, userId);
                    data.SetData("Double", circleUI.Height);
                    data.SetData("Object", this);

                    // Inititate the drag-and-drop operation.
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }



            protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
            {
                base.OnGiveFeedback(e);
                // These Effects values are set in the drop target's
                // DragOver event handler.
                if (e.Effects.HasFlag(DragDropEffects.Copy))
                {
                    Mouse.SetCursor(Cursors.Cross);
                }
                else if (e.Effects.HasFlag(DragDropEffects.Move))
                {
                    Mouse.SetCursor(Cursors.Pen);
                }
                else
                {
                    Mouse.SetCursor(Cursors.Pen);
                }
                e.Handled = true;
            }



            protected override void OnDrop(DragEventArgs e)
            {
                base.OnDrop(e);

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    
                // If the string can be converted into a Brush, 
                // convert it and apply it to the ellipse.
                    
                }
                e.Handled = true;
            }



            protected override void OnDragOver(DragEventArgs e)
            {
                base.OnDragOver(e);
                e.Effects = DragDropEffects.None;

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, allow copying or moving.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid("Yellow"))
                    {
                        // Set Effects to notify the drag source what effect
                        // the drag-and-drop operation will have. These values are 
                        // used by the drag source's GiveFeedback event handler.
                        // (Copy if CTRL is pressed; otherwise, move.)
                        if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                        {
                            e.Effects = DragDropEffects.Copy;
                        }
                        else
                        {
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
                e.Handled = true;
            }


            protected override void OnDragEnter(DragEventArgs e)
            {
                base.OnDragEnter(e);
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
                _previousFill = circleUI.Fill;

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, convert it.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString.ToString());
                        circleUI.Fill = newFill;
                    }
                }
            }

            protected override void OnDragLeave(DragEventArgs e)
            {
                base.OnDragLeave(e);
                // Undo the preview that was applied in OnDragEnter.
                circleUI.Fill = _previousFill;
            }

        }
    }
