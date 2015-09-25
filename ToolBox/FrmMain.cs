using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Windows.Forms;                                     


namespace ToolBox
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public class ProgramDL 
        {
            public string Name     { get; set; }
            public string Category { get; set; }
            public string File     { get; set; }                    
            public string Dl       { get; set; }
        }

        //TODO: Exceptions
        //TODO: Categories for programs

        public List<ProgramDL> ProgramList = new List<ProgramDL>();

        private async void Updater()
        {
            try
            {
                //
                //very poorly written
                if (File.Exists("_Database.json"))
                {
                    File.Delete("Database.json");
                    File.Move("_Database.json", "Database.json");
                }
                string json = File.ReadAllText(@"Database.json");
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(json);
                ulong localVersion = (ulong)dict["Fileversion"];

                var webClient = new WebClient();
                json = webClient.DownloadString(dict["Mostrecent"]);
                jss = new JavaScriptSerializer();
                dict = jss.Deserialize<Dictionary<string, dynamic>>(json);
                ulong currentVersion = (ulong)dict["Fileversion"];

                if (localVersion < currentVersion)
                {
                    if (MessageBox.Show("Your program database is obsolete, do you want to update?",
                        "Database Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                         DialogResult.Yes)
                    {
                        await webClient.DownloadFileTaskAsync(dict["Mostrecent"], "_Database.json");

                        if (MessageBox.Show("Do you want to restart the program to apply the update??",
                            "Database Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                            DialogResult.Yes)
                        {
                            Close();
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {           
                string message = "Update Server could not be reached. \n" + ex.ToString();
                string caption = "Update Error";            
                DialogResult exception = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                          
            }

            //http://zerozero.schedar.uberspace.de/Database.json
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           Updater();
             
            //Size = new Size(Size.Width, 350);
            //Database.json is read
            //{"Programs":
            //  [
            //    {"Name":"Skype", "DL":"http://download.skype.com/7b01e67d58d947c79090bb373ba48030/SkypeSetup.exe"},
            //	  {"Name":"     ", "DL":" "}
            //  ]
            //}
            string json = File.ReadAllText(@"Database.json");
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(json);

            //One checkbox and one ProgramDL per program
            foreach (var value in dict["Programs"])
            {
                ProgramDL program = new ProgramDL();      
                
                cbProgramList.Items.Add(value["Name"]); 

                program.Name     = value["Name"];
                program.Category = value["Category"];
                program.File     = value["File"];
                program.Dl       = value["DL"];
                ProgramList.Add(program);
            }                                                 
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {

            progressDownloaded.Value = 0;
            double p = 100.0;
            p = (double)(p / cbProgramList.CheckedItems.Count);

            btnCheck.Enabled = false;
            btnNext.Enabled = false;
            btnUncheck.Enabled = false;
            cbProgramList.Enabled = false;

            for (int i = 0; i < cbProgramList.CheckedItems.Count; ++i)
                {
                                                            
                    string _uri = ProgramList[i].Dl;
                    Uri uri = new Uri(@_uri);
                    string name = ProgramList[i].File;
                    if (!File.Exists(name))
                    {
                        try
                        {
                            //cbProgramList.SelectedItem = Color.Orange;
                            WebClient client = new WebClient();
                            await client.DownloadFileTaskAsync(uri, @"Downloads\" + name);
                            //cbProgramList.SelectedItem
                            //((CheckBox)control).ForeColor = Color.Green;
                        }
                        catch
                        {
                            //download failed
                            //((CheckBox)control).ForeColor = Color.Red;
                        }
                    
                    }
                    else
                    {
                        //was passiert wenn die datei schon existiert
                    }
                progressDownloaded.Value = (int)(i*p);
            }

            progressDownloaded.Value = 100;

            btnCheck.Enabled = true;
            btnNext.Enabled = true;
            btnUncheck.Enabled = true;
            cbProgramList.Enabled = true;
                 
        }

        private void btnCheck_Click(object sender, EventArgs e)
        { 
            for (int i = 0; i < cbProgramList.Items.Count; i++)
            {
                cbProgramList.SetItemChecked(i,true);
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {   
            for (int i = 0; i < cbProgramList.Items.Count; i++)
            {
                cbProgramList.SetItemChecked(i,false);
            }
        }

        [Serializable]
        private class HttpException : Exception
        {
            public HttpException()
            {
            }

            public HttpException(string message) : base(message)
            {
            }

            public HttpException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }       
    }
}