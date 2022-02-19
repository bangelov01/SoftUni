namespace SMS.Contracts
{
    public interface IUserService
    {
        void CreateUser(string username,
                string email,
                string password);

        string GetUserId(string username,
                        string password);

        string GetUsername(string userId);

        string GetUserCartId(string userId);
    }
}
