namespace AngularApp3.Server.Helpers
{
    public class HTTP
    {
        private HttpClient http;
        public HTTP()
        {
            http = new HttpClient();
        }

        public async Task<string> CallURLAsync(string url)
        {
            HttpResponseMessage response = await http.GetAsync(url);

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

    }
}
