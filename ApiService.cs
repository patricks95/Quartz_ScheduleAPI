namespace Auto_API_Run
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CallApis()
        {
            // Example API call
            var response = await _httpClient.GetAsync("https://localhost:7001/api/sample/auto-api");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("API call succeeded.");
            }
            else
            {
                Console.WriteLine("API call failed.");
            }
        }
    }
}
