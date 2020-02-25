using MailSender.Reports;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{ 
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var report = new TestReport();
            report.CreatePackage("Report.docx");
        }
    }
}
