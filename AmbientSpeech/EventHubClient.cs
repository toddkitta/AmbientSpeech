using Newtonsoft.Json;
using System;
using System.Net;
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
        public string PolicyName { get; }

        private string sasToken = null;

        public EventHubClient(string apiEndpoint, string serviceBusNamespace, string eventHub, string policyName, string deviceId)
        {
            if (String.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentNullException(nameof(apiEndpoint));

            if (String.IsNullOrWhiteSpace(serviceBusNamespace))
                throw new ArgumentNullException(nameof(serviceBusNamespace));

            if (String.IsNullOrWhiteSpace(eventHub))
                throw new ArgumentNullException(nameof(eventHub));

            if (String.IsNullOrWhiteSpace(policyName))
                throw new ArgumentNullException(nameof(policyName));

            if (String.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentNullException(nameof(deviceId));

            SasTokenApiEndpoint = apiEndpoint;
            DeviceId = deviceId;
            ServiceBusNamespace = serviceBusNamespace;
            EventHub = eventHub;
            PolicyName = policyName;
        }

        private async Task EnsureSasToken()
        {
            if (!String.IsNullOrWhiteSpace(sasToken))
                return;

            HttpClient http = new HttpClient();
            var response = await http.GetAsync($"{SasTokenApiEndpoint}/api/v1/sastoken/{ServiceBusNamespace}/{EventHub}/{PolicyName}/{DeviceId}");
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

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // time to get a new token
                sasToken = null;
                await EnsureSasToken();

                // try again
                response = await httpClient.PostAsync(url, content);
            }
        }
    }

}
