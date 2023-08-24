using log4net;
using System;

namespace SpikeLog
{
    internal class LogContext : IDisposable
    {
        public bool Initialized { get; private set; }
        public void InitializeContext(object context)
        {
            ThreadContext.Properties[SpikeLoggerFactory.ContextObjKey] = context;
            Initialized = true;
        }

        public void Dispose()
        {
            //this might work correctly?
            ThreadContext.Properties.Remove(SpikeLoggerFactory.ContextObjKey);
            Initialized = false;
        }
    }
}
