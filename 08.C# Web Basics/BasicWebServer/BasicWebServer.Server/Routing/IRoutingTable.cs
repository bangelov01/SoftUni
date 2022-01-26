using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string url, Func<Request, Response> responseFunction);
        IRoutingTable MapGet(string url, Func<Request, Response> responseFunction);
        IRoutingTable MapPost(string url, Func<Request, Response> responseFunction);
    }
}
