﻿using Microsoft.Extensions.Logging;
using Nexus.DataModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Extensions
{
    internal interface IJsonRpcServer
    {
        public Task<ApiVersionResponse> 
            GetApiVersionAsync(CancellationToken cancellationToken);

        public Task 
            SetContextAsync(string resourceLocator, Dictionary<string, string> configuration, CancellationToken cancellationToken);

        public Task<CatalogIdsResponse>
            GetCatalogIdsAsync(CancellationToken cancellationToken);

        public Task<CatalogResponse>
            GetCatalogAsync(string catalogId, CancellationToken cancellationToken);

        public Task<TimeRangeResponse>
            GetTimeRangeAsync(string catalogId, CancellationToken cancellationToken);

        public Task<AvailabilityResponse>
            GetAvailabilityAsync(string catalogId, DateTime begin, DateTime end, CancellationToken cancellationToken);

        public Task
            ReadSingleAsync(string resourcePath, int elementCount, DateTime begin, DateTime end, CancellationToken cancellationToken);
    }

    internal record ApiVersionResponse(int ApiVersion);
    internal record CatalogIdsResponse(string[] CatalogIds);
    internal record CatalogResponse(ResourceCatalog Catalog);
    internal record TimeRangeResponse(DateTime Begin, DateTime End);
    internal record AvailabilityResponse(double Availability);
    internal record LogMessage(LogLevel LogLevel, string Message);

    internal class RpcException : Exception
    {
        public RpcException(string message, Exception innerException = null)
            : base(message, innerException)
        {
            //
        }
    }
}
