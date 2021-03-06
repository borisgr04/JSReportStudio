﻿using jsreport.Binary;
using jsreport.Local;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleJsReportServer
{
    class Program
    {
        static async task Main(string[] args)
        {
            var rs = new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .RunInDirectory(Path.Combine(Directory.GetCurrentDirectory(),"jsreport"))
                .KillRunningJsReportProcesses()
                .Configure(cfg=>cfg.CreateSamples().FileSystemStore())
                .AsWebServer()
                .RedirectOutputToConsole()
                .Create();


            await rs.StartAsync();
            Console.ReadKey();
            await rs.KillAsync();
        }
    }
}
