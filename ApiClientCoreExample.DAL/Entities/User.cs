namespace ApiClientCoreExample.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Miner { get; set; }
    }
}
