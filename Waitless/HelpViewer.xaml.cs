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
        private int size = 7;
       
        public HelpViewer()
        {
            InitializeComponent();
            slides = new Uri[size+1];
            slides[0] = new Uri("Images/Help1.xaml", UriKind.Relative);
            slides[1] = new Uri("Images/Help2.xaml", UriKind.Relative);
            slides[2] = new Uri("Images/Help3.xaml", UriKind.Relative);
            slides[3] = new Uri("Images/Help4.xaml", UriKind.Relative);
            slides[4] = new Uri("Images/Help5.xaml", UriKind.Relative);
            slides[5] = new Uri("Images/Help6.xaml", UriKind.Relative);
            slides[6] = new Uri("Images/Help7.xaml", UriKind.Relative);
            slides[7] = new Uri("Images/Help8.xaml", UriKind.Relative);
            HelpImage.NavigationService.Navigate(slides[Global.HelpPosition]);
            if (Global.HelpPosition == size)
                Next.IsEnabled = false;
            if (Global.HelpPosition == 0)
                Previous.IsEnabled = false;
         
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            this.Top = HackyCommunicationClass.mainWindow.Top;
            this.Left = HackyCommunicationClass.mainWindow.Left;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Global.Main.Show();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (--Global.HelpPosition == 0)
                Previous.IsEnabled = false;
            if (Next.IsEnabled == false)
                Next.IsEnabled = true;
            HelpImage.NavigationService.Navigate(slides[Global.HelpPosition]);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (++Global.HelpPosition == size)
                Next.IsEnabled = false;
            if (Previous.IsEnabled == false)
                Previous.IsEnabled = true;
            HelpImage.NavigationService.Navigate(slides[Global.HelpPosition]);
        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Main.Show();
        }
    }
}
