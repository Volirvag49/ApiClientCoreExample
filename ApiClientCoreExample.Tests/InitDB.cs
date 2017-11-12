using ApiClientCoreExample.DAL.EF;
using ApiClientCoreExample.DAL.Entities;
namespace ApiClientCoreExample.Tests
{
    public class InitDB
    {
        public static void InitDbContext(ApplicationDBContext context)
        {
            context.Users.Add(new User { Login = "111111", Password = "111111", Miner = "sdfjskfjask;dfjlas;dfjsdf" });
            context.Users.Add(new User { Login = "222222", Password = "222222", Miner = "dfsdafsdfasdfsfsdfasdf" });
            context.SaveChanges();
        }

    }
}


