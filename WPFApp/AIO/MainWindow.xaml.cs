using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MahApps.Metro.Controls;

namespace wpfAppMetro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/CWXDEV/UIProjects/tree/main/WPFApp",
                UseShellExecute = true
            });
        }

        private void SideMenu_OnMouseEnter(object sender, MouseEventArgs e)
        {
            (SideMenu.Resources["OpenSideMenu"] as Storyboard).Begin();
        }
        
        private void SideMenu_OnMouseLeave(object sender, MouseEventArgs e)
        {
            (SideMenu.Resources["CloseSideMenu"] as Storyboard).Begin();
        }
    }
}