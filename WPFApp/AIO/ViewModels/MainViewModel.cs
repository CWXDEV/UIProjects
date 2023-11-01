using wpfAppMetro.Core;

namespace wpfAppMetro.ViewModels;

public class MainViewModel : ObservableObject
{
    // new "page" add new RelayCommand, NewPageVM
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand HardwareMonitorViewCommand { get; set; }
    public RelayCommand SettingsViewCommand { get; set; }

    public HomeViewModel HomeVm { get; set; }
    public HardwareMonitorViewModel HardwareMonitorVm { get; set; }
    public SettingsViewModel SettingsVm { get; set; }

    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    // new "page" instantiate Model, Instantiate Relay
    public MainViewModel()
    {
        // ViewModels
        HomeVm = new HomeViewModel();
        HardwareMonitorVm = new HardwareMonitorViewModel();
        SettingsVm = new SettingsViewModel();

        // RelayCommands
        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });
        HardwareMonitorViewCommand = new RelayCommand(o => { CurrentView = HardwareMonitorVm; });
        SettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsVm; });
        
        CurrentView = HomeVm;
    }
}