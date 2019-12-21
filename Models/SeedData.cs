using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HD_Decisions_Case_Study.Data;
using System;
using System.Linq;

namespace HD_Decisions_Case_Study.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HD_Decisions_Case_StudyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HD_Decisions_Case_StudyContext>>()))
            {
                
                if (context.FormData.Any())
                {
                    return;   // DB has been seeded
                }

                context.FormData.AddRange(
                    new FormData
                    {
                        Name = "Jack Sanders",
                        DateOfBirth = DateTime.Parse("1997-04-12"),
                        AnnualIncome = 35000,
                       
                    },

                    new FormData
                    {
                        Name = "Joe Bloggs",
                        DateOfBirth = DateTime.Parse("1999-04-15"),
                        AnnualIncome = 19000,

                    },

                    new FormData
                    {
                        Name = "Jane Doe",
                        DateOfBirth = DateTime.Parse("1987-09-16"),
                        AnnualIncome = 30000,

                    }
                );
                context.SaveChanges();

               
            }
        }
    }
}