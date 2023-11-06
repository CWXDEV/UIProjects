using System.Linq;
using System.Timers;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Core;
using wpfAppMetro.Helpers;

namespace wpfAppMetro.ViewModels;

public class HardwareMonitorViewModel : ObservableObject
{
    private HardwareMonitorHelper _hwInstance = null;
    private Timer _timer = null;
    public bool Enabled = false;
    
    public int HwTimer = 1000;
    public float? CpuLoad { get; set; }
    public float? GpuLoad { get; set; }
    
    public HardwareMonitorViewModel()
    {
        _hwInstance = HardwareMonitorHelper.Instance;
        Enabled = true;
        Start();
    }

    public void Start()
    {
        _timer = new Timer();
        _timer.Interval = HwTimer;
        _timer.Elapsed += OnUpdate;
        _timer.Start();
    }

    public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        if (_hwInstance == null || !Enabled) return;
        
        _hwInstance.UpdateHardware();
        CpuLoad = _hwInstance.GetCpu().Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load).Value;
        GpuLoad = _hwInstance.GetGpu().Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load).Value;
        OnPropertyChanged("CpuLoad");
        OnPropertyChanged("GpuLoad");
    }

    public void End()
    {
        _timer.Stop();
        Enabled = false;
    }
}