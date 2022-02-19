namespace SMS.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

    }
}
