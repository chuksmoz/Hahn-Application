using Hahn.ApplicationProcess.December2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Data
{
    public class HahnApplicantDatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new HahnApplicantDatabaseInitializer();
            initializer.SeedApplicant(context);
        }

        public void SeedApplicant(AppDbContext context)
        {
            var applicants = new[]
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
                    Name= "Nmae"
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
                    Name= "Nmae"
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
                new Applicant()
                {
                    Address = "	Leimkugelstr. 13, SchÖPpenstedt, 38170",
                    Age = 27,
                    CountryOfOrigin = "Germany",
                    EmailAddress = "test@test.com",
                    FamilyName = "family Name",
                    Hired = true,
                    ID = 4,
                    Name= "Nmae"
                }
            };

            context.Applicants.AddRange(applicants);

            context.SaveChanges();
        }
    }
}
