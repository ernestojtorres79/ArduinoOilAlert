using ArduinoYum.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ArduinoYum.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext context, bool sensor = true, bool stype = true, bool boardIO = true)
        {
            if (boardIO) SeedBoardIO(context);
            if (stype) SeedStype(context);
            if (sensor) SeedSensor(context);

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!RoleManager.RoleExists("Admin"))
            {
                var Role = new IdentityRole();
                Role.Name = "Admin";
                RoleManager.Create(Role);
            }
            if (!RoleManager.RoleExists("User"))
            {
                var Role = new IdentityRole();
                Role.Name = "User";
                RoleManager.Create(Role);
            }

            if (!context.Users.Any(x => x.UserName == "ernestojtorres79"))
            {
                var User = new ApplicationUser();
                User.UserName = "ernestojtorres79";
                User.Email = "ernestojtorres@hotmail.com";
                User.EmailConfirmed = true;
                UserManager.Create(User, "123123");
                UserManager.AddToRole(User.Id, "Admin");
            }

        }
        private static void SeedSensor(ApplicationDbContext context)
        {
            context.Sensors.AddOrUpdate(x => x.SensorName,
                new Sensor() { SensorName = "Presure Sensor 1", STypeId = context.STypes.Where(v => v.STypeName == "Analog").FirstOrDefault().STypeId, BoardIOId = context.BoardIOs.Where(c=> c.IOName == "A0").FirstOrDefault().BoardIOId },
                new Sensor() { SensorName = "Presure Sensor 2", STypeId = context.STypes.Where(v => v.STypeName == "Analog").FirstOrDefault().STypeId, BoardIOId = context.BoardIOs.Where(c => c.IOName == "A1").FirstOrDefault().BoardIOId },
                new Sensor() { SensorName = "Water Tank 1", STypeId = context.STypes.Where(v => v.STypeName == "Digital").FirstOrDefault().STypeId, BoardIOId = context.BoardIOs.Where(c => c.IOName == "D2").FirstOrDefault().BoardIOId });
            context.SaveChanges();
        }
        private static void SeedStype(ApplicationDbContext context)
        {
            context.STypes.AddOrUpdate(x => x.STypeName,
                new SType() { STypeName = "Analog" },
                new SType() { STypeName = "Digital" });
            context.SaveChanges();
        }
        private static void SeedBoardIO(ApplicationDbContext context)
        {
            context.BoardIOs.AddOrUpdate(x => x.IOName,
                new BoardIO() { IOName = "A0"},
                new BoardIO() { IOName = "A1"},
                new BoardIO() { IOName = "A2"},
                new BoardIO() { IOName = "A3"},
                new BoardIO() { IOName = "A4"},
                new BoardIO() { IOName = "A5"},
                new BoardIO() { IOName = "D0"},
                new BoardIO() { IOName = "D1"},
                new BoardIO() { IOName = "D2"},
                new BoardIO() { IOName = "D3"},
                new BoardIO() { IOName = "D4"},
                new BoardIO() { IOName = "D5"},
                new BoardIO() { IOName = "D6"},
                new BoardIO() { IOName = "D7"},
                new BoardIO() { IOName = "D8"},
                new BoardIO() { IOName = "D9"},
                new BoardIO() { IOName = "D10"},
                new BoardIO() { IOName = "D11"},
                new BoardIO() { IOName = "D12"});
            context.SaveChanges();
        }
    }
}
