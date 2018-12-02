using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Braslets
{
    class PortalFetcher
    {
        private WebBrowser _br;
        public PortalFetcher()
        {
        }

        /// <summary>
        /// Extract all anchor tags using AngleSharp
        /// </summary>
        public IEnumerable<string> ExtractById(string html, string elementID)
        {
            List<string> tags = new List<string>();

            var parser = new HtmlParser();
            var document = parser.Parse(html);
            foreach (IElement element in document.QuerySelectorAll("#"+ elementID))
            {
                tags.Add(element.ToString());
            }

            return tags;
        }

        public async void Test()
        {
            // Setup the configuration to support document loading
            var config = Configuration.Default.WithDefaultLoader();
            // Load the names of all The Big Bang Theory episodes from Wikipedia
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
            // Asynchronously get the document in a new context using the configuration
            var document = await BrowsingContext.New(config).OpenAsync(address);
            // This CSS selector gets the desired content
            var cellSelector = "tr.vevent td:nth-child(3)";
            // Perform the query to get all cells with the content
            var cells = document.QuerySelectorAll(cellSelector);
            // We are only interested in the text - select it with LINQ
            var titles = cells.Select(m => m.TextContent);

           // Console.WriteLine(string.Join(", ", titles));
        }

        public async void Authorize()
        {
            HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
                {
                    { "txtUserName", "ctigran" },
                    { "txtUserPassword", "dream666" },
                    { "txtTimeOffset", "6" },
                    { "loginType", "0" },
                    { "loginLan", "en-us" },
                    { "hidRememberPwd", "1" }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://mini361.com/Login/SignIn", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.Write(responseString);
            runBrowserThread();
            //Thread.Sleep(1000);

            //var responseString1 = await client.GetStringAsync("http://mini361.com/Apply/Dashboard?DeviceId=34184F1854385617");

            //var test = ExtractById(responseString1, "Heart");

        }

        public void runBrowserThread()
        {
            var th = new Thread(() => {
                Thread.Sleep(10000);
                var br = new WebBrowser();
                br.DocumentCompleted += browser_DocumentCompleted;
                br.Navigate(new Uri(@"http://mini361.com/Apply/Dashboard?DeviceId=34184F1854385617"));
                
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                Console.WriteLine("Natigated to {0}", e.Url);
            }
        }

        public void Login()
        {
            string postData = "txtUserName=" + "ctigran"
            + "&txtUserPassword=" + "dream666"
            + "&txtTimeOffset=" + "6"
            + "&loginType=" + "0"
            + "&loginLan=" + "en-us"
            + "&hidRememberPwd=" + "1";
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(postData);
            _br.Navigate(@"http://mini361.com/Login/SignIn", string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
        }

        public void GoToUrl()
        {
            _br.Navigate(new Uri(@"http://mini361.com/Apply/Dashboard?DeviceId=34184F1854385617"));
        }
    }
}
