using System;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAB4_API
{
    public class Program
    {
        public static async Task Main()
        {
            using var db = new Context();
            db.Database.EnsureCreated();
            var teams = await APIActions.GetTeamsFromApi();
            var deserializer = JsonSerializer.Deserialize<Teams[]>(teams, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var item in deserializer)
            {
                db.Teams.Add(await AddTeamToDB.AddTeam(item));
                db.SaveChanges();
            };
        }
    }
}
