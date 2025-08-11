namespace LibraryAPI.Models.DTOs.Auth
{
    /// <summary>
    /// Represents the response returned after a successful authentication.
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Gets or sets the generated JWT token.
        /// </summary>
        public string Token { get; set; } = null!;

        /// <summary>
        /// Gets or sets the expiration date and time of the token.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}