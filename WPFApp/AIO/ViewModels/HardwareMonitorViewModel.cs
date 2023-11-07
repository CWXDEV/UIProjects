using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Core;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

// TODO: Finish decision on design and how to store the data
public class HardwareMonitorViewModel : ObservableObject
{
    private HardwareMonitorHelper _helper;
    public ObservableCollection<ISensor> LoadSensors { get; set; } = new ObservableCollection<ISensor>();

    public HardwareMonitorViewModel()
    {
        _helper = HardwareMonitorHelper.Instance;

        AppStateManager.Instance.UpdateTimerDict
            .FirstOrDefault(x => x.Key == ETimer.Hardware.ToString()).Value.Elapsed += OnUpdate;
        
        PopulateCpuContainer();
    }

    public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        PopulateCpuContainer();
    }

    public void PopulateCpuContainer()
    {
        var list = _helper.GetCpu()?.Sensors.Where(x => x.SensorType is SensorType.Load).OrderBy(x => x.Index).ToList();
        var cpu = _helper.GetCpu();

        Application.Current.Dispatcher.Invoke(() =>
        {
            LoadSensors.Clear();

            for (var i = 0; i < list?.Count; i++)
            {
                LoadSensors.Add(list[i]);
            }
        });
    }
}