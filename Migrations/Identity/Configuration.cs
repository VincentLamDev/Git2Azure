namespace CodeFirstLab.Migrations.Identity
{
    using Models;
    using Models.Places;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstLab.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(CodeFirstLab.Models.ApplicationDbContext context)
        {
            context.Provinces.AddOrUpdate(p => p.ProvinceCode, getProvince());
            context.SaveChanges();
            context.Cities.AddOrUpdate(c => new { c.CityName, c.Population }, getCities(context));
            context.SaveChanges();
        }

        private Province[] getProvince()
        {
            var provinces = new List<Province>
            {
                new Models.Places.Province() { ProvinceCode = "BC", ProvinceName = "British Columbia"},
                new Models.Places.Province() { ProvinceCode = "AL", ProvinceName = "Alberta"},
                new Models.Places.Province() { ProvinceCode = "ON", ProvinceName = "Ontario"},
            };
            return provinces.ToArray();
        }

        private City[] getCities(ApplicationDbContext context)
        {
            var cities = new List<City>
            {
                new Models.Places.City()
                {
                    CityName = "Toronto",
                    Population = 5132794,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                 new Models.Places.City()
                {
                    CityName = "Hamilton",
                    Population = 670580,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                  new Models.Places.City()
                {
                    CityName = "London",
                    Population = 366191,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                 new Models.Places.City()
                {
                    CityName = "Calgary",
                    Population = 1095404,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AL").ProvinceCode

                },
                 new Models.Places.City()
                {
                    CityName = "Edmonton",
                    Population = 960015,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AL").ProvinceCode

                },
                 new Models.Places.City()
                {
                    CityName = "Fort McMurray",
                    Population = 61374,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AL").ProvinceCode

                },
                new Models.Places.City()
                {
                    CityName = "Vancouver",
                    Population = 2135201,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
                new Models.Places.City()
                {
                    CityName = "Victoria",
                    Population = 316327,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
                new Models.Places.City()
                {
                    CityName = "Abbotsford",
                    Population = 149855,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
            };
            return cities.ToArray();
        }
    }
}
