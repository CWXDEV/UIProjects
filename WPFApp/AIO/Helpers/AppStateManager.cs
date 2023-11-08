using System.Collections.Generic;
using System.Timers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.Helpers;

public class AppStateManager
{
	private static AppStateManager _instance;
	private static readonly object Padlock = new();

	public Dictionary<string, Timer> UpdateTimerDict = new();

	public AppStateManager()
	{
		UpdateTimerDict.Add(ETimer.Hardware.ToString(), new Timer(1000));
		UpdateTimerDict.Add(ETimer.App.ToString(), new Timer(5000));

		foreach (var timer in UpdateTimerDict) timer.Value.Start();
	}

	public static AppStateManager Instance
	{
		get
		{
			lock (Padlock)
			{
				if (_instance == null)
				{
					_instance = new AppStateManager();
				}

				return _instance;
			}
		}
	}

	public void UpdateTimerInterval(string key, int interval)
	{
		if (UpdateTimerDict.TryGetValue(key, out var timer))
		{
			timer.Interval = interval;
		}
	}
}