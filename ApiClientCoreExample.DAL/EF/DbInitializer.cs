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
                new User{Login = "111111", Password = "111111", Miner= "e6b821fb8bc6df40b922a82bdf78925bcff29d67"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
