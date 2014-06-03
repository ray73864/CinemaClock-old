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
        public ClockProfileState cps = new ClockProfileState();
        public ClockSettings settings;
        ClockConfig myConfig;
        public static ClockRestServer clockRestServer = new ClockRestServer();
        Battery battery = new Battery();
        int i = 0;
        int j = 0;
        public static HttpListener server = new HttpListener();
        public static string startUpPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string webRoot = "\\webroot\\";
        Thread webServerThread, restServerThread;
        

        public ClockDisplay()
        {
            InitializeComponent();

            clockTimer.Enabled = false;

            /* Preload all json profiles */
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"profiles");

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                ClockSettings clock = JsonConvert.DeserializeObject<ClockSettings>(File.ReadAllText(@"profiles\" + file.Name));

                try
                {
                    cps.Profiles.Add(new ClockProfiles(clock.ProfileName, clock));
                }
                catch (NullReferenceException nre) {  }
            }

            cps.LoadedProfile = cps.Profiles[0].ProfileSettings;
            settings = cps.LoadedProfile;

            /* Start the Web Server */
            /* Prepare the HttpListener */
            server.Prefixes.Add("http://localhost:80/");
            server.Start();

            webServerThread = new Thread(new ThreadStart(webClientListener));
            webServerThread.Start();

            clockRestServer.myClockDisplay = this;
            clockRestServer.myClockConfig = myConfig;

            clockRestServer.Start();
            clockRestServer.WebRoot = startUpPath + webRoot;

            restServerThread = new Thread(new ThreadStart(restClientListener));
            restServerThread.Start();

            clockTimer.Enabled = true;

            pnlClock.Invalidate();
        }

        public static void restClientListener()
        {
            while (clockRestServer.IsListening)
            {
                Thread.Sleep(3000);
            }

            clockRestServer.Stop();
        }

        public static void webClientListener()
        {
            while (true)
            {
                try
                {
                    HttpListenerContext request = server.GetContext();
                    ThreadPool.QueueUserWorkItem(processWebRequest, request);
                }
                catch (Exception e) {  }
            }
        }

        public static void processWebRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;
                string filename = context.Request.RawUrl;

                if ( filename.Equals("/") ) { filename = "index.html"; }

                filename = filename.Replace("/", "\\");
                //string path = Path.Combine(startUpPath + webRoot, filename);
                string path = startUpPath + webRoot + filename;
                byte[] msg;

                if (!File.Exists(path))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    msg = File.ReadAllBytes(startUpPath + webRoot + "error.html");
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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            myConfig = new ClockConfig(this, "test");
            myConfig.ShowDialog();
            myConfig.Dispose();

            if ((ClockSettings)clockSettingsBindingSource.Current != null)
            {
                this.settings = (ClockSettings)clockSettingsBindingSource.Current;
            }

            pnlTopText.Invalidate();
            pnlBottomText.Invalidate();
        }

        private void PaintThisPanel(Panel thePanel, PaintEventArgs e, String theText, String theFont, int theFontSize, Boolean overrideFontSize, Color colour1, Color colour2)
        {
            StringFormat sf = new StringFormat();
            Font gTextFont;
            SizeF measure;
            int gFontSize = theFontSize;
            Graphics gGraphics = this.CreateGraphics();
            Boolean autoFontSize = false;
            
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Color colourToUse = (colour1 == colour2) ? colour1 : ((DateTime.Now.Second % 2) == 0) ? colour1 : colour2;

            Rectangle gRect = new Rectangle(1, 1, thePanel.Width, thePanel.Height);
            LinearGradientBrush gBrush = new LinearGradientBrush(gRect, colourToUse, colourToUse, LinearGradientMode.Horizontal);

            gTextFont = new Font(theFont, gFontSize);

            measure = gGraphics.MeasureString(theText, gTextFont, thePanel.Width, sf);

            gFontSize = 100;
            gTextFont = new Font(theFont, gFontSize);

            while (autoFontSize == false)
            {
                measure = gGraphics.MeasureString(theText, gTextFont, thePanel.Width, sf);

                if (measure.Width > thePanel.Width || measure.Height > thePanel.Height)
                {
                    gFontSize = gFontSize - 1;
                    gTextFont = new Font(theFont, gFontSize);
                }
                else
                {
                    autoFontSize = true;
                }
            }

            e.Graphics.DrawString(theText, gTextFont, gBrush, gRect, sf);

            gGraphics.Dispose();
        }

        private void pnlTopText_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel((Panel)sender, e, settings.TopText, settings.TopFont, settings.TopFontSize, false, Color.FromArgb(settings.TopOnColour1), Color.FromArgb(settings.TopOffColour1));
        }

        private void pnlBottomText_Paint(object sender, PaintEventArgs e)
        {
            PaintThisPanel((Panel)sender, e, settings.BottomText, settings.BottomFont, settings.BottomFontSize, false, Color.FromArgb(settings.BottomOnColour1), Color.FromArgb(settings.BottomOffColour1));
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
            PaintThisPanel(pnlClock, e, DateTime.Now.ToString("h:mm tt"), settings.BottomFont, settings.BottomFontSize, false, Color.Yellow, Color.Yellow);
            lblSeconds.Text = DateTime.Now.ToString("ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webServerThread.Abort();
            restServerThread.Abort();
            clockRestServer.Stop();
            server.Stop();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}