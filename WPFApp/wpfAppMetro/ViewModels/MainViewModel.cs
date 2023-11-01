using wpfAppMetro.Core;

namespace wpfAppMetro.ViewModels;

public class MainViewModel : ObservableObject
{
    // new "page" add new RelayCommand, NewPageVM
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand Page2ViewCommand { get; set; }

    public HomeViewModel HomeVm { get; set; }
    public Page2ViewModel Page2Vm { get; set; }

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
        HomeVm = new HomeViewModel();
        Page2Vm = new Page2ViewModel();

        CurrentView = HomeVm;

        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });
        Page2ViewCommand = new RelayCommand(o => { CurrentView = Page2Vm; });
    }
}