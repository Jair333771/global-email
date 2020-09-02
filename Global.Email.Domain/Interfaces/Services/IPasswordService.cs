namespace Global.Email.Domain.Interfaces.Services
{
    public interface IPasswordService
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
