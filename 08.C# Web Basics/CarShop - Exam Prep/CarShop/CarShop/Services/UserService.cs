namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Common;
    using CarShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(string username,
            string email,
            string password,
            string userType)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsMechanic = userType == DataConstants.USER_MECHANIC
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
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

        public bool IsUserMechanic(string userId)
        {
            return this.dbContext
                .Users
                .Any(u => u.Id == userId && u.IsMechanic);
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
