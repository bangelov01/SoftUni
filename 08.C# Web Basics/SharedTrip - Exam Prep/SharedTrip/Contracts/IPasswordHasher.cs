namespace SharedTrip.Contracts
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
