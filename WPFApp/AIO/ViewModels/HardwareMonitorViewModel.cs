using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using LibreHardware_Helper;
using LibreHardware_Helper.Model.HardwareData.CPU;
using LibreHardwareMonitor.Hardware;
using wpfAppMetro.Core;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

// TODO: Finish decision on design and how to store the data
public partial class HardwareMonitorViewModel : ObservableObject
{
	public HardwareMonitorViewModel()
	{
		AppStateManager.Instance.UpdateTimerDict
			.FirstOrDefault(x => x.Key == ETimer.Hardware.ToString()).Value.Elapsed += OnUpdate;

		AddCoresToList();
	}

	[ObservableProperty]
	private Visibility _isTempVisible = Visibility.Visible;

	[ObservableProperty]
	private CpuData _cpuData;

	public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
	{
		CpuData.Update();
	}

	private void AddCoresToList()
	{
		var helper = new LibreHardwareHelper();
		CpuData = helper.GetCpuData();

		if (CpuData.Cores[0].Temp == 0)
		{
			IsTempVisible = Visibility.Hidden;
		}
	}
}