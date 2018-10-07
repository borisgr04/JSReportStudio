using jsreport.Binary;
using jsreport.Local;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JsReportStudio
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rs = new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .RunInDirectory(Path.Combine(Directory.GetCurrentDirectory(), "jsreport"))
                .KillRunningJsReportProcesses()
                .Configure(cfg => cfg.CreateSamples().FileSystemStore())
                .AsWebServer()
                .RedirectOutputToConsole()
                .Create();


            await rs.StartAsync();
            Console.WriteLine("Por favor, abra el navegador en: http://localhost:5488");
            Console.ReadKey();
            await rs.KillAsync();

        }
    }
}
