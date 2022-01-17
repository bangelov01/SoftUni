﻿using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [Method.GET] = new(),
                [Method.POST] = new(),
                [Method.PUT] = new(),
                [Method.DELETE] = new(),

            };
        }

        public IRoutingTable Map(string url, Method method, Response response) =>
            method switch
            {
                Method.GET => this.MapGet(url, response),
                Method.POST => this.MapPost(url, response),
                _ => throw new InvalidOperationException($"Method {method} is not supported.")
            };

        public IRoutingTable MapGet(string url, Response response)
        {
            NullValidator.Validate(url, nameof(url));
            NullValidator.Validate(response, nameof(response));

            this.routes[Method.GET][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            NullValidator.Validate(url, nameof(url));
            NullValidator.Validate(response, nameof(response));

            this.routes[Method.POST][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) || 
                !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
