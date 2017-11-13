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
            string miner = "7eb4dfab904c3d42c99a85114b6f0831bf8b318a";
            // act
            data = await minerService.GetCurrentStats(miner);

            // assert
            Assert.IsNotNull(data);
        }
    }
}
