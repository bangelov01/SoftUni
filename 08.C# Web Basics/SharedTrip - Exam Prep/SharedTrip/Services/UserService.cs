namespace SharedTrip.Services
{
    using SharedTrip.Contracts;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(string username,
            string email,
            string password)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public string GetUserId(string username,
            string password)
        {
            var userId = dbContext
            .Users
            .Where(u => u.Username == username
                        && u.Password == password)
            .Select(u => u.Id)
            .FirstOrDefault();

            return userId;
        }
    }
}
