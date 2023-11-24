using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using AIO.Helpers;
using AIO.Models.SaveState;

namespace AIO.Views;

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