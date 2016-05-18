using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Document;

namespace RuntimeJsonPopulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var pageReport = new PageReport(new FileInfo(Application.StartupPath + @"\..\..\traffic.source.rdlx"));
            var pageDocument = new PageDocument(pageReport);
            pageDocument.LocateDataSource += (evSender, evArgs) =>
            {
                // here instead of the local file reading the code should try to read the data from a web service that required credentials
                evArgs.Data = File.ReadAllText(Application.StartupPath + @"\..\..\log.traffic.sources.json");
            };
            viewer1.LoadDocument(pageDocument);
        }
    }
}
