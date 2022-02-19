namespace SMS.Services
{
    using System.Linq;

    using SMS.Contracts;
    using SMS.Data;
    using SMS.Data.Models;

    public class UserService : IUserService
    {
        private readonly SMSDbContext dbContext;

        public UserService(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(string username,
            string email,
            string password)
        {
            var cart = new Cart();

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                Cart = cart
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public string GetUserCartId(string userId)
        {
            return dbContext
                      .Carts
                      .Where(c => c.User.Id == userId)
                      .FirstOrDefault()
                      .Id;
        }

        public string GetUserId(string username, string password)
        {
            var user = dbContext
                          .Users
                          .Where(u => u.Username == username
                                   && u.Password == password)
                          .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string userId)
        {
            return dbContext
                      .Users
                      .Find(userId)
                      .Username;
        }
    }
}
