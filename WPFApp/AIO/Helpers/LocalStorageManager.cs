using System;
using System.IO;
using System.Text.Json;
using wpfAppMetro.Models.IO;

namespace wpfAppMetro.Helpers;

public class LocalStorageManager
{
    private static LocalStorageManager _instance = null;
    private static readonly object Padlock = new object();
    
    private string _path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CWX-AIO");
    private string _fileName = "SaveState.json";
    public static LocalStorageManager Instance
    {
        get
        {
            lock (Padlock)
            {
                if (_instance == null)
                {
                    _instance = new LocalStorageManager();
                }

                return _instance;
            }
        }
    }
    
    public LocalStorageManager()
    {
        var jsonString = "";

        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }

        if (!File.Exists(Path.Combine(_path, _fileName)))
        {
            var newDetails = GenerateDefaults();
            jsonString = JsonSerializer.Serialize<SaveStateModel>(newDetails);
            File.WriteAllText(Path.Combine(_path, _fileName), jsonString);
        }
    }


    public void SaveJson(SaveStateModel saveState)
    {
        try
        {
            var newDetails = JsonSerializer.Serialize<SaveStateModel>(saveState);
            File.WriteAllText(Path.Combine(_path, _fileName), newDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public SaveStateModel OpenJson()
    {
        try
        {
            var jsonString = File.ReadAllText(Path.Combine(_path, _fileName));
            var data = JsonSerializer.Deserialize<SaveStateModel>(jsonString);
            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SaveStateModel GenerateDefaults()
    {
        return new SaveStateModel()
        {
            HardwareMonitorSave = new HardwareMonitorModel()
            {
                Timer = 5
            }
        };
    }
}