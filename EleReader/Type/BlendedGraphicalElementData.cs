namespace EleReader
{
    internal class BlendedGraphicalElementData : NormalGraphicalElementData
    {
        public BlendedGraphicalElementData(int elementId, int elementType) : base(elementId, elementType)
        {
        }


        public string blendMode;

        override public void fromRaw(ELEReader raw, int version)
        {
            uint blendModeLength = (uint)raw.ReadInt();
            this.blendMode = raw.ReadAscii((int)blendModeLength);
        }
    }
}

