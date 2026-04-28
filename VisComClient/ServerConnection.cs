using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace VisComClient
{
    public class ServerConnection
    {
        private CookieContainer Cookies = new();
        private HttpClientHandler Handler;

        public HttpClient Client = new();
        public string Credentials = "";
        private readonly string UserName;

        public ServerConnection(string? URI, string? User) 
        {
            if(URI != null && User != null)
            {
                UserName = User;
                Handler = new HttpClientHandler
                {
                    CookieContainer = Cookies,
                    UseCookies = true
                };
                Client = new HttpClient(Handler) { BaseAddress = new Uri(URI) };
                Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{User}:{User}"));
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Credentials);
            }
        }

        public async Task<int> LoginAsync()
        {
            HttpResponseMessage Request = await Client.GetAsync($"/login/{UserName}");
            return (int)Request.StatusCode;
        }

        public async Task<int> LogoutAsync()
        {
            HttpResponseMessage Request = await Client.GetAsync("/logout");
            return (int)Request.StatusCode;
        }

        public async Task<int> PingServer()
        {
            HttpResponseMessage Response = await Client.GetAsync("/");
            int ResponseCode = (int)Response.StatusCode;

            return ResponseCode;
        }

        public async Task<(int, List<String>)> GetProjects()
        {
            HttpResponseMessage Response = await Client.GetAsync("/project/get/");
            int ResponseCode = (int)Response.StatusCode;
            string ResponseContent = await Response.Content.ReadAsStringAsync();
            List<String> ProjectsList = new();

            if (ResponseContent != "No projects to serve.")
            {
                ResponseContent = ResponseContent.Trim().Replace("[", "").Replace("]", "").Replace(" ", "");
                var contents = ResponseContent.Split(',');

                foreach (var project in contents)
                    ProjectsList.Add(project.Replace(",", ""));
            }

            return (ResponseCode, ProjectsList);
        }

        public async Task<(int, string)> CreateProject(string Name, string Type)
        {
            HttpResponseMessage Response = await Client.GetAsync($"/project/new/{Name}/{Type}");
            int ResponseCode = (int)Response.StatusCode;
            string ResponseContent = await Response.Content.ReadAsStringAsync();

            return (ResponseCode, ResponseContent);
        }

        public async Task<(int, string)> GetProject(string Name)
        {
            HttpResponseMessage Response = await Client.GetAsync($"/project/get/{Name}");
            int ResponseCode = (int)Response.StatusCode;
            string ResponseContent = await Response.Content.ReadAsStringAsync();

            return (ResponseCode, ResponseContent);
        }

        public async Task<int> DeleteProject(string Name)
        {
            HttpResponseMessage Response = await Client.GetAsync($"/project/delete/supersure/yes/{Name}");
            int ResponseCode = (int)Response.StatusCode;

            return ResponseCode;
        }

        public async void GetImages(string Name)
        {

        }

    }

}
