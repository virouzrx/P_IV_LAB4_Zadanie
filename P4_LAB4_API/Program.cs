using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using RestSharp;
using System.Linq;

namespace P4_LAB4_API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new Website("https://api.collegefootballdata.com/");
            var teams = api.DownloadAsync("/teams/fbs").Result.Content;

            using (var db = new FootballContext())
            {
                db.Database.EnsureCreated();
                var deserialization = JsonSerializer.Deserialize<Teams[]>(teams, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                var tasks = new List<Task<IRestResponse>>();
                foreach (var item in deserialization)
                {
                    var coach = api.DownloadAsync($"/coaches?team={item.School}");
                    tasks.Add(coach);

                }
                var responses = await Task.WhenAll(tasks);

                var deserializationCoaches = responses.SelectMany(x => JsonSerializer.Deserialize<Coaches[]>(x.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
                foreach (var item in deserializationCoaches)
                {
                    deserialization.SingleOrDefault(x => x.School == item.Seasons.FirstOrDefault().School).Coaches.Add(item);
                }



                var addTasks = deserialization.Select(x => db.AddAsync(x).AsTask());
                await Task.WhenAll(addTasks);
                await db.SaveChangesAsync();


            }
        }
    }
}