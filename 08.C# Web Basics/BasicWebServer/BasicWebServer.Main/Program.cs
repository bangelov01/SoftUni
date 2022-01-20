using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

namespace BasicWebServer.Main
{
    public class Program
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

        private const string FileName = "content.txt";

        public static async Task Main()
        {
            await DownloadSitesAsTextFile(FileName, new string[] { "https://softuni.org/", "https://judge.softuni.org/" });

            var server = new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from the server!"))
                    .MapGet("/HTML", new HtmlResponse(HtmlForm))
                    .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                    .MapPost("/HTML", new TextResponse("", AddFormDataAction))
                    .MapGet("/Content", new HtmlResponse(DownloadForm))
                    .MapPost("/Content", new TextFileResponse(FileName))
                    .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction)));

            await server.Start();
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            var requestHasCookies = request.Cookies.Any();

            var body = string.Empty;

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");

                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                body = cookieText.ToString();
            }
            else
            {
                body = "<h1>Cookies Set!</h1>";
            }

            response.Body = body;

            if(!requestHasCookies)
            {
                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
            }
        }

        private static async Task<string> DownloadWebsiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebsiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responseString = string.Join(Environment.NewLine + new String('-', 100), responses);

            await File.AppendAllTextAsync(fileName, responseString);
        }
    }
}