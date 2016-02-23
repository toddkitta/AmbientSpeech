﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace AmbientSpeech
{
    public partial interface ISasToken
    {
        /// <param name='serviceNamespace'>
        /// Required.
        /// </param>
        /// <param name='eventHub'>
        /// Required.
        /// </param>
        /// <param name='keyName'>
        /// Required.
        /// </param>
        /// <param name='publisherId'>
        /// Required.
        /// </param>
        /// <param name='transport'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<string>> GetTokenWithOperationResponseAsync(string serviceNamespace, string eventHub, string keyName, string publisherId, string transport = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}