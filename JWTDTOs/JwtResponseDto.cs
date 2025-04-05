namespace HospitalManagementSystem_HMS_.JWTDTOs
{
    public class JwtResponseDto
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string Role { get; set; }
    }
}
