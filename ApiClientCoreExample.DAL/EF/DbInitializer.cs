using ApiClientCoreExample.DAL.Entities;
using System;
using System.Linq;

namespace ApiClientCoreExample.DAL.EF
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Login = "111111", Password = "111111", Miner= "7eb4dfab904c3d42c99a85114b6f0831bf8b318a"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
