namespace JWT_AUTH_ASP.Authentication
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(string username, string password);
    }
}
