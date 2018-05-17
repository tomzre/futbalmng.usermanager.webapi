namespace UserManager.Infrastructure.Settings
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}