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
using Newtonsoft.Json;

namespace CinemaClockJSON
{
    public partial class ClockDisplay : Form
    {
        ClockSettings settings = new ClockSettings();
        Battery battery = new Battery();
        int i = 0;
        int j = 0;

        public ClockDisplay()
        {
            InitializeComponent();
            pnlClock.Invalidate();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ClockConfig myConfig = new ClockConfig(this, "test");
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
            pnlTopText.Invalidate();
            pnlBottomText.Invalidate();
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}