using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Infrastructure;
using ApiClientCoreExample.BLL.Services;
using ApiClientCoreExample.DAL.EF;
using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientCoreExample.Tests.BLL
{
    public class UserServiceTest
    {
        [TestClass]
        public class UOWTest
        {
            DbContextOptionsBuilder<ApplicationDBContext> builder;
            ApplicationDBContext db;
            UnitOfWork unitOfWork;
            UserService userService;

            [TestInitialize]
            public void Initialize()
            {
                builder = new DbContextOptionsBuilder<ApplicationDBContext>();
                builder.UseInMemoryDatabase(databaseName:
                         "TestDB");
                db = new ApplicationDBContext(builder.Options);
                InitDB.InitDbContext(db);
                unitOfWork = new UnitOfWork(db);
                userService = new UserService(unitOfWork);
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            }

            [TestMethod]
            public async Task UserService_Register()
            {
                // arrange
                UserDTO newUser = new UserDTO()
                {
                    Login = "123123",
                    Password = "123123",
                    Miner = "123hjsdfk8345jhgdf"

                };

                int oldUserCount = db.Users.Count();
                // act
                await userService.Register(newUser);

                var users = db.Users.ToList();
                var newReaders = from u in db.Users
                                 .Where(u => u.Login == "123123")
                                 select u;

                // assert
                Assert.AreEqual(oldUserCount + 1, users.Count);
                Assert.AreNotEqual(0, newReaders.Count());
            }

            [TestMethod]
            public async Task UserService_Login()
            {
                // arrange
                string login = "111111";
                string password = "111111";
                string fakepassword = "Sfdfdf32";
                bool loginIsCorrect = true;
                bool loginIsNotCorrect = true;

                // act
                try
                {
                    await userService.Login(login, password);

                }
                catch (BusinessLogicException)
                {
                    loginIsCorrect = false;

                }

                try
                {
                    await userService.Login(login, fakepassword);

                }
                catch (BusinessLogicException)
                {
                    loginIsNotCorrect = false;

                }

                // assert
                Assert.IsTrue(loginIsCorrect);
                Assert.IsFalse(loginIsNotCorrect);
            }

        }
    }
}
