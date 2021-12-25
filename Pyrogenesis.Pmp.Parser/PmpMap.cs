using System.IO;

namespace Pyrogenesis.Pmp.Parser
{
    public class PmpMap
    {
        /// <summary>
        /// Creates an new instance of the <see cref="PmpMap"/> class.
        /// </summary>
        /// <param name="mapPath"></param>
        public PmpMap(string mapPath)
        {
            if (string.IsNullOrWhiteSpace(mapPath))
            {
                throw new System.ArgumentException($"'{nameof(mapPath)}' cannot be null or whitespace.", nameof(mapPath));
            }

            using (var binReader = new BinaryReader(File.Open(mapPath, FileMode.Open)))
            {
                this.Header = new Header(binReader);
            }
        }

        public Header Header { get; set; }
    }
}
