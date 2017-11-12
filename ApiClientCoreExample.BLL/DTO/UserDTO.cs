using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClientCoreExample.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Miner { get; set; }
    }
}
