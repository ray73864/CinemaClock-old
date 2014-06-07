using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using Newtonsoft.Json;
using Grapevine;

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

            /* Turn the timer off while we prepare everything necessary */
            clockTimer.Enabled = false;

            clockAppConfig = new ClockAppConfig();

            /* Load the default / saved config for the clock itself - profileroot, webroot, etc... */
            defaultAppConfig();

            /* Preload all discovered Json Profiles into the necessary class objects */
            preloadJsonProfiles();

            /* Run the Web and REST servers */
            runBackgroundWorkers();

            /* Finally we have finished doing stuff, re-enable the timer to let the clock do stuff! */
            clockTimer.Enabled = true;

            pnlClock.Invalidate();
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
            clockRestServer.Start();
            clockRestServer.WebRoot = clockAppConfig.WebRoot;

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
                /*
                measure = gGraphics.MeasureString(theText, gTextFont, thePanel.Width, sf);

                gFontSize = 100;
                gTextFont = new Font(theFont, gFontSize);

                while (autoFontSize)
                {
                    measure = gGraphics.MeasureString(theText, gTextFont, thePanel.Width, sf);

                    if (measure.Width > thePanel.Width || measure.Height > thePanel.Height)
                    {
                        gFontSize = gFontSize - 1;
                        gTextFont = new Font(theFont, gFontSize);
                    }
                    else
                    {
                        autoFontSize = false;
                    }
                }
                 */
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
            pnlClock.Invalidate();
            if (settings.TopOnColour1 != settings.TopOffColour1) { pnlTopText.Invalidate(); }
            if (settings.BottomOnColour1 != settings.BottomOffColour1) { pnlBottomText.Invalidate(); }
            lblBatteryPercent.Text = battery.getBatteryCharge().ToString() + "%";
            lblChargerStatus.Text = battery.getPowerStatus();
        }

        private void pnlClock_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel(pnlClock, e, DateTime.Now.ToString("h:mm tt"), settings.BottomFont, settings.BottomFontSize, false, ColorTranslator.FromHtml(clockAppConfig.ClockColour), ColorTranslator.FromHtml(clockAppConfig.ClockColour));
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
        }
    }
}