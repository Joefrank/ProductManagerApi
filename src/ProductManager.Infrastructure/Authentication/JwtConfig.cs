//Not used in this project yet.

namespace ProductManager.Infrastructure.Authentication
{    public class JwtConfig
    {
        public string Secret { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public int TokenDurationInHours { get; set; }
    }
}
