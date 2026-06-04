namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        public async Task<bool> ImportProject(string path)
        {
            return true;
        }

        public async Task<string> DownloadProject(string project)
        {
            return project;
        }

        public async Task<(int, List<String>)> GetProjects()
        {
            HttpResponseMessage Response = await Client.GetAsync("/project/get/");
            int ResponseCode = (int)Response.StatusCode;
            string ResponseContent = await Response.Content.ReadAsStringAsync();
            List<String> ProjectsList = [];

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
    }
}
