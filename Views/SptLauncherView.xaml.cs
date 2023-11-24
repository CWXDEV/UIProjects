using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace AIO.Views;

public partial class SptLauncherView : UserControl
{
	private Process? _sptProcess;
	public SptLauncherView()
	{
		InitializeComponent();
	}

	private async void StartSPT_OnClick(object sender, RoutedEventArgs e)
	{
		var path = "C:\\Programs\\SPT";

		_sptProcess = new Process();
		_sptProcess.StartInfo.FileName = Path.Combine(path, "Aki.Server.exe");
		_sptProcess.StartInfo.UseShellExecute = false;
		_sptProcess.StartInfo.RedirectStandardOutput = true;
		_sptProcess.StartInfo.RedirectStandardError = true;
		_sptProcess.StartInfo.CreateNoWindow = false;
		_sptProcess.StartInfo.WorkingDirectory = path;

		_sptProcess.OutputDataReceived += (o, args) =>
		{
			if (args.Data != null)
			{
				var outputText = ConvertAnsiColorCodes(args.Data);
				Dispatcher.Invoke(() =>
				{
					ConsoleOutput.AppendText(outputText + Environment.NewLine);
					ConsoleOutput.ScrollToEnd();
				});
			}
		};

		_sptProcess.ErrorDataReceived += (o, args) =>
		{
			if (args.Data != null)
			{
				var errorText = ConvertAnsiColorCodes(args.Data);
				Dispatcher.Invoke(() => { ConsoleOutput.AppendText(errorText + Environment.NewLine); });
			}
		};

		_sptProcess.Start();

		_sptProcess.BeginOutputReadLine();
		_sptProcess.BeginErrorReadLine();

		await Task.Run(() => _sptProcess.WaitForExit());

		if (_sptProcess != null)
		{
			var exitCode = _sptProcess?.ExitCode ?? 1;
			Console.WriteLine($"ExitCode: {exitCode}");
		}
	}

	private string ConvertAnsiColorCodes(string input)
	{
		return Regex.Replace(input, @"\u001b\[\d{1,2}m", string.Empty);
	}

	private void StopSPT_OnClick(object sender, RoutedEventArgs e)
	{
		if (_sptProcess != null && !_sptProcess.HasExited)
		{
			if (_sptProcess.CloseMainWindow())
			{
				_sptProcess.WaitForExit();
			}
			else
			{
				_sptProcess.Kill();
			}

			_sptProcess.Dispose();
			_sptProcess = null;
		}
	}
}