using System;
using System.Linq;
using System.Timers;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Models.Enum;
using wpfAppMetro.Models.HW;

namespace wpfAppMetro.Helpers;

public class HardwareMonitorHelper
{
    private static HardwareMonitorHelper _instance = null;
    private static readonly object Padlock = new object();
    private Computer _computer = null;
    public bool Enabled = false;

    public static HardwareMonitorHelper Instance
    {
        get
        {
            lock (Padlock)
            {
                if (_instance == null)
                {
                    _instance = new HardwareMonitorHelper();
                }

                return _instance;
            }
        }
    }

    public HardwareMonitorHelper()
    {
        _computer = new Computer()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsStorageEnabled = true,
            IsControllerEnabled = true,
            IsNetworkEnabled = true,
            IsBatteryEnabled = true,
            IsPsuEnabled = true
        };

        _computer.Open();
        _computer.Accept(new UpdateVisitor());
        Enabled = true;

        AppStateManager.Instance.UpdateTimerDict
            .FirstOrDefault(x => x.Key == ETimer.Hardware.ToString())
            .Value.Elapsed += OnUpdate;
    }

    public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        if (_instance == null || !Enabled) return;

        _instance.UpdateHardware();
    }

    public IHardware? GetCpu()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Cpu);
    }

    public IHardware? GetGpu()
    {
        return _computer?.Hardware.FirstOrDefault(x =>
            x.HardwareType is HardwareType.GpuNvidia or HardwareType.GpuAmd or HardwareType.GpuIntel);
    }

    public IHardware? GetMemory()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Memory);
    }

    public IHardware? GetMotherboard()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Motherboard);
    }

    public IHardware? GetStorage()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Storage);
    }

    public IHardware? GetControllers()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.EmbeddedController);
    }

    public IHardware? GetNetwork()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Network);
    }

    public IHardware? GetBattery()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Battery);
    }

    public IHardware? GetPsu()
    {
        return _computer?.Hardware.FirstOrDefault(x => x.HardwareType is HardwareType.Psu);
    }

    public void UpdateHardware()
    {
        foreach (var hardware in _computer.Hardware)
        {
            hardware.Update();
        }
    }
}