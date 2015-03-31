namespace ArduinoYum.Data.Migrations
{
    using ArduinoYum.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArduinoYum.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArduinoYum.Data.ApplicationDbContext context)
        {
            Seeder.Seed(context, true, true, true);
        }
    }
}
