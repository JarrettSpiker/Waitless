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

namespace Waitless
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ItemDefinitionController.CreateSerialization();
            ItemDefinitionController.InitializeItemDefinitions();
            CurrentUri = MenuCategories;
            TheFrame.NavigationService.Navigate(CurrentUri);
            CurrentButton = MenuButton;
            Back.IsEnabled = false;

            HackyCommunicationClass.registerMainWindow(this);
        }

        private Button PreviousButton;
        private Button CurrentButton;
        private Uri CurrentUri;
        private Uri PreviousUri;
        private Uri Cheque = new Uri("ChequePage.xaml", UriKind.Relative);
        private Uri Menu= new Uri("MenuPage.xaml", UriKind.Relative);
        private Uri Options = new Uri("OptionsPage.xaml", UriKind.Relative);
        private Uri MenuCategories = new Uri("CategoriesPage.xaml", UriKind.Relative);

        private void request_Click(object sender, RoutedEventArgs e)
        {
            request.Visibility = Visibility.Hidden;
            requested.Visibility = Visibility.Visible;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }
            
            private void timer_tick(object sender, EventArgs e)
        {
            requested.Visibility = Visibility.Hidden;
            request.Visibility = Visibility.Visible;

        }

        public void OnBackToCategoriesEvent()
        {
            Toggle(MenuCategories, MenuButton);
        }

        public void OnCategorySelected(string categoryName)
        {
            TheFrame.Navigate(new Uri("MenuPage.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Toggle(PreviousUri, PreviousButton);
            Back.IsEnabled = false;
        }

        private void ChequeButton_Click(object sender, RoutedEventArgs e)
        {
            Toggle(Cheque, ChequeButton);
            Back.IsEnabled = true;
        }

        private void Toggle(Uri uri, Button button)
        {
            PreviousUri = CurrentUri;
            PreviousButton = CurrentButton;
            CurrentButton = button;
            CurrentUri = uri;
            PreviousButton.IsEnabled = true;
            CurrentButton.IsEnabled = false;
            TheFrame.Navigate(CurrentUri);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Toggle(MenuCategories, MenuButton);
            Back.IsEnabled = true;
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            Toggle(Options, OptionsButton);
            Back.IsEnabled = true;
        }
    }



}


