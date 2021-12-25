namespace Pyrogenesis.Pmp.Parser
{
    using System.IO;

    public class Tile
    {
        /// <summary>
        /// Creates an new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="binReader"></param>
        public Tile(BinaryReader binReader)
        {
            texture1 = binReader.ReadUInt16();
            texture2 = binReader.ReadUInt16();
            priority = binReader.ReadUInt32();
        }

        public ushort texture1 { get; set; } // index into terrain_textures[]
        public ushort texture2 { get; set; }  // index, or 0xFFFF for 'none'
        public uint priority { get; set; }  // Used for blending between edges of tiles with different textures. A higher priority is blended on top of a lower priority.
    }
}
