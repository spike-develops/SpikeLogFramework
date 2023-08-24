namespace SpikeLog
{
    //if i reimplement compact logging this might be useful
    internal struct CompactLogData
    {
        public uint StartingFrame;
        public short LogCount;
        public uint LastLoggedFrame;

        internal CompactLogData(uint startingFrame, short logCount,uint lastLoggedFrame)
        {
            StartingFrame = startingFrame;
            LogCount = logCount;
            LastLoggedFrame = lastLoggedFrame;
        }
    }
}
