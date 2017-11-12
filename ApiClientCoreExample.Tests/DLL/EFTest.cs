using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ApiClientCoreExample.Tests.DLL
{
    [TestClass]
    public class EFTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db = null;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
        }

        [TestMethod]
        public void Users_GetAll()
        {
            // Arrange            
            // Act
            var result = db.Users.ToListAsync();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Result.Count);
        }

        [TestMethod]
        public void Users_FindById()
        {
            // arrange
            // act
            var user = db.Users.Find(1);


            // assert
            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void Users_Create()
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

            var user = db.Users.Add(newUser);
            db.SaveChanges();

            var users = db.Users.ToList();
            var newReaders = from u in db.Users
                             .Where(u => u.Login == "111111")
                             select u;

            // assert
            Assert.AreEqual(oldUserCount + 1, users.Count);
            Assert.AreNotEqual(0, newReaders.Count());
        }

        [TestMethod]
        public void Users_Delete()
        {
            // arrange
            User user = db.Users.Find(1);

            int oldUserCount = db.Users.Count();
            // act

            db.Users.Remove(user);
            db.SaveChanges();

            var users = db.Users.ToList();
            var emptyUser = db.Users.Find(1);

            // assert
            Assert.AreEqual(oldUserCount - 1, users.Count);
            Assert.IsNull(emptyUser);

        }
    }
}

