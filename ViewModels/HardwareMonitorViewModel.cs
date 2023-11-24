using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using LibreHardware_Helper;
using LibreHardware_Helper.Model.HardwareData.CPU;
using LibreHardware_Helper.Model.HardwareData.GPU;
using LibreHardware_Helper.Model.HardwareData.Memory;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

public partial class HardwareMonitorViewModel : ObservableObject
{
	private LibreHardwareHelper _helper = new ();

	[ObservableProperty]
	private CpuData? _cpuData;

	[ObservableProperty]
	private GpuData? _gpuData;

	[ObservableProperty]
	private MemoryData? _ramData;

	[ObservableProperty]
	private string _physicalMemoryUsage = "";

	[ObservableProperty]
	private string _virtualMemoryUsage = "";

	public ObservableValue PhysicalCurrentValue { get; set; } = new ();

	public ObservableValue VirtualCurrentValue { get; set; } = new ();

	public IEnumerable<ISeries> PhysicalSeries { get; set; }

	public IEnumerable<ISeries> VirtualSeries { get; set; }

	public HardwareMonitorViewModel()
	{
		AppStateManager.Instance.UpdateTimerDict
			.FirstOrDefault(x => x.Key == ETimer.Hardware.ToString()).Value.Elapsed += OnUpdate;

		InitData();
	}

	public void OnUpdate(object? sender, ElapsedEventArgs elapsedEventArgs)
	{
		CpuData?.Update();
		GpuData?.Update();
		RamData?.Update();
		UpdateMemoryUsage();
	}

	private void InitData()
	{
		CpuData = _helper.GetCpuData();
		GpuData = _helper.GetGpuData();
		RamData = _helper.GetMemoryData();

		PhysicalSeries = GaugeGenerator.BuildSolidGauge(new GaugeItem(PhysicalCurrentValue, series =>
		{
			series.Fill = new SolidColorPaint(SKColors.YellowGreen);
			series.DataLabelsSize = 25;
			series.DataLabelsPaint = new SolidColorPaint(SKColors.White);
			series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
			series.InnerRadius = 50;
			series.DataLabelsFormatter = value => value.PrimaryValue.ToString("N0") + "%";
		}), new GaugeItem(GaugeItem.Background, series =>
		{
			series.InnerRadius = 50;
			series.Fill = new SolidColorPaint(new SKColor(100, 181, 246, 90));
		}));

		VirtualSeries = GaugeGenerator.BuildSolidGauge(new GaugeItem(VirtualCurrentValue, series =>
		{
			series.Fill = new SolidColorPaint(SKColors.YellowGreen);
			series.DataLabelsSize = 25;
			series.DataLabelsPaint = new SolidColorPaint(SKColors.White);
			series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
			series.InnerRadius = 50;
			series.DataLabelsFormatter = value => value.PrimaryValue.ToString("N0") + "%";
		}), new GaugeItem(GaugeItem.Background, series =>
		{
			series.InnerRadius = 50;
			series.Fill = new SolidColorPaint(new SKColor(100, 181, 246, 90));
		}));
	}

	private void UpdateMemoryUsage()
	{
		PhysicalMemoryUsage = $"{RamData?.AmountUsed:N2} / {RamData?.Total:N2} GB";
		VirtualMemoryUsage = $"{RamData?.VirtualAmountUsed:N2} / {RamData?.VirtualTotal:N2} GB";

		PhysicalCurrentValue.Value = (int) RamData?.PercentUsed;
		VirtualCurrentValue.Value = (int) RamData?.VirtualPercentUsed;
	}
}