using System;
using System.Collections.Generic;

namespace SpikeLog
{
    public static class SpikeLoggerFactory
    {
        public static ISpikeLogger GetLogger(Type loggingType)
        {
            //TODO some sort of conditional logic if log4net exists?
            return new Log4netSpikeLogger(loggingType);
        }

        public static ISpikeLogger GetLogger(Type loggingType, object context)
        {
            return new Log4netSpikeLogger(loggingType, context);
        }

        public const string ContextObjKey = "ContextObj";
        private static List<LogContext> _contextPool = new List<LogContext>(1);

        //adds the object given to the Context objKey. usefull for 
        //allowing a log to know what object its about without actually being tied to it
        public static IDisposable AddLogContext(object context)
        {
            for (int i = 0; i < _contextPool.Count; i++)
            {
                //initialize and return the first uninitialized context
                if (!_contextPool[i].Initialized)
                {
                    _contextPool[i].InitializeContext(context);
                    return _contextPool[i];
                }
            }

            if (_contextPool.Count > 20)
            {
                throw new InvalidOperationException($"context pool isn't working as intended! shouldn't need {_contextPool.Count} logContext pools!");
            }
            //if we get to the end, make a new one, add it to the list, and intialize it
            var toAdd = new LogContext();
            toAdd.InitializeContext(context);
            _contextPool.Add(toAdd);
            return toAdd;
        }
    }
}
