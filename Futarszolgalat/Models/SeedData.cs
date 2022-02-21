using Futarszolgalat.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Futarszolgalat.Models
{
    public class SeedData
    {
        public static void Inicializalas(IServiceProvider serviceProvider)
        {
            ApplicationDbContext db = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (!db.Gyogyszer.Any())
            {
                var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var csvLocation = Path.Combine(executableLocation, @"Resources\gyogyszerek_temp.csv");

                var sorok = File.ReadAllLines(csvLocation).Skip(1);

                foreach (var item in sorok)
                {
                    db.Gyogyszer.Add(new Gyogyszer(item));
                }
                db.SaveChanges();
            }
        }
    }
}
