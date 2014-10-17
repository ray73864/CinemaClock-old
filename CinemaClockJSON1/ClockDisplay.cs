using Grapevine;
using Microsoft.TeamFoundation.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CinemaClockJSON
{
    public partial class ClockDisplay : Form
    {
        /* Start here, this holds the main settings information for the clock! */
        public ClockAppConfig clockAppConfig;

        public ClockProfileState cps = new ClockProfileState();
        public ClockSettings settings;
        public ClockRestServer clockRestServer = new ClockRestServer();
        Battery battery = new Battery();
        public static HttpListener server = new HttpListener();
        public static string startUpPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        BackgroundWorker webServerWorker, restServerWorker;

        public ClockDisplay()
        {
            InitializeComponent();

            /* First things first, deal with that pesky windows firewall */
            firewallConfig(true);

            /* Turn the timer off while we prepare everything necessary */
            clockTimer.Enabled = false;

            clockAppConfig = new ClockAppConfig();

            /* Load the default / saved config for the clock itself - profileroot, webroot, etc... */
            defaultAppConfig();

            /* Hide/Display panels if required */
            pnlFormControls.Visible = clockAppConfig.ShowTopBar;
            pnlPowerpoint.Visible = clockAppConfig.ShowTopBar;
            pnlSetupSlides.Visible = clockAppConfig.ShowTopBar;
            pnlBatteryInfo.Visible = clockAppConfig.ShowTopBar;

            this.KeyUp += new KeyEventHandler(OnKeyPressHandler);

            /* Preload all discovered Json Profiles into the necessary class objects */
            preloadJsonProfiles();

            /* Run the Web and REST servers */
            runBackgroundWorkers();

            lblServerIP2.Text = "http://" + getListeningIP();
            
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://" + getListeningIP();

            lblServerIP2.Links.Add(link);

            getPresentationPowerpoints();

            /* Finally we have finished doing stuff, re-enable the timer to let the clock do stuff! */
            clockTimer.Enabled = true;

            pnlClock.Invalidate();
        }

        private void getPresentationPowerpoints()
        {
            comboPresentations.Items.Clear();
            foreach (String presentation in settings.Presentations)
            {
                if (presentation != "") { comboPresentations.Items.Add(presentation.ToString()); }                
            }

            try
            {
                comboPresentations.SelectedIndex = 0;
                btnPlayPresentation.Enabled = true;
                btnEditPresentation.Enabled = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                btnPlayPresentation.Enabled = false;
                btnEditPresentation.Enabled = false;
            }
        }

        private void OnKeyPressHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void firewallConfig(bool openPorts)
        {
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);

            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
            bool firewallEnabled = mgr.LocalPolicy.CurrentProfile.FirewallEnabled;

            if (firewallEnabled)
            {
                INetFwOpenPorts ports;
                INetFwOpenPort webPort = (INetFwOpenPort)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWOpenPort"));
                INetFwOpenPort restPort = (INetFwOpenPort)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWOpenPort"));

                ports = (INetFwOpenPorts)mgr.LocalPolicy.CurrentProfile.GloballyOpenPorts;

                webPort.Port = 80;
                webPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                webPort.Name = "CinemaClockJson1";
                webPort.Enabled = openPorts;

                restPort.Port = 1234;
                restPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                restPort.Name = "CinemaClockJson1";
                restPort.Enabled = openPorts;

                if (openPorts)
                {
                    ports.Add(webPort);
                    ports.Add(restPort);
                }
                else
                {
                    ports.Remove(webPort.Port, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                    ports.Remove(restPort.Port, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                }
            }
        }

        public string getListeningIP() {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First().ToString();
        }

        private void defaultAppConfig()
        {
            if ( File.Exists(startUpPath + "\\clockconfig.json")) {
                clockAppConfig = JsonConvert.DeserializeObject<ClockAppConfig>(File.ReadAllText(startUpPath + "\\clockconfig.json"));
            }
            else
            {
                string json = JsonConvert.SerializeObject(clockAppConfig);
                File.WriteAllText(startUpPath + "\\clockconfig.json", json);
            }

            if (!Directory.Exists(clockAppConfig.ProfileRoot))
            {
                Directory.CreateDirectory(clockAppConfig.ProfileRoot);
            }
        }

        private void runBackgroundWorkers()
        {
            /* Set the Display and Config up on the REST Server itself */
            clockRestServer.myClockDisplay = this;

            /* Create the Background Workers */
            webServerWorker = new BackgroundWorker();
            restServerWorker = new BackgroundWorker();

            webServerWorker.WorkerSupportsCancellation = true;
            restServerWorker.WorkerSupportsCancellation = true;

            /* Give the Background Workers something to do */
            webServerWorker.DoWork += webServerWorker_DoWork;
            restServerWorker.DoWork += restServerWorker_DoWork;

            /* Run the Background Workers in Asyncronous mode! */
            webServerWorker.RunWorkerAsync();
            restServerWorker.RunWorkerAsync();
        }

        private void preloadJsonProfiles()
        {
            /* Preload all json profiles */
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(clockAppConfig.ProfileRoot);

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            if (files.Length == 0)
            {
                ClockSettings blankSettings = new ClockSettings();
                File.WriteAllText(clockAppConfig.ProfileRoot + "\\" + blankSettings.ProfileName + ".json", JsonConvert.SerializeObject(blankSettings));
            }

            files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                ClockSettings clock = JsonConvert.DeserializeObject<ClockSettings>(File.ReadAllText(clockAppConfig.ProfileRoot + "\\" + file.Name));

                try
                {
                    cps.Profiles.Add(new ClockProfiles(clock.ProfileName, clock));
                }
                catch (NullReferenceException nre) { }
            }

            cps.LoadedProfile = cps.Profiles[0].ProfileSettings;
            settings = cps.LoadedProfile;
        }

        void restServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            clockRestServer.WebRoot = clockAppConfig.WebRoot;
            clockRestServer.Host = getListeningIP();
            clockRestServer.Start();

            while (clockRestServer.IsListening)
            {
                Thread.Sleep(3000);
            }

            clockRestServer.Stop();
        }

        void webServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /* Start the Web Server */
            /* Prepare the HttpListener */
            server.Prefixes.Add("http://*:80/");
            server.Start();

            while (server.IsListening)
            {
                try
                {
                    HttpListenerContext request = server.GetContext();
                    ThreadPool.QueueUserWorkItem(processWebRequest, request);
                }
                catch (Exception exc) { }
            }
        }

        public void RunClockAction(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void processWebRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;
                string filename = context.Request.Url.AbsolutePath;

                if ( filename.Equals("/") ) { filename = "index.html"; }

                filename = filename.Replace("/", "\\");
                //string path = Path.Combine(startUpPath + webRoot, filename);
                string path = clockAppConfig.WebRoot + "\\" + filename;
                byte[] msg;

                if (!File.Exists(path))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    msg = File.ReadAllBytes(clockAppConfig.WebRoot + "\\" + "error.html");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    msg = File.ReadAllBytes(path);
                }

                context.Response.ContentLength64 = msg.Length;
                using (Stream s = context.Response.OutputStream)
                    s.Write(msg, 0, msg.Length);
            }
            catch {  }
        }

        private void PaintThisPanel(Panel thePanel, PaintEventArgs e, String theText, String theFont, int theFontSize, Boolean overrideFontSize, Color colour1, Color colour2)
        {
            StringFormat sf = new StringFormat();
            Font gTextFont;
            //SizeF measure;
            int gFontSize = theFontSize;
            Graphics gGraphics = this.CreateGraphics();
            //Boolean autoFontSize = true;
            
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Color colourToUse = (colour1 == colour2) ? colour1 : ((DateTime.Now.Second % 2) == 0) ? colour1 : colour2;

            Rectangle gRect = new Rectangle(1, 1, thePanel.Width, thePanel.Height);
            LinearGradientBrush gBrush = new LinearGradientBrush(gRect, colourToUse, colourToUse, LinearGradientMode.Horizontal);

            gTextFont = new Font(theFont, gFontSize);

            if (!overrideFontSize)
            {
                FontAdjustment fa = new FontAdjustment();
                gTextFont = fa.GetAdjustedFont(gGraphics, theText, gTextFont, thePanel.Width, thePanel.Height, 80, 50, true);
            }
            
            e.Graphics.DrawString(theText, gTextFont, gBrush, gRect, sf);

            gGraphics.Dispose();
        }

        private void pnlTopText_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel((Panel)sender, e, settings.TopText, settings.TopFont, settings.TopFontSize, settings.TopFontSizeOverride, ColorTranslator.FromHtml(settings.TopOnColour1), ColorTranslator.FromHtml(settings.TopOffColour1));
        }

        private void pnlBottomText_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel((Panel)sender, e, settings.BottomText, settings.BottomFont, settings.BottomFontSize, false, ColorTranslator.FromHtml(settings.BottomOnColour1), ColorTranslator.FromHtml(settings.BottomOffColour1));
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            /* Not really the best place to do these 5 tasks, but for now it will have to suffice */
            pnlFormControls.Visible = clockAppConfig.ShowTopBar;
            pnlPowerpoint.Visible = clockAppConfig.ShowTopBar;
            pnlSetupSlides.Visible = clockAppConfig.ShowTopBar;
            pnlBatteryInfo.Visible = clockAppConfig.ShowTopBar;

            getPresentationPowerpoints();

            pnlClock.Invalidate();
            if (settings.TopOnColour1 != settings.TopOffColour1) { pnlTopText.Invalidate(); }
            if (settings.BottomOnColour1 != settings.BottomOffColour1) { pnlBottomText.Invalidate(); }
            lblBatteryPercent.Text = battery.getBatteryCharge().ToString() + "%";
            lblChargerStatus.Text = battery.getPowerStatus();
        }

        private void pnlClock_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel(pnlClock, e, DateTime.Now.ToString("h:mm tt"), clockAppConfig.ClockFont, clockAppConfig.ClockFontSize, false, ColorTranslator.FromHtml(clockAppConfig.ClockColour), ColorTranslator.FromHtml(clockAppConfig.ClockColour));
            lblSeconds.Text = DateTime.Now.ToString("ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ClockDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            webServerWorker.CancelAsync();
            restServerWorker.CancelAsync();

            clockRestServer.Stop();
            server.Stop();

            firewallConfig(false);
        }

        public void RunPowerpointPresentation(string presentation)
        {
            if (File.Exists(presentation))
            {
                Process myProcess = Process.Start(presentation);
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += myProcess_Exited;
            }
        }

        void myProcess_Exited(object sender, EventArgs e)
        {
            
        }

        private void btnSetupWide_Click(object sender, EventArgs e)
        {
            RunPowerpointPresentation(clockAppConfig.SetupWide);
        }

        private void btnSetupStd_Click(object sender, EventArgs e)
        {
            RunPowerpointPresentation(clockAppConfig.SetupTele);
        }

        private void btnSetupScope_Click(object sender, EventArgs e)
        {
            RunPowerpointPresentation(clockAppConfig.SetupScope);
        }

        private void lblServerIP2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }

        private void btnConfigForm_Click(object sender, EventArgs e)
        {

        }

        private void btnPlayPresentation_Click(object sender, EventArgs e)
        {
            RunPowerpointPresentation(comboPresentations.SelectedItem.ToString());
        }

        private void btnEditPresentation_Click(object sender, EventArgs e)
        {
            String theNewFile;
            String newExtension = ".ppt";
            FileInfo oldPowerpoint;
            String selectedPresentation = comboPresentations.SelectedItem.ToString();
            settings.editPresentation = selectedPresentation;

            settings.testPresentation = new FileInfo(selectedPresentation);
            if (File.Exists(selectedPresentation))
            {
                theNewFile = settings.testPresentation.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(settings.testPresentation.FullName) + newExtension;
                oldPowerpoint = new FileInfo(theNewFile);

                if (File.Exists(theNewFile))
                {
                    oldPowerpoint.Delete();
                }

                settings.testPresentation.MoveTo(theNewFile);

                Process myProcess = Process.Start(theNewFile);
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += editPresentation_Exited;
            }
        }

        void editPresentation_Exited(object sender, EventArgs e)
        {
            settings.testPresentation.MoveTo(settings.editPresentation);
            settings.editPresentation = "";
        }
    }
}