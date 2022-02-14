namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        void CreateUser(string username,
            string email,
            string password);

        string GetUserId(string username,
            string password);
    }
}
