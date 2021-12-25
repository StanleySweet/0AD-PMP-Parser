namespace Pyrogenesis.Pmp.Parser
{
    using System.IO;

    /// <summary>
    /// Defines the map file's PMP header.
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Creates an new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="binReader"></param>
        public Header(BinaryReader binReader)
        {
            magic = binReader.ReadChars(4);
            version = binReader.ReadUInt32();
            data_size = binReader.ReadUInt32();
            map_size = binReader.ReadUInt32();
            var v = map_size * 16 + 1;
            var heightmapsize = v * v;
            heightmap = new ushort[heightmapsize];
            for (var i = 0; i < heightmapsize; i++)
            {
                heightmap[i] = binReader.ReadUInt16();
            }
            num_terrain_textures = binReader.ReadUInt32();
            terrain_textures = new string[num_terrain_textures];
            for (var i = 0; i < num_terrain_textures; i++)
            {
                var length = binReader.ReadUInt32();
                terrain_textures[i] = string.Intern(new string((binReader.ReadChars((int)length))));
            }

            var v1 = map_size * map_size;
            patches = new Patch[v1];
            for (var i = 0; i < v1; i++)
            {
                patches[i] = new Patch(binReader);
            }

        }


        public char[] magic { get; set; }
        public uint version { get; set; }
        public uint data_size { get; set; }
        public uint map_size { get; set; }
        public ushort[] heightmap { get; set; }
        public uint num_terrain_textures { get; set; }
        public string[] terrain_textures { get; set; }
        public Patch[] patches { get; set; }
    }
}
