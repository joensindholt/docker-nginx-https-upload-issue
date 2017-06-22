using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            await UploadHttpsFile(source: args[0], dest: args[1], loops: int.Parse(args[2]));
        }

        private static async Task UploadHttpsFile(string source, string dest, int loops)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            var client = new HttpClient(httpClientHandler);
            client.Timeout = TimeSpan.FromMinutes(30);

            for (var i = 0; i < loops; i++)
            {
                using (var fileStream = File.Open(source, FileMode.Open, FileAccess.Read))
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new StreamContent(fileStream),
                        RequestUri = new Uri(dest)
                    };

                    Console.WriteLine($"Posting {request.Content.Headers.ContentLength:N0} bytes of data to {request.RequestUri}");

                    var watch = Stopwatch.StartNew();
                    var response = await client.SendAsync(request);
                    watch.Stop();

                    Console.WriteLine($"{response.StatusCode} received after {watch.Elapsed}");
                }
            }
        }
    }
}
