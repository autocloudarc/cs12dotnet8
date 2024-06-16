using System.Diagnostics; // To use the Debug and Trace classes
using Microsoft.Extensions.Configuration; // To use the IConfiguration interface ConfigurationBuilder
Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

#if DEBUG
// Text writer is buffered, so this option calls
// Flush() on all listeners after writing.
Trace.AutoFlush = true;
#endif // DEBUG

string settingsFile = "appsettings.json";
string settingsPath = Path.Combine(Environment.CurrentDirectory, settingsFile);
Console.WriteLine($"Reading from: {settingsPath}");
Console.WriteLine("--{0} contents--", settingsFile);
Console.WriteLine(File.ReadAllText(settingsPath));
Console.Write("----");

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());

// Add the settings file to the processed configuration
// and make it mandatory so an exception will be thrown if the file is not found.

builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(
    displayName: "PacktSwitch",
    description: "This switch is set via the configuration file.");

configuration.GetSection("PacktSwitch").Bind(ts);

Console.WriteLine($"TraceSwitch level: {ts.Value}");
Console.WriteLine($"TraceSwitch description: {ts.Level}");

Trace.WriteLineIf(ts.TraceError, "Trace error message.");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning message.");
Trace.WriteLineIf(ts.TraceInfo, "Trace info message.");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose message.");   

// Close the text file (also flushes) and release resources.
Debug.Close();
Trace.Close();

Console.WriteLine("Press enter to exit.");
Console.ReadLine();