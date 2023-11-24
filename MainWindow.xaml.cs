using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;

namespace AIO;

/// <summary>
///     Interaction logic for MainWindow.xaml
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
			FileName = "https://github.com/CWXDEV/UIProjects/tree/main",
			UseShellExecute = true
		});
	}

	private void SideMenu_OnMouseEnter(object sender, MouseEventArgs e)
	{
		(SideMenu.Resources["OpenSideMenu"] as Storyboard)?.Begin();
	}

	private void SideMenu_OnMouseLeave(object sender, MouseEventArgs e)
	{
		(SideMenu.Resources["CloseSideMenu"] as Storyboard)?.Begin();
	}
}