namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using System.Linq;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;
        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return username;
        }

        public string GetUserId(string username, string password)
        {
            var userId = dbContext
                        .Users
                        .Where(u => u.Username == username
                                    && u.Password == password)
                        .Select(u => u.Id)
                        .FirstOrDefault();

            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            if (this.dbContext.Users.Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameAvailable(string username)
        {
            if (this.dbContext.Users.Any(u => u.Username == username))
            {
                return false;
            }

            return true;
        }
    }
}
