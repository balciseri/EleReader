namespace EleReader
{
    public class GraphicalElementData
    {

        public int id;
        public int type;

        public GraphicalElementData(int elementId, int elementType)
        {
            this.id = elementId;
            this.type = elementType;
        }

        public virtual void fromRaw(ELEReader reader, int version)
        {
            throw new System.FieldAccessException();
        }
    }
}