namespace MGDockerBlazorApp.Client.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginUser() 
        { 

        }

        public async Task ChangePassword()
        {

        }
    }
}
