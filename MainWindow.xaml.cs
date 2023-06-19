using Multiple_Views;
using Multiple_Views.Pages;
using Multiple_Views.Views;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /* Start: Page jump */
        private void rdHome_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Home());
        }

        private void rdAnalytics_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Analytics());
        }

        private void rdMessages_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Messages());
        }

        private void rdCollections_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Collections());
        }

        private void rdUsers_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Users());
        }

        private void rdNotifications_Click(object sender, RoutedEventArgs e) {

        }
        private void rdSettings_Click(object sender, RoutedEventArgs e) {
            frameContent.Navigate(new Setting());
        }
        /* End: Page jump */

        private void Themes_Click(object sender, RoutedEventArgs e) {
            if (Themes.IsChecked == true) {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            } else {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            }
        }

        private void rdHome_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdAnalytics_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdMessages_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdCollections_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdUsers_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdNotifications_Checked(object sender, RoutedEventArgs e) {

        }

        private void rdSettings_Checked(object sender, RoutedEventArgs e) {

        }

        private void Themes_Checked(object sender, RoutedEventArgs e) {

        }

        /* ===== Window Settings ===== */
        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e) {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }


        private void btnRestore_Click2(object sender, RoutedEventArgs e) {
            if (WindowState == WindowState.Normal) {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 1.0;
                animation.To = 0.0;
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                animation.Completed += (s, _) =>
                {
                    WindowState = WindowState.Maximized;
                    DoubleAnimation restoreAnimation = new DoubleAnimation();
                    restoreAnimation.From = 0.0;
                    restoreAnimation.To = 1.0;
                    restoreAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                    BeginAnimation(OpacityProperty, restoreAnimation);
                };
                BeginAnimation(OpacityProperty, animation);
            } else {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 1.0;
                animation.To = 0.0;
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                animation.Completed += (s, _) =>
                {
                    WindowState = WindowState.Normal;
                    DoubleAnimation restoreAnimation = new DoubleAnimation();
                    restoreAnimation.From = 0.0;
                    restoreAnimation.To = 1.0;
                    restoreAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                    BeginAnimation(OpacityProperty, restoreAnimation);
                };
                BeginAnimation(OpacityProperty, animation);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                DragMove();
            }
        }
    }
}
