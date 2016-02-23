using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmbientSpeech
{
    public class EventHubClient<T>
    {
        public string SasTokenApiEndpoint { get; }
        public string DeviceId { get; }
        public string ServiceBusNamespace { get; }
        public string EventHub { get; }

        private string sasToken = null;

        // http://mtcsastokenapi.azurewebsites.net/api/v1
        // {52F7CD55-377C-4994-9B0B-7A780C1A69B2}
        // ambientwords
        // Send

        public EventHubClient(string apiEndpoint, string deviceId, string serviceBusNamespace, string eventHub)
        {
            if (String.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentNullException(nameof(apiEndpoint));

            if (String.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentNullException(nameof(deviceId));

            if (String.IsNullOrWhiteSpace(serviceBusNamespace))
                throw new ArgumentNullException(nameof(serviceBusNamespace));

            if (String.IsNullOrWhiteSpace(eventHub))
                throw new ArgumentNullException(nameof(eventHub));

            SasTokenApiEndpoint = apiEndpoint;
            DeviceId = deviceId;
            ServiceBusNamespace = serviceBusNamespace;
            EventHub = eventHub;
        }

        private async Task EnsureSasToken()
        {
            if (!String.IsNullOrWhiteSpace(sasToken))
                return;

            HttpClient http = new HttpClient();
            var response = await http.GetAsync($"{SasTokenApiEndpoint}Token?deviceId={DeviceId}&hub={EventHub}&ServiceNamespace={ServiceBusNamespace}");
            sasToken = (await response.Content.ReadAsStringAsync()).Replace("\"", "");
        }

        public async void PostPayload(T payload)
        {
            // create uri to device specific event hub endpoint
            string url = $"{EventHub}/publishers/{DeviceId}/messages";

            // Create client
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://{ServiceBusNamespace}.servicebus.windows.net/")
            };

            await EnsureSasToken();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", sasToken);

            string serializedPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            content.Headers.Add("ContentType", "application/json");

            var response = await httpClient.PostAsync(url, content);
        }
    }

}
