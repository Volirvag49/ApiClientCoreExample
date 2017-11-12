using ApiClientCoreExample.DAL.EF;
using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiClientCoreExample.Tests.DLL
{
    [TestClass]
    public class UOWTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db;
        UnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
            unitOfWork = new UnitOfWork(db);
        }

        [TestMethod]
        public async Task Users_GetAllAsync()
        {
            // arrange
            // act
            var users =await unitOfWork.Users.GetAllAsync() as List<User>;
            // assert
            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public async Task Users_GetAsync()
        {
            // arrange
            // act
            var users = await unitOfWork.Users.GetAsync(orderBy: q => q.OrderBy(d => d.Login)) as List<User>;
            // assert
            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void Users_FindByIdAsync()
        {
            // arrange
            // act
            var user = unitOfWork.Users.GetByIdAsyn(1);

            // assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Users_CreateAsync()
        {
            // arrange
            User newUser = new User()
            {
                Login = "123123",
                Password = "123123",
                Miner = "123hjsdfk8345jhgdf"

            };

            int oldUserCount = db.Users.Count();
            // act

            unitOfWork.Users.Create(newUser);
            await unitOfWork.CommitAsync();

            var users = db.Users.ToList();
            var newReaders = from u in db.Users
                             .Where(u => u.Login == "123123")
                             select u;

            // assert
            Assert.AreEqual(oldUserCount + 1, users.Count);
            Assert.AreNotEqual(0, newReaders.Count());
        }

        [TestMethod]
        public async Task Users_DeleteAsync()
        {
            // arrange
            User user = db.Users.Find(1);

            int oldUserCount = db.Users.Count();
            // act

            unitOfWork.Users.Delete(user);
            await unitOfWork.CommitAsync();

            var users = db.Users.ToList();
            var emptyUser = db.Users.Find(1);

            // assert
            Assert.AreEqual(oldUserCount - 1, users.Count);
            Assert.IsNull(emptyUser);

        }

        [TestMethod]
        public async Task Users_CountAsync()
        {
            // arrange
            // act
            var user = await unitOfWork.Users.CountAsync(where: q => q.Password == "111111");

            // assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Users_IsExistAsync()
        {
            // arrange
            string userLogin = "111111";
            int userId = 1;

            // act: Проверка есть ли пользователь с данным логином и id
            var loginIsExist = await unitOfWork.Users.IsExistAsync(where: q => q.Login == userLogin && q.Id == userId);

            // assert
            Assert.IsTrue(loginIsExist);
        }
    }
}
