using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace CinemaClockJSON
{
    public partial class ClockConfig : Form
    {
        ClockSettings loadedClock;
        ClockDisplay myDisplay;


        public ClockConfig(ClockDisplay display, String currentProfile)
        {
            InitializeComponent();

            this.myDisplay = display;

            if (!System.IO.Directory.Exists(@"profiles"))
            {
                System.IO.Directory.CreateDirectory(@"profiles");
            }

            PaintListView(@"profiles");

            //listView1.Items[display.clockSettingsBindingSource.
        }

        public void HandlePropertyChanged(object sender, EventArgs eventArgs)
        {
            string json = JsonConvert.SerializeObject(loadedClock, Formatting.Indented);

            File.WriteAllText(@"profiles\" + loadedClock.ProfileName + ".json", json);
        }

        private void PaintListView(string p)
        {
            try
            {
                ListViewItem item = null;
                ListViewItem.ListViewSubItem[] subItems;

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(p);

                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                this.listView1.Items.Clear();
                this.listView1.BeginUpdate();

                foreach (FileInfo file in files)
                {
                    ClockSettings clock = JsonConvert.DeserializeObject<ClockSettings>(File.ReadAllText(@"profiles\" + file.Name));
                    item = new ListViewItem(clock.ProfileName);
                    subItems = new ListViewItem.ListViewSubItem[] { 
                        new ListViewItem.ListViewSubItem(item, clock.TopText), 
                        new ListViewItem.ListViewSubItem(item, clock.BottomText),
                        new ListViewItem.ListViewSubItem(item, file.Name)
                    };

                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                this.listView1.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }

            this.listView1.View = View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClockSettings clock = new ClockSettings();
            clock.ProfileName = textBox1.Text;

            string json = JsonConvert.SerializeObject(clock, Formatting.Indented);

            File.WriteAllText(@"profiles\" + clock.ProfileName + ".json", json);

            this.PaintListView(@"profiles");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string clockJson = null;
            clockSettingsBindingSource.Clear();
            myDisplay.clockSettingsBindingSource.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                clockJson = File.ReadAllText(@"profiles\" + listView1.SelectedItems[0].SubItems[3].Text);
                loadedClock = JsonConvert.DeserializeObject<ClockSettings>(clockJson);
                loadedClock.PropertyChanged += this.HandlePropertyChanged;
                clockSettingsBindingSource.Add(loadedClock);
                myDisplay.clockSettingsBindingSource.Add(loadedClock);

                if (loadedClock.presentations != null)
                {
                    /*foreach (ClockSettings.PowerpointPresentations presentation in loadedClock.presentations)
                    {
                        listView2.Items.Add(presentation.presentationName);
                    }*/
                }
            }
        }

        private void txtBottomColourOn_TextChanged(object sender, EventArgs e)
        {
            btnBottomColourOn.BackColor = Color.FromArgb(int.Parse(txtBottomColourOn.Text));
        }

        private void txtBottomColourOff_TextChanged(object sender, EventArgs e)
        {
            btnBottomColourOff.BackColor = Color.FromArgb(int.Parse(txtBottomColourOff.Text));
        }

        private void txtTopColourOn_TextChanged(object sender, EventArgs e)
        {
            btnTopColourOn.BackColor = Color.FromArgb(int.Parse(txtTopColourOn.Text));
        }

        private void txtTopColourOff_TextChanged(object sender, EventArgs e)
        {
            btnTopColourOff.BackColor = Color.FromArgb(int.Parse(txtTopColourOff.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
