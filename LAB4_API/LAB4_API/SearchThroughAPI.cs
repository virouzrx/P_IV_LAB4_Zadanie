using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_API
{
    class SearchThroughAPI
    {
        //linq method
        public static async Task<string> Search(string _conference, List<Advanced> lista)
        {
            return lista.Where(x => x.Conference == _conference)
                                     .Select(x => x.Team)
                                     .FirstOrDefault();
        }
    }
}
