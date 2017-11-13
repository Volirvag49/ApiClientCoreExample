using ApiClientCoreExample.BLL.DTO;
using System;
using System.Threading.Tasks;

namespace ApiClientCoreExample.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Register(UserDTO user);
        Task<bool> Login(string login, string password);
        Task<string> GetUsersMiner(string userLogin);
    }
}
