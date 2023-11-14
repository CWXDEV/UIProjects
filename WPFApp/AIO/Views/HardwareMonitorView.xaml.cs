using System.Windows.Controls;
using wpfAppMetro.ViewModels;

namespace wpfAppMetro.Views;

public partial class HardwareMonitorView : UserControl
{
	public bool testing { get; set; }
	public HardwareMonitorView()
	{
		InitializeComponent();
	}
}