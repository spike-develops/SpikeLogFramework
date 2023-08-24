
namespace SpikeLog
{
    public interface ISpikeLogger
    {
        void Debug(object message);

        void Info(object message);

        void Warn(object message);

        void Error(object message);
    }
}
