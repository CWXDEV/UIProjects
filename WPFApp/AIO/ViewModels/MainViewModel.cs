using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using wpfAppMetro.Views;

namespace wpfAppMetro.ViewModels;

public partial class MainViewModel : ObservableObject
{
	// new "page" instantiate Model, Instantiate Relay
	public MainViewModel()
	{
		// ViewModels
		HomeV = new HomeView();
		HardwareMonitorV = new HardwareMonitorView();
		SettingsV = new SettingsView();
		SptLauncherV = new SptLauncherView();

		// RelayCommands
		HomeViewCommand = new RelayCommand(() => { CurrentView = HomeV; });
		HardwareMonitorViewCommand = new RelayCommand(() => { CurrentView = HardwareMonitorV; });
		SettingsViewCommand = new RelayCommand(() => { CurrentView = SettingsV; });
		SptLauncherViewCommand = new RelayCommand(() => { CurrentView = SptLauncherV; });

		CurrentView = HomeV;
	}

	[ObservableProperty]
	private object _currentView;

	// new "page" add new RelayCommand, NewPageVM
	public ICommand HomeViewCommand { get; set; }
	public ICommand HardwareMonitorViewCommand { get; set; }
	public ICommand SettingsViewCommand { get; set; }
	public ICommand SptLauncherViewCommand { get; set; }

	public HomeView HomeV { get; set; }
	public HardwareMonitorView HardwareMonitorV { get; set; }
	public SettingsView SettingsV { get; set; }
	public SptLauncherView SptLauncherV { get; set; }
}