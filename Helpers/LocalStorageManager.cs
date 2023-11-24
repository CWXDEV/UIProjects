using System;
using System.IO;
using System.Text.Json;
using AIO.Models.SaveState;

namespace AIO.Helpers;

public class LocalStorageManager
{
	private static LocalStorageManager? _instance;
	private static readonly object Padlock = new();
	private readonly string _fileName = "SaveState.json";

	private readonly string _path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CWX-AIO");

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
			jsonString = JsonSerializer.Serialize(newDetails);
			File.WriteAllText(Path.Combine(_path, _fileName), jsonString);
		}
	}

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


	public void SaveJson(SaveStateModel saveState)
	{
		try
		{
			var newDetails = JsonSerializer.Serialize(saveState);
			File.WriteAllText(Path.Combine(_path, _fileName), newDetails);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public SaveStateModel? OpenJson()
	{
		try
		{
			var jsonString = File.ReadAllText(Path.Combine(_path, _fileName));
			return JsonSerializer.Deserialize<SaveStateModel>(jsonString);

		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	private SaveStateModel GenerateDefaults()
	{
		return new SaveStateModel
		{
			HardwareMonitorSave = new HardwareMonitorModel
			{
				Timer = 5
			},
			SptConfigSave = new[]
			{
				new SptLaunchConfigModel
				{
					Path = "1",
					LaunchServer = false
				},
				new SptLaunchConfigModel
				{
					Path = "2",
					LaunchServer = false
				}
			}
		};
	}
}