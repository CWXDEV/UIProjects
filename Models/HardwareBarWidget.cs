using System.Windows;
using System.Windows.Controls;

namespace AIO.Models;

public class HardwareBarWidget : Control
{
	public static readonly DependencyProperty TempProperty =
		DependencyProperty.RegisterAttached("Temp", typeof(float), typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(default(float)));

	public static readonly DependencyProperty ClockProperty =
		DependencyProperty.RegisterAttached("Clock", typeof(float), typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(default(float)));

	public static readonly DependencyProperty PowerProperty =
		DependencyProperty.RegisterAttached("Power", typeof(float), typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(default(float)));

	public static readonly DependencyProperty LoadProperty =
		DependencyProperty.RegisterAttached("Load", typeof(float), typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(default(float)));

	public static readonly DependencyProperty TitleProperty =
		DependencyProperty.RegisterAttached("Title", typeof(string), typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(default(string)));

	static HardwareBarWidget()
	{
		DefaultStyleKeyProperty.OverrideMetadata(typeof(HardwareBarWidget),
			new FrameworkPropertyMetadata(typeof(HardwareBarWidget)));
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

	public string Title
	{
		get => (string) GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}
}