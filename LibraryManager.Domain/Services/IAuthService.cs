namespace LibraryManager.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email);
        string ComputeSha256Hash(string password);
    }
}
