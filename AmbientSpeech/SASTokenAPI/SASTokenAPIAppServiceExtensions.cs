using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace AmbientSpeech
{
    public static class SASTokenAPIAppServiceExtensions
    {
        public static SASTokenAPI CreateSASTokenAPI(this IAppServiceClient client)
        {
            return new SASTokenAPI(client.CreateHandler());
        }

        public static SASTokenAPI CreateSASTokenAPI(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new SASTokenAPI(client.CreateHandler(handlers));
        }

        public static SASTokenAPI CreateSASTokenAPI(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new SASTokenAPI(uri, client.CreateHandler(handlers));
        }

        public static SASTokenAPI CreateSASTokenAPI(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new SASTokenAPI(rootHandler, client.CreateHandler(handlers));
        }
    }
}
