using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;

namespace AIO.Models;

public class HardwareRadialWidget : Control
{
	public static readonly DependencyProperty SeriesProperty = DependencyProperty.RegisterAttached("Series", typeof(IEnumerable<ISeries>),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(IEnumerable<ISeries>)));

	public static readonly DependencyProperty InitialRotationProperty = DependencyProperty.RegisterAttached("InitialRotation", typeof(double),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(double)));

	public static readonly DependencyProperty MaxAngleProperty = DependencyProperty.RegisterAttached("MaxAngle", typeof(double),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(double)));

	public static readonly DependencyProperty MinValueProperty = DependencyProperty.RegisterAttached("MinValue", typeof(double),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(double)));

	public static readonly DependencyProperty MaxValueProperty = DependencyProperty.RegisterAttached("MaxValue", typeof(double),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(double)));

	public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title", typeof(string),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(string)));

	public static readonly DependencyProperty MemoryUsageProperty = DependencyProperty.RegisterAttached("MemoryUsage", typeof(string),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(default(string)));

	static HardwareRadialWidget()
	{
		DefaultStyleKeyProperty.OverrideMetadata(typeof(HardwareRadialWidget),
			new FrameworkPropertyMetadata(typeof(HardwareRadialWidget)));
	}

	public float Series
	{
		get => (float) GetValue(SeriesProperty);
		set => SetValue(SeriesProperty, value);
	}

	public double InitialRotation
	{
		get => (double) GetValue(InitialRotationProperty);
		set => SetValue(InitialRotationProperty, value);
	}

	public double MaxAngle
	{
		get => (double) GetValue(MaxAngleProperty);
		set => SetValue(MaxAngleProperty, value);
	}

	public double MinValue
	{
		get => (double) GetValue(MinValueProperty);
		set => SetValue(MinValueProperty, value);
	}

	public double MaxValue
	{
		get => (double) GetValue(MaxValueProperty);
		set => SetValue(MaxValueProperty, value);
	}

	public string Title
	{
		get => (string) GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string MemoryUsage
	{
		get => (string) GetValue(MemoryUsageProperty);
		set => SetValue(MemoryUsageProperty, value);
	}

}