namespace Pyrogenesis.Pmp.Parser
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Program
    {
        private const string m_MapsLocationUser = "C:/Dev/perso/0ad/binaries/data/mods/public/maps";
        private static void Main(string[] args)
        {
            IEnumerable<string> maps = Directory.GetFiles(m_MapsLocationUser, "*.pmp", SearchOption.AllDirectories);
            Parallel.ForEach(maps, map =>
            {
                string mapPath = map.Replace("\\", "/");
                var pmpMap = new PmpMap(mapPath);
                if (pmpMap.Header.terrain_textures.Any(a => a.Contains(" ")))
                {
                    Console.WriteLine(mapPath);
                    Console.WriteLine(JsonConvert.SerializeObject(pmpMap.Header.terrain_textures, Formatting.Indented));
                }
            });
        }
    }
}
