namespace EleReader
{
    public class AnimatedGraphicalElementData : NormalGraphicalElementData
    {
        public AnimatedGraphicalElementData(int elementId, int elementType) : base(elementId, elementType)
        {

        }
        public uint minDelay;
        public uint maxDelay;

        override public void fromRaw(ELEReader raw, int version)
        {
            if (version == 4)
            {
                this.minDelay = (uint)raw.ReadInt();

                this.maxDelay = (uint)raw.ReadInt();
            }
        }
    }
}