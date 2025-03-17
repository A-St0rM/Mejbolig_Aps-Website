namespace M.E.J_PropertyWebsite.Server.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public Admin()
        {

        }
    }
}
