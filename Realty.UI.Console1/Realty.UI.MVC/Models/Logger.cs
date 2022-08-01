using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Realty.UI.MVC.Models
{
    public class Logger : Serilog.ILogger
    {

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }

        public void Write(LogEvent logEvent)
        {

        }
    }
}
