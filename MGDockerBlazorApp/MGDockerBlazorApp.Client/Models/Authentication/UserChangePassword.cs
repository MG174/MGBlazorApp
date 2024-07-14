namespace MGDockerBlazorApp.Client.Models.Authentication
{
    public class UserChangePassword
    {
        public string Email { get; set; }
        public string PreviousPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
