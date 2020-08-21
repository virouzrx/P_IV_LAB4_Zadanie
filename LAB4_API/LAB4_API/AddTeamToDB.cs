using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_API
{
    class AddTeamToDB
    {
        public static async Task<Teams> AddTeam(Teams item)
        {

            var crew = new Teams
            {
                Abbreviation = item.Abbreviation,
                School = item.School,
                Conference = item.Conference,
                Team = await DeserializeInfo._deserializeAdvancedInfo(item.Conference)
            };

            return crew;
        }
    }
}
