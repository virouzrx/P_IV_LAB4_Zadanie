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
        //wstawka tutaj:
        public static async Task<List<string>> GetAdvancedDataForEachTeamAsync()
        {
            var teams = await APIActions.GetTeamsFromApi();
            var deserializeTeamNames = JsonSerializer.Deserialize<Teams[]>(teams, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

           List<string> TeamsAdvancedData = new List<string>();
            foreach (var team in deserializeTeamNames)
            {
                TeamsAdvancedData.Append(await APIActions.DownloadAdvancedByName(team.Team));
            }
            return TeamsAdvancedData;

        }

        //
        public static async Task<string> _deserializeAdvancedInfo(string _conferenceName)
        {
            List<Advanced> list = new List<Advanced>();

   
            var downloadedAdvancedData = await APIActions.DownloadToAdvanced();
            var deserializeAdvancedData = JsonSerializer.Deserialize<Advanced[]>(downloadedAdvancedData, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var item in deserializeAdvancedData)
            {
                list.Add(new Advanced
                {
                    Team = item.Team,
                    Conference = item.Conference,
                    Mascot = item.Mascot,
                });
            }
            return await SearchThroughAPI.Search(_conferenceName, list);
        }
    }
}
