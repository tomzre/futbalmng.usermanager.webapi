namespace UserManager.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}