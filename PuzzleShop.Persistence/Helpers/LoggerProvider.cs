using System;
using Microsoft.Extensions.Logging;

namespace PuzzleShop.Persistance.Helpers
{
    public class LoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }
        
        private class MyLogger : ILogger {
            public IDisposable BeginScope<TState>(TState state) {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel) {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
                Exception exception, Func<TState, Exception, string> formatter) {
                Console.WriteLine(formatter(state, exception));
            }
        }
    }
}