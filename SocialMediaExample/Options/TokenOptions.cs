namespace SocialMediaExample.Options
{
    public class TokenOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double ExpirationInMinutes { get; set; }
    }
}
