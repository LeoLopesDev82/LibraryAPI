using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs.Auth
{
    /// <summary>
    /// Represents the login request payload containing user credentials.
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// Gets or sets the username used for authentication.
        /// </summary>
        [Required]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password used for authentication.
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;
    }
}