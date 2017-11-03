using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using JsonData;
using System.Linq;
using rapi;
namespace MusicApi
{
    public class Program
    {
        public static void Main(string[] args)

        {
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            IWebHost host = new WebHostBuilder()

                // ContentRoot tells our webserver where to find the project files
                .UseContentRoot(Directory.GetCurrentDirectory())
                // This line tells the WebHost to use Kestrel
                .UseKestrel()
                .UseStartup<Startup>()
                // Completes the initialization of the WebHost
                .Build();
            // Here the WebHost starts up the web app
            host.Run();
        }
    }
}
