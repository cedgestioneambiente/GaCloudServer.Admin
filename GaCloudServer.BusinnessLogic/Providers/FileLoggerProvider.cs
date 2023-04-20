using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Providers
{
    public class FileLoggerProvider:ILoggerProvider
    {
        private readonly string _logFilePath;

        public FileLoggerProvider(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_logFilePath);
        }

        public void Dispose()
        {
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                string message = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")} [{logLevel}] {formatter(state, exception)}{Environment.NewLine}";

                if (!Directory.Exists(Path.GetDirectoryName(_logFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
                }

                if (!File.Exists(_logFilePath))
                {
                    using (StreamWriter writer = File.CreateText(_logFilePath))
                    {
                        writer.WriteLine(message);
                    }
                }
                else
                {
                    File.AppendAllText(_logFilePath, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Directory not found: " + ex.Message);
            }
        }
    }
}
