namespace EleReader
{
    internal class EntityGraphicalElementData : GraphicalElementData
    {
        public EntityGraphicalElementData(int elementId, int elementType) : base(elementId, elementType)
        {
        }

        public string entityLook;
        public bool horizontalSymmetry;
        public bool playAnimation;
        public bool playAnimStatic;
        public uint minDelay;
        public uint maxDelay;

        override public void fromRaw(ELEReader raw, int version)
        {
            uint entityLookLength = (uint)raw.ReadInt();
            this.entityLook = raw.ReadAscii((int)entityLookLength);

            this.horizontalSymmetry = raw.ReadBool();

            if (version >= 7)
            {
                this.playAnimation = raw.ReadBool();

            }
            if (version >= 6)
            {
                this.playAnimStatic = raw.ReadBool();

            }
            if (version >= 5)
            {
                this.minDelay = (uint)raw.ReadInt();

                this.maxDelay = (uint)raw.ReadInt();
            }
        }
    }
}
