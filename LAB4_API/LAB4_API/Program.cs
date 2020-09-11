using Microsoft.EntityFrameworkCore.Storage;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAB4_API
{
    class Program
    {
        //link do api
        public static Website API = new Website("https://api.collegefootballdata.com");
        //teamsy oraz advancedy dla nich
        public static async Task<string> _downloadTeamsFromAPI()
        {
            return API.Download("/teams/fbs");
        }
        public static async Task<string> _downloadAdvancedInfoFromAPI()
        {
            return API.Download("/stats/season/advanced?year=2010");
        }
        //dodaj info
        public static async Task<Teams> _addTeamToDB(Teams item)
        {
            var ekipa = new Teams
            {
                School = item.School,
                Abbreviation = item.Abbreviation,
                Conference = item.Conference,
                Divison = item.Divison,
                Color = item.Color,
                Alt_Color = item.Alt_Color,
                Team = await _getAdvancedInfoFromAPI(item.Conference)
            };
            return ekipa;
        }
        //pobierz advanced data
        public static async Task<string> _getAdvancedInfoFromAPI(string _nazwaConfy)
        {
            List<Advanced> lista = new List<Advanced>();
            var advanced = await _downloadAdvancedInfoFromAPI();
            var deserializer_advanced = JsonSerializer.Deserialize<Advanced[]>(advanced, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var item in deserializer_advanced)
            {
                lista.Add(new Advanced
                {
                    Team = item.Team,
                    Conference = item.Conference,
                    Year = item.Year,
                    excludeGarbageTime = item.excludeGarbageTime,
                    startWeek = item.startWeek,
                    endWeek = item.endWeek
                });
            }
            return await _lookForMatch(_nazwaConfy, lista);
        }
        //znajdz wszystkie odpowiadajace tym druzynom conference i dodaj im parametry z advanceda
        public static async Task<string> _lookForMatch(string _Confa, List<Advanced> lista)
        {
            return lista
                            .Where(x => x.Conference == _Confa)
                            .Select(x => x.Team)
                            .FirstOrDefault();
        }
        public static async Task Main()
        {
            //String hourMinute = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine("Odpaliłem program!\n");
            using var db = new Context();
            db.Database.EnsureCreated();
            Console.WriteLine("Stworzylem baze!\n");
            var teams = await _downloadTeamsFromAPI();

            var deserializer = JsonSerializer.Deserialize<Teams[]>(teams, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            Console.WriteLine("Zdeserializowalem dane!\n");
            foreach (var item in deserializer)
            {
                db.Teams.Add(await _addTeamToDB(item));
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                Console.WriteLine("Dodalem element do bazy...\n");
            };
            db.SaveChanges();
            Console.WriteLine("Zapisalem dane do bazy!");
        }
    }
}
