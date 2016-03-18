namespace EleReader
{
    public class NormalGraphicalElementData : GraphicalElementData
    {
        public NormalGraphicalElementData(int elementId, int elementType) : base(elementId, elementType)
        {
        }

        public int gfxId;
        public uint height;
        public bool horizontalSymmetry;
        public Point origin;
        public Point size;

        override public void fromRaw(ELEReader raw, int version)
        {
            this.gfxId = raw.ReadInt();
            this.height = raw.ReadByte();

            this.horizontalSymmetry = raw.ReadBool();

            this.origin = new Point(raw.ReadShort(), raw.ReadShort());

            this.size = new Point(raw.ReadShort(), raw.ReadShort());
        }
    }
}