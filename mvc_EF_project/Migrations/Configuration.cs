namespace mvc_EF_project.Migrations
{
    using mvc_EF_project.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mvc_EF_project.DAL.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mvc_EF_project.DAL.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var students = new List<Worker>(){
                   new Worker{FirstName="Andy",LastName="George",Sex = Sex.Male},
                   new Worker{FirstName="Laura",LastName="Smith",Sex = Sex.Female},
                   new Worker{FirstName="Jason",LastName="Black",Sex = Sex.Male},
                   new Worker{FirstName="Linda",LastName="Queen",Sex = Sex.Female},
                   new Worker{FirstName="James",LastName="Brown", Sex = Sex.Male}
            };
            students.ForEach(c => context.Workers.AddOrUpdate(d=> d.ID, c));
            context.SaveChanges();

            var provinceList = new List<Province>(){
             new Province(){provinceId=1,provinceName="湖南",Abbr="hunan_province"},
             new Province(){provinceId=2,provinceName="广东",Abbr="guangdong_province"},
             new Province(){provinceId=3,provinceName="吉林",Abbr="jilin_province"},
             new Province(){provinceId=4,provinceName="四川",Abbr="sichuang_province"}
            };
            provinceList.ForEach(p => context.Provinces.AddOrUpdate(d => d.provinceName, p));
            context.SaveChanges();

            var cities = new List<City>(){
                new City(){CityId=1,CityName="榆阳",provinceId=1},
                new City(){CityId=2,CityName="深圳",provinceId=2},
                new City(){CityId=3,CityName="东莞",provinceId=2},
                new City(){CityId=4,CityName="沈阳",provinceId=3},
                new City(){CityId=5,CityName="成都",provinceId=4},
                new City(){CityId=6,CityName="德阳",provinceId=4},
                new City(){CityId=7,CityName="西昌",provinceId=4},
            };
            cities.ForEach(c => context.Cities.AddOrUpdate(ct => ct.CityName, c));
            context.SaveChanges();
        }
    }
}
