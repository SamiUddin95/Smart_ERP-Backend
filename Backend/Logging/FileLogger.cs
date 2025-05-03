using Microsoft.Extensions.Configuration;
using System.IO;
using System;

public class FileLogger
{
    private readonly string _logFilePath;

    public FileLogger(IConfiguration configuration)
    {
        _logFilePath = configuration["FileLogging:LogFilePath"];
    }

    public void LogError(string apiName,Exception ex)
    {
        try
        {
            string logDirectory = _logFilePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFilePath = Path.Combine(logDirectory, $"Log_{DateTime.Now:yyyyMMdd}.txt");

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("-------------------------------------------------------");
                writer.WriteLine($"Timestamp      : {DateTime.Now}");
                writer.WriteLine($"API Name       : {apiName}");
                writer.WriteLine($"Exception      : {ex.Message}");
                writer.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                writer.WriteLine("-------------------------------------------------------");
                writer.WriteLine();
            }
        }
        catch
        {
            // Silent fail
        }
    }
}
