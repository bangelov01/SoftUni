namespace SharedTrip.Services
{
    using SharedTrip.Contracts;
    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
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

            repository.Add(user);
            repository.SaveChanges();
        }

        public string GetUserId(string username,
            string password)
        {
            var userId = repository
                            .Many<User>()
                            .Where(u => u.Username == username
                                     && u.Password == password)
                            .Select(u => u.Id)
                            .FirstOrDefault();
            return userId;
        }
    }
}
