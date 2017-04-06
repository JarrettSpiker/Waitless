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

namespace Waitless
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        private Uri[] slides;
        private int size = 2;
        private int position = 0;
        public HelpViewer()
        {
            InitializeComponent();
            slides = new Uri[size+1];
            slides[0] = new Uri("Images/Help1.xaml", UriKind.Relative);
            slides[1] = new Uri("Images/Help2.xaml", UriKind.Relative);
            slides[2] = new Uri("Images/pepsi.xaml", UriKind.Relative);
            slides[2] = new Uri("Images/testHelpSlide.xaml", UriKind.Relative);
            HelpImage.NavigationService.Navigate(slides[0]);
         
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Global.Main.Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (--position == 0)
                Previous.IsEnabled = false;
            if (Next.IsEnabled == false)
                Next.IsEnabled = true;
            HelpImage.NavigationService.Navigate(slides[position]);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (++position == size)
                Next.IsEnabled = false;
            if (Previous.IsEnabled == false)
                Previous.IsEnabled = true;
            HelpImage.NavigationService.Navigate(slides[position]);
        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Main.Show();
        }
    }
}
