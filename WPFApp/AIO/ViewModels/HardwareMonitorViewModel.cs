using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Core;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

public class HardwareMonitorViewModel : ObservableObject
{
    private HardwareMonitorHelper _helper = null;
    public ObservableCollection<string> LoadSensors { get; set; } = new ObservableCollection<string>();
    
    // public ISensor? CPUload { get; set; }
    public HardwareMonitorViewModel()
    {
        _helper = HardwareMonitorHelper.Instance;
        // CPUload = _helper.GetCpu().Sensors.FirstOrDefault(x => x.SensorType is SensorType.Load);
        
        AppStateManager.Instance.UpdateTimerDict
            .FirstOrDefault(x => x.Key == ETimer.Hardware.ToString()).Value.Elapsed += OnUpdate;
        
        PopulateCpuContainer();
    }
    
    public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        PopulateCpuContainer();
        // OnPropertyChanged("LoadSensors");
    }

    public void PopulateCpuContainer()
    {
        var list = _helper.GetCpu().Sensors.Where(x => x.SensorType is SensorType.Load).ToList();

        LoadSensors.Clear();
        
        for (var i = 0; i < list.Count; i++)
        {
            LoadSensors.Add($"Cpu{i} Load: {list[i].Value}");
        }
    }
}