using Microsoft.EntityFrameworkCore;
using SpartaToDo.Models;

namespace SpartaToDo.Data;
 public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var db = new SpartaToDoContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<SpartaToDoContext>>()))
        {
            // Look for any ToDos.
            if (db.ToDos.Any())
            {
                return;   // DB has been seeded
            }

            db.ToDos.AddRange(

                new ToDo
                {
                    Title = "Teach C#",
                    Description = "Teach Engineering-2022 how to use Entity Framework",
                    Complete = true,
                    DateCreated = new DateTime(2022, 03, 01)
                },
                new ToDo
                {
                    Title = "Learn two swim",
                    Description = "Dive off from the Cliffs of Dover and swim until I get to France",
                    Complete = false
                },

                new ToDo
                {
                    Title = "Reunite Oasis",
                    Description = "Need to arrange chat with Noel and Liam to sort out a reunion tour",
                    Complete = false
                });
            db.SaveChanges();
        }
    }
}
