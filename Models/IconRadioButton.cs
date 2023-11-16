using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace wpfAppMetro.Models;

public class IconRadioButton : RadioButton
{
	public static readonly DependencyProperty IconProperty =
		DependencyProperty.RegisterAttached("Icon", typeof(PackIconModernKind), typeof(IconRadioButton));

	static IconRadioButton()
	{
		DefaultStyleKeyProperty.OverrideMetadata(typeof(IconRadioButton), new FrameworkPropertyMetadata(typeof(IconRadioButton)));
	}

	public PackIconModernKind Icon
	{
		get => (PackIconModernKind) GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}
}