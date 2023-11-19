using System;
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
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.ViewModels;

public partial class HardwareMonitorViewModel : ObservableObject
{
	[ObservableProperty]
	private CpuData? _cpuData;

	[ObservableProperty]
	private GpuData? _gpuData;

	[ObservableProperty]
	private MemoryData? _ramData;

	public PathGeometry PhysicalMemoryGeometry
	{
		get => CalculateArcGeometry(_ramData.PercentUsed);
	}

	private PathGeometry CalculateArcGeometry(float percentUsed)
	{
		var min = 0; // Assuming minimum is 0
		var max = 100; // Assuming maximum is 100
		var range = max - min;
		var normalizedValue = (percentUsed - min) / range;
		var angle = normalizedValue * 360;

		// Convert degrees to radians
		var radians = angle * Math.PI / 180;

		// Assuming the radial control has a fixed size, e.g., 100x100
		var radius = 50; // Radius of the circle
		var startPoint = new Point(radius, 0); // Start point at the top center

		// Calculate the end point
		var endPointX = radius + radius * Math.Sin(radians);
		var endPointY = radius - radius * Math.Cos(radians);
		var endPoint = new Point(endPointX, endPointY);

		// Determine if it's a large arc
		var isLargeArc = angle > 180.0;

		// Create the arc segment
		var arcSegment = new ArcSegment
		{
			Point = endPoint,
			Size = new Size(radius, radius),
			IsLargeArc = isLargeArc,
			SweepDirection = SweepDirection.Clockwise
		};

		// Create the path figure
		var pathFigure = new PathFigure
		{
			StartPoint = startPoint,
			IsClosed = false
		};
		pathFigure.Segments.Add(arcSegment);

		// Create the path geometry
		var pathGeometry = new PathGeometry();
		pathGeometry.Figures.Add(pathFigure);

		return pathGeometry;
	}


	private LibreHardwareHelper _helper = new();

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
		OnPropertyChanged(nameof(PhysicalMemoryGeometry));
	}

	private void InitData()
	{
		CpuData = _helper.GetCpuData();
		GpuData = _helper.GetGpuData();
		RamData = _helper.GetMemoryData();

	}
}