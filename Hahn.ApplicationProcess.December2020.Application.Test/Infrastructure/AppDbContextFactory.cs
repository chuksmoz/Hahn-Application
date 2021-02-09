using Hahn.ApplicationProcess.December2020.Data;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure
{
    class AppDbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            context.Database.EnsureCreated();

            context.Applicants.AddRange(new[]
            {
                    new Applicant()
                    {
                        Address = "Ansgarstr. 4, Wallenhorst, 49134",
                        Age = 27,
                        CountryOfOrigin = "Germany",
                        EmailAddress = "test@test.com",
                        FamilyName = "family Name",
                        Hired = true,
                        ID = 1,
                        Name= "Name"
                    },
                    new Applicant()
                    {
                        Address = "Ochsenweg 54, Melle, 49324",
                        Age = 27,
                        CountryOfOrigin = "Germany",
                        EmailAddress = "test@test.com",
                        FamilyName = "family Name",
                        Hired = true,
                        ID = 2,
                        Name= "Name"
                    },
                    new Applicant()
                    {
                        Address = "Falkenstr. 5, GeorgsmarienhÜTte, 49124",
                        Age = 27,
                        CountryOfOrigin = "Germany",
                        EmailAddress = "test@test.com",
                        FamilyName = "family Name",
                        Hired = true,
                        ID = 3,
                        Name= "Nmae"
                    },
                }
            );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
