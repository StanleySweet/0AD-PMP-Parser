namespace Pyrogenesis.Pmp.Parser
{
    using System.IO;

    /// <summary>
    /// Define a map terrain patch.
    /// </summary>
    public class Patch
    {
        private const int tileSize = 16 * 16;

        /// <summary>
        /// Creates an new instance of the <see cref="Patch"/> class.
        /// </summary>
        /// <param name="binReader"></param>
        public Patch(BinaryReader binReader)
        {
            tiles = new Tile[tileSize];
            for (int i = 0; i < tileSize; i++)
            {
                tiles[i] = new Tile(binReader);
            }
        }

        public Tile[] tiles { get; set; }

    }
}
