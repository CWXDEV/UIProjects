using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.SaveState;

namespace wpfAppMetro.Views;

public partial class SettingsView : UserControl
{
	public SaveStateModel? LocalSaveState;

	public SettingsView()
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		var localManager = LocalStorageManager.Instance;
		LocalSaveState = localManager.OpenJson();

		Console.WriteLine(JsonSerializer.Serialize(LocalSaveState));
	}
}