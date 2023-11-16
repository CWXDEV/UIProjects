using System.Windows;
using System.Windows.Controls;

namespace wpfAppMetro.Models;

public class HardwareWidget : Control
{
	public static readonly DependencyProperty TempProperty =
		DependencyProperty.Register("Temp", typeof(float), typeof(HardwareWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty ClockProperty =
		DependencyProperty.Register("Clock", typeof(float), typeof(HardwareWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty PowerProperty =
		DependencyProperty.Register("Power", typeof(float), typeof(HardwareWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty LoadProperty =
		DependencyProperty.Register("Load", typeof(float), typeof(HardwareWidget), new FrameworkPropertyMetadata((float) 0.0));

	public HardwareWidget()
	{
		DefaultStyleKeyProperty.OverrideMetadata(typeof(HardwareWidget), new FrameworkPropertyMetadata(typeof(HardwareWidget)));
	}

	public float Temp
	{
		get => (float) GetValue(TempProperty);
		set => SetValue(TempProperty, value);
	}

	public float Clock
	{
		get => (float) GetValue(ClockProperty);
		set => SetValue(ClockProperty, value);
	}

	public float Power
	{
		get => (float) GetValue(PowerProperty);
		set => SetValue(PowerProperty, value);
	}

	public float Load
	{
		get => (float) GetValue(LoadProperty);
		set => SetValue(LoadProperty, value);
	}
}