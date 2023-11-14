using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using LibreHardware_Helper;
using LibreHardware_Helper.Model.HardwareData.CPU;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Core;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

// TODO: Finish decision on design and how to store the data
public class HardwareMonitorViewModel : ObservableObject
{
	public HardwareMonitorViewModel()
	{
		AppStateManager.Instance.UpdateTimerDict
			.FirstOrDefault(x => x.Key == ETimer.Hardware.ToString()).Value.Elapsed += OnUpdate;

		TestWaffleTool();
	}

	public bool IsTempVisible { get; set; } = true;
	private bool WasTempChecked { get; set; }
	public ObservableCollection<CpuCore> CpuCores { get; set; } = new();

	public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
	{
		TestWaffleTool();
	}

	private void TestWaffleTool()
	{
		var test = new LibreHardwareHelper();
		var cpus = test.GetCpuCores().ToList();

		if (!WasTempChecked)
		{
			if (cpus[0].Temp == 0)
			{
				IsTempVisible = false;
				DisableTempCol();
			}

			WasTempChecked = true;
		}

		cpus.Sort((x, y) => x.Number.CompareTo(y.Number));

		Application.Current.Dispatcher.Invoke(() =>
		{
			CpuCores.Clear();

			foreach (var core in cpus)
			{
				CpuCores.Add(core);
			}
		});
	}

	private void DisableTempCol()
	{
		if (WasTempChecked && !IsTempVisible)
		{

			Application.Current.Dispatcher.Invoke(() =>
			{
				OnPropertyChanged("IsTempVisible");

			});
		}
	}
}