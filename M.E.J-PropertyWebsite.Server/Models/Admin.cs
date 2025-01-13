namespace M.E.J_PropertyWebsite.Server.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin(int id, string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.Id = id;
        }
    }
}
