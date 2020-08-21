using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_API
{
    public class APIActions
    {
        public static Website API = new Website("https://api.collegefootballdata.com");
        public static async Task<string> GetTeamsFromApi()
        {
            return API.Download("/teams/fbs");
        }

        public static async Task<string> DownloadToAdvanced()
        {
            return API.Download("/stats/season/advanced?year=2010");
        }
    }
}
