using System.Net;

namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        public async Task<(int, string)> GetImagesList(string Name)
        {
            HttpResponseMessage Response = await Client.GetAsync($"/image/get/{Name}/");
            int ResponseCode = (int)Response.StatusCode;
            string ResponseContent = await Response.Content.ReadAsStringAsync();

            return (ResponseCode, ResponseContent);
        }

        public async Task<byte[]> GetImage(string Name, string ImageName)
        {
            var Response = await Client.GetByteArrayAsync($"/image/load/{Name}/{ImageName}");
            return Response;
        }

        public async Task<bool> LockImage(string Name, string ImageName)
        {
            var Response = await Client.GetAsync($"/image/lock/{Name}/{ImageName}");
            if (Response.StatusCode == HttpStatusCode.OK)
                return true;
            else return false;
        }

        public async void UnlockImage(string Name, string ImageName)
        {
            await Client.GetAsync($"/image/unlock/{Name}/{ImageName}");
        }

        public async Task<bool> CheckLock(string Name, string ImageName)
        {
            var Response = await Client.GetAsync($"/image/check/{Name}/{ImageName}");
            if ((int)Response.StatusCode == 200)
                return false;
            else return true;
        }
    }
}
