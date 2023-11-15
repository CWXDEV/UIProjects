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

	public static void SetIcon(UIElement element, PackIconModernKind value)
	{
		element.SetValue(IconProperty, value);
	}

	public static PackIconModernKind GetIcon(UIElement element)
	{
		return (PackIconModernKind) element.GetValue(IconProperty);
	}
}