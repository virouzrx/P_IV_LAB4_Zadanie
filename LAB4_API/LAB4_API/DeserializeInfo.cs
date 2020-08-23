using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAB4_API
{
    class DeserializeInfo
    {
        public static async Task<string> _deserializeAdvancedInfo(string _conferenceName)
        {
            List<Advanced> lista = new List<Advanced>();

            var downloadedAdvancedData = await APIActions.DownloadToAdvanced();
            var deserializeAdvancedData = JsonSerializer.Deserialize<Advanced[]>(downloadedAdvancedData, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var item in deserializeAdvancedData)
            {
                lista.Add(new Advanced
                {
                    Team = item.Team,
                    Conference = item.Conference,
                    Mascot = item.Mascot,
                });
            }
            return lista.Where(x => x.Conference == _conferenceName)
                                     .Select(x => x.Team)
                                     .FirstOrDefault();
        }
    }
}
