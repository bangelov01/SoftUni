using BasicWebServer.Server.HTTP;
using System.Text;
using System.Web;

namespace BasicWebServer.Server.Controllers
{
    public  class HomeController : Controller
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

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => Text("Hello from server!");

        public Response Redirect() => Redirect("https://softuni.org/");

        public Response Html() => Html(HtmlForm);

        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(DownloadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName, new string[] { "https://softuni.org/", "https://judge.softuni.org/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            var requestHasCookies = Request.Cookies.Any(c => c.Name != HTTP.Session.SessionCookieName);

            var body = string.Empty;

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");

                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();

            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies Set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";

            var sessionExists = Request.Session.ContainsKey(currentDateKey); 
            
            if (sessionExists)
            {
                var currentDate = Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}");
            }

            return Text("Current date stored!");
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

            await System.IO.File.AppendAllTextAsync(fileName, responseString);
        }
    }
}
