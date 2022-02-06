namespace CarShop.Services
{
    using System.Threading.Tasks;
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void CreateUser(string username,
            string email,
            string password,
            string userType);

        bool IsUsernameAvailable(string username);

        bool IsUserMechanic(string userId);
    }
}
