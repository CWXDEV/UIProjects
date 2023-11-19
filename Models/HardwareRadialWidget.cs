using System.Windows;
using System.Windows.Controls;

namespace wpfAppMetro.Models;

public class HardwareRadialWidget : Control
{
	public static readonly DependencyProperty MinProperty = DependencyProperty.RegisterAttached("Min", typeof(float),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty CurrentProperty = DependencyProperty.RegisterAttached("Current", typeof(float),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty MaxProperty = DependencyProperty.RegisterAttached("Max", typeof(float),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata((float) 0.0));

	public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title", typeof(string),
		typeof(HardwareRadialWidget), new FrameworkPropertyMetadata(""));

	public HardwareRadialWidget()
	{
		DefaultStyleKeyProperty.OverrideMetadata(typeof(HardwareRadialWidget),
			new FrameworkPropertyMetadata(typeof(HardwareRadialWidget)));
	}

	public float Min
	{
		get => (float) GetValue(MinProperty);
		set => SetValue(MinProperty, value);
	}

	public float Current
	{
		get => (float) GetValue(CurrentProperty);
		set => SetValue(CurrentProperty, value);
	}

	public float Max
	{
		get => (float) GetValue(MaxProperty);
		set => SetValue(MaxProperty, value);
	}

	public string Title
	{
		get => (string) GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}
}