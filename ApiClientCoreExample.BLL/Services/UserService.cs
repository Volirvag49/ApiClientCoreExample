using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Infrastructure;
using ApiClientCoreExample.BLL.Interfaces;
using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ApiClientCoreExample.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork { get; set; }

        public UserService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task Register(UserDTO userDTO)
        {

            if (userDTO == null)
            {
                throw new ValidationException("Требуется пользователь", "");
            }

            await CheckLogin(userDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
            User user = Mapper.Map<UserDTO, User>(userDTO);

            unitOfWork.Users.Create(user);
            await unitOfWork.CommitAsync();
        }

        private async Task CheckLogin(UserDTO userDTO)
        {
            var loginIsExist = await unitOfWork.Users.IsExistAsync(where: q => q.Login == userDTO.Login && q.Id != userDTO.Id);
            if (loginIsExist)
            {
                throw new ValidationException("Логин должен быть уникальным", "Login");
            }
        }

        public async Task<bool> Login(string login, string password)
        {
            var userIsExist = await unitOfWork.Users.IsExistAsync(where: q => q.Login == login && q.Password == password);

            if (userIsExist)
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
