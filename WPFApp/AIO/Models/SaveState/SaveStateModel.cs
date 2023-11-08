namespace wpfAppMetro.Models.SaveState;

public class SaveStateModel
{
	public HardwareMonitorModel? HardwareMonitorSave { get; set; }
	public SptLaunchConfigModel[]? SptConfigSave { get; set; }
}