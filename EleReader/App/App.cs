using System.Collections.Generic;
using System.IO;
using Ionic.Zlib;
namespace EleReader
{
    public class App
    {
        int fileVersion;
        ELEReader reader;
        Dictionary<int, GraphicalElementData> elementsMap = new Dictionary<int, GraphicalElementData>();
        Dictionary<int, int> elementsIndex = new Dictionary<int, int>();
        Dictionary<int, bool> jpgMap;

        public App(string eleFilePath)
        {

            byte[] compressedELEFileBytes = File.ReadAllBytes(eleFilePath);
            byte[] uncompressedELEFileBytes = ZlibStream.UncompressBuffer(compressedELEFileBytes);

            using (MemoryStream eleFile = new MemoryStream(uncompressedELEFileBytes))
            using (reader = new ELEReader(eleFile))
            {
                int header;
                int skypLen;
                int i;
                int edId;
                int gfxCount;
                int gfxId;

                header = reader.ReadByte();
                if (header != 69)
                {
                    throw new InvalidDataException();
                }
              
                fileVersion = reader.ReadByte();
                uint elementsCount = reader.ReadUInt();
                
                skypLen = 0;
                i = 0;
                while (i < elementsCount)
                {
                    if (fileVersion >= 9)
                    {
                        skypLen = reader.ReadUShort();
                    }

                    edId = reader.ReadInt();

                    if (fileVersion <= 8)
                    {
                        elementsIndex[edId] = reader.Pointer;
                        readElement((uint)edId);
                    }
                    else
                    {
                        elementsIndex[edId] = reader.Pointer;
                        reader.Pointer = (reader.Pointer+ (skypLen - 4));
                    }
                    i = (i + 1);
                }

                if (fileVersion >= 8)
                {
                    gfxCount = reader.ReadInt();
                    jpgMap = new Dictionary<int, bool>();
                    i = 0;
                    while (i < gfxCount)
                    {
                        gfxId = reader.ReadInt();
                        jpgMap[gfxId] = true;
                        i = (i + 1);
                    }
                }
            }
        }

        private GraphicalElementData readElement(uint edId)
        {
            reader.Pointer = elementsIndex[(int)edId];
            int edType = reader.ReadByte();
            GraphicalElementData ed = GraphicalElementFactory.getGraphicalElementData((int)edId, edType);
            if (ed == null)
            {
                return (null);
            }
            ed.fromRaw(reader, fileVersion);
            elementsMap[(int)edId] = ed;

            return (ed);
        }
    }
}

