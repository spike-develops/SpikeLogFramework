using System;
using System.Collections.Generic;
using System.Text;

namespace SpikeLog
{
    internal class DummySpikeLogger : ISpikeLogger
    {
        public void Debug(object message) { }
        public void Info(object message) { }
        public void Warn(object message) { }
        public void Error(object message) { }


    }
}
