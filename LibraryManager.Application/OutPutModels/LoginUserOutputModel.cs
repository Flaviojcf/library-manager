namespace LibraryManager.Application.OutPutModels
{
    public class LoginUserOutputModel(string email, string token)
    {
        public string Email { get; private set; } = email;
        public string Token { get; private set; } = token;
    }
}
