using Microsoft.Extensions.DependencyInjection;
using projectoFinalV2.Models;
using Newtonsoft.Json;

namespace projectoFinalV2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope   = serviceProvider.CreateScope();
            var context       = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Si ya hay películas, salimos
            if (context.Films.Any()) return;

            // 1) Traer y guardar películas
            var http = new HttpClient();
            var filmsJson = http.GetStringAsync("https://ghibliapi.vercel.app/films").Result;
            var films = JsonConvert.DeserializeObject<List<Film>>(filmsJson)!;
            context.Films.AddRange(films);
            context.SaveChanges();

            // 2) Traer y guardar personas
            var peopleJson = http.GetStringAsync("https://ghibliapi.vercel.app/people").Result;
            var people = JsonConvert.DeserializeObject<List<People>>(peopleJson)!;
            context.People.AddRange(people);
            context.SaveChanges();
        }
    }
}
