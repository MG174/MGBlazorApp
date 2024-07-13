namespace MGDockerBlazorApp.Client.Models
{
    public class UserChangePasswordDto
    {
        public string Email { get; set; }
        public string PreviousPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
