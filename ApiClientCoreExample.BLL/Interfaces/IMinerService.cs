using ApiClientCoreExample.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientCoreExample.BLL.Interfaces
{
    public interface IMinerService
    {
        Task<DataDTO> GetCurrentStats(string miner);
    }
}
