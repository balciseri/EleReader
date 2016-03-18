namespace EleReader
{
    public class GraphicalElementFactory
    {
        public static GraphicalElementData getGraphicalElementData(int elementId, int elementType)
        {
            switch ((uint)elementType)
            {
                case GraphicalElementTypes.NORMAL:
                    return (new NormalGraphicalElementData(elementId, elementType));
                case GraphicalElementTypes.BOUNDING_BOX:
                    return (new BoundingBoxGraphicalElementData(elementId, elementType));
                case GraphicalElementTypes.ANIMATED:
                    return (new AnimatedGraphicalElementData(elementId, elementType));
                case GraphicalElementTypes.ENTITY:
                    return (new EntityGraphicalElementData(elementId, elementType));
                case GraphicalElementTypes.PARTICLES:
                    return (new ParticlesGraphicalElementData(elementId, elementType));
                case GraphicalElementTypes.BLENDED:
                    return (new BlendedGraphicalElementData(elementId, elementType));
            }
            return (null);
        }

    }
}