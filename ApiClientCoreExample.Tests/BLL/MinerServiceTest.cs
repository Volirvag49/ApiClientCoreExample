using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Services;

namespace ApiClientCoreExample.Tests.BLL
{
    [TestClass]
    public class MinerServiceTest
    {
        MinerService minerService;
        [TestInitialize]
        public void Initialize()
        {
            minerService = new MinerService();
        }

        [TestMethod]
        public async Task MinerService_GetCurrentStats()
        {
            // arrange
            DataDTO data = new DataDTO();
            string miner = "e6b821fb8bc6df40b922a82bdf78925bcff29d67";
            // act
            data = await minerService.GetCurrentStats(miner);

            // assert
            Assert.IsNotNull(data);
        }
    }
}
