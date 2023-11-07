using System;
using System.Collections.Generic;
using System.Timers;
using wpfAppMetro.Models.Enum;

namespace wpfAppMetro.Helpers;

public class AppStateManager
{
    private static AppStateManager _instance = null;
    private static readonly object Padlock = new object();

    public Dictionary<string, Timer> UpdateTimerDict = new Dictionary<string, Timer>();

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

    public AppStateManager()
    {
        UpdateTimerDict.Add(ETimer.Hardware.ToString(), new Timer(1000));
        UpdateTimerDict.Add(ETimer.App.ToString(), new Timer(5000));
        
        foreach (var timer in UpdateTimerDict)
        {
            timer.Value.Start();
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