namespace EleReader
{
    internal class ParticlesGraphicalElementData : GraphicalElementData
    {
        public ParticlesGraphicalElementData(int elementId, int elementType) : base(elementId, elementType)
        {
        }
        public int scriptId;

        override public void fromRaw(ELEReader raw, int version)
        {
            this.scriptId = (int)raw.ReadShort();
        }
    }
}