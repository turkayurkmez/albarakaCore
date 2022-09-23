using catalog.Entities;

namespace catalog.Business.Services
{
    public class UserService
    {
        List<User> _users = new List<User>();
        public UserService()
        {
            _users = new List<User>
            {
                new User{ Id=1, UserName="turkayurkmez", Password="123456", EmailAddress="a@b.com", Role="Admin"},
                new User{ Id=2, UserName="caglarsen", Password="123456", EmailAddress="c@b.com", Role="Editor"},
                new User{ Id=3, UserName="nebipinar", Password="123456", EmailAddress="n@b.com", Role="User"},

            };
        }
        public User ValidateUser(string userName, string password)
        {
            return _users.Find(u => u.UserName == userName && u.Password == password);
        }
    }
}
