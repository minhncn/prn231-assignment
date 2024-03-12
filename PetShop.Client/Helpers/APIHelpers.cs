namespace PetShop.Client.Helpers
{
    public class APIHelpers
    {
        public async Task<string> GetAPI(string url, string token)
        {
            var httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);
            var cleanedToken = token.Replace("\r", "").Replace("\n", "");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + cleanedToken);
            HttpResponseMessage responseMessage = await httpClient.SendAsync(request);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
