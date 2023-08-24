using log4net.Core;
using System;
using System.Reflection;

namespace SpikeLog
{
    internal class Log4netSpikeLogger : ISpikeLogger
    {
        readonly Type _type;
        private readonly ILogger _logger;

        private bool _contextAllowed;
        private object _contextObj;

        public Log4netSpikeLogger(Type loggingType, object contextObj):this(loggingType)
        {
            _contextObj = contextObj;
            _contextAllowed = _contextObj != null;
        }

        public Log4netSpikeLogger(Type loggingType)
        {
            _type = loggingType;
            _logger = LoggerManager.GetLogger(Assembly.GetCallingAssembly(), loggingType);
        }

        public void Debug(object message)
        {
            if (_logger.IsEnabledFor(Level.Debug))
            {
                LogEvent(message, Level.Debug);
            }
        }

        public void Info(object message)
        {
            if (_logger.IsEnabledFor(Level.Info))
            {
                LogEvent(message, Level.Info);
            }
        }

        public void Warn(object message)
        {
            if (_logger.IsEnabledFor(Level.Warn))
            {
                LogEvent(message, Level.Warn);
            }
        }

        public void Error(object message)
        {
            if (_logger.IsEnabledFor(Level.Error))
            {
                LogEvent(message, Level.Error);
            }
        }

        private void LogEvent(object message, Level lvl)
        {
            var evt = new LoggingEvent(typeof(ISpikeLogger), _logger.Repository, _logger.Name, lvl, message, null);
            if (_contextAllowed)
            {
                evt.Properties[SpikeLoggerFactory.ContextObjKey] = _contextObj;
            }
            _logger.Log(evt);
        }
    }
}
