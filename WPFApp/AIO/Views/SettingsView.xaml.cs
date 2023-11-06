using System;
using System.Windows;
using System.Windows.Controls;
using wpfAppMetro.Helpers;
using wpfAppMetro.Models.IO;

namespace wpfAppMetro.Views;

public partial class SettingsView : UserControl
{
    public SaveStateModel LocalSaveState;
    public SettingsView()
    {
        InitializeComponent();
    }
    
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var localManager = LocalStorageManager.Instance;
        LocalSaveState = localManager.OpenJson();
        
        Console.WriteLine(LocalSaveState.HardwareMonitorSave.Timer);
    }
}