namespace CinemaClockJSON
{
    partial class ClockConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmProfileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTopText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBottomText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmJsonFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTopText = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTopColourOn = new System.Windows.Forms.Button();
            this.txtTopColourOn = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTopColourOff = new System.Windows.Forms.Button();
            this.txtTopColourOff = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTopFont = new System.Windows.Forms.Button();
            this.chkTopOverride = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTopFont = new System.Windows.Forms.TextBox();
            this.txtTopFontSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTopText = new System.Windows.Forms.TextBox();
            this.tabBottomText = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBottomColourOn = new System.Windows.Forms.Button();
            this.txtBottomColourOn = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBottomColourOff = new System.Windows.Forms.Button();
            this.txtBottomColourOff = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.chkBottomFontOverride = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBottomFont = new System.Windows.Forms.TextBox();
            this.txtBottomFontSize = new System.Windows.Forms.TextBox();
            this.txtBottomText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPowerpoint = new System.Windows.Forms.TabPage();
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.clockSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTopText.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabBottomText.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPowerpoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clockSettingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "ProfileName", true));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(604, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(537, 26);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1147, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmProfileName,
            this.clmTopText,
            this.clmBottomText,
            this.clmJsonFile});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(586, 496);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // clmProfileName
            // 
            this.clmProfileName.Text = "Profile Name";
            this.clmProfileName.Width = 160;
            // 
            // clmTopText
            // 
            this.clmTopText.Text = "Top Text";
            this.clmTopText.Width = 140;
            // 
            // clmBottomText
            // 
            this.clmBottomText.Text = "Bottom Text";
            this.clmBottomText.Width = 140;
            // 
            // clmJsonFile
            // 
            this.clmJsonFile.Text = "Json File";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTopText);
            this.tabControl1.Controls.Add(this.tabBottomText);
            this.tabControl1.Controls.Add(this.tabPowerpoint);
            this.tabControl1.Location = new System.Drawing.Point(604, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 506);
            this.tabControl1.TabIndex = 6;
            // 
            // tabTopText
            // 
            this.tabTopText.Controls.Add(this.groupBox2);
            this.tabTopText.Controls.Add(this.groupBox3);
            this.tabTopText.Controls.Add(this.groupBox1);
            this.tabTopText.Controls.Add(this.label4);
            this.tabTopText.Controls.Add(this.label1);
            this.tabTopText.Controls.Add(this.txtTopText);
            this.tabTopText.Location = new System.Drawing.Point(4, 22);
            this.tabTopText.Name = "tabTopText";
            this.tabTopText.Size = new System.Drawing.Size(663, 480);
            this.tabTopText.TabIndex = 0;
            this.tabTopText.Text = "Top Text";
            this.tabTopText.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTopColourOn);
            this.groupBox2.Controls.Add(this.txtTopColourOn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 157);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colour On";
            // 
            // btnTopColourOn
            // 
            this.btnTopColourOn.Location = new System.Drawing.Point(248, 67);
            this.btnTopColourOn.Name = "btnTopColourOn";
            this.btnTopColourOn.Size = new System.Drawing.Size(34, 23);
            this.btnTopColourOn.TabIndex = 7;
            this.btnTopColourOn.UseVisualStyleBackColor = true;
            // 
            // txtTopColourOn
            // 
            this.txtTopColourOn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "TopOnColour1", true));
            this.txtTopColourOn.Location = new System.Drawing.Point(25, 65);
            this.txtTopColourOn.Name = "txtTopColourOn";
            this.txtTopColourOn.Size = new System.Drawing.Size(216, 26);
            this.txtTopColourOn.TabIndex = 3;
            this.txtTopColourOn.TextChanged += new System.EventHandler(this.txtTopColourOn_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTopColourOff);
            this.groupBox3.Controls.Add(this.txtTopColourOff);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(336, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 157);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colour Off";
            // 
            // btnTopColourOff
            // 
            this.btnTopColourOff.Location = new System.Drawing.Point(248, 67);
            this.btnTopColourOff.Name = "btnTopColourOff";
            this.btnTopColourOff.Size = new System.Drawing.Size(34, 23);
            this.btnTopColourOff.TabIndex = 9;
            this.btnTopColourOff.UseVisualStyleBackColor = true;
            // 
            // txtTopColourOff
            // 
            this.txtTopColourOff.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "TopOffColour1", true));
            this.txtTopColourOff.Location = new System.Drawing.Point(25, 65);
            this.txtTopColourOff.Name = "txtTopColourOff";
            this.txtTopColourOff.Size = new System.Drawing.Size(216, 26);
            this.txtTopColourOff.TabIndex = 8;
            this.txtTopColourOff.TextChanged += new System.EventHandler(this.txtTopColourOff_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTopFont);
            this.groupBox1.Controls.Add(this.chkTopOverride);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTopFont);
            this.groupBox1.Controls.Add(this.txtTopFontSize);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Font Settings";
            // 
            // btnTopFont
            // 
            this.btnTopFont.Location = new System.Drawing.Point(389, 71);
            this.btnTopFont.Name = "btnTopFont";
            this.btnTopFont.Size = new System.Drawing.Size(34, 23);
            this.btnTopFont.TabIndex = 9;
            this.btnTopFont.UseVisualStyleBackColor = true;
            // 
            // chkTopOverride
            // 
            this.chkTopOverride.AutoSize = true;
            this.chkTopOverride.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.clockSettingsBindingSource, "TopFontSizeOverride", true));
            this.chkTopOverride.Location = new System.Drawing.Point(282, 25);
            this.chkTopOverride.Name = "chkTopOverride";
            this.chkTopOverride.Size = new System.Drawing.Size(162, 24);
            this.chkTopOverride.TabIndex = 5;
            this.chkTopOverride.Text = "Override Auto Font";
            this.chkTopOverride.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Font Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Font Name";
            // 
            // txtTopFont
            // 
            this.txtTopFont.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "TopFont", true));
            this.txtTopFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopFont.Location = new System.Drawing.Point(100, 69);
            this.txtTopFont.Name = "txtTopFont";
            this.txtTopFont.Size = new System.Drawing.Size(283, 26);
            this.txtTopFont.TabIndex = 2;
            // 
            // txtTopFontSize
            // 
            this.txtTopFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "TopFontSize", true));
            this.txtTopFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopFontSize.Location = new System.Drawing.Point(100, 25);
            this.txtTopFontSize.Name = "txtTopFontSize";
            this.txtTopFontSize.Size = new System.Drawing.Size(159, 26);
            this.txtTopFontSize.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(249, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Top Text Design";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text";
            // 
            // txtTopText
            // 
            this.txtTopText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "TopText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTopText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopText.Location = new System.Drawing.Point(24, 60);
            this.txtTopText.Multiline = true;
            this.txtTopText.Name = "txtTopText";
            this.txtTopText.Size = new System.Drawing.Size(618, 106);
            this.txtTopText.TabIndex = 0;
            // 
            // tabBottomText
            // 
            this.tabBottomText.Controls.Add(this.groupBox4);
            this.tabBottomText.Controls.Add(this.groupBox5);
            this.tabBottomText.Controls.Add(this.groupBox6);
            this.tabBottomText.Controls.Add(this.txtBottomText);
            this.tabBottomText.Controls.Add(this.label15);
            this.tabBottomText.Controls.Add(this.label16);
            this.tabBottomText.Location = new System.Drawing.Point(4, 22);
            this.tabBottomText.Name = "tabBottomText";
            this.tabBottomText.Padding = new System.Windows.Forms.Padding(3);
            this.tabBottomText.Size = new System.Drawing.Size(663, 480);
            this.tabBottomText.TabIndex = 1;
            this.tabBottomText.Text = "Bottom Text";
            this.tabBottomText.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBottomColourOn);
            this.groupBox4.Controls.Add(this.txtBottomColourOn);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(24, 284);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 157);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Colour On";
            // 
            // btnBottomColourOn
            // 
            this.btnBottomColourOn.Location = new System.Drawing.Point(248, 67);
            this.btnBottomColourOn.Name = "btnBottomColourOn";
            this.btnBottomColourOn.Size = new System.Drawing.Size(34, 23);
            this.btnBottomColourOn.TabIndex = 7;
            this.btnBottomColourOn.UseVisualStyleBackColor = true;
            // 
            // txtBottomColourOn
            // 
            this.txtBottomColourOn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "BottomOnColour1", true));
            this.txtBottomColourOn.Location = new System.Drawing.Point(25, 65);
            this.txtBottomColourOn.Name = "txtBottomColourOn";
            this.txtBottomColourOn.Size = new System.Drawing.Size(216, 26);
            this.txtBottomColourOn.TabIndex = 3;
            this.txtBottomColourOn.TextChanged += new System.EventHandler(this.txtBottomColourOn_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnBottomColourOff);
            this.groupBox5.Controls.Add(this.txtBottomColourOff);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(336, 284);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 157);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Colour Off";
            // 
            // btnBottomColourOff
            // 
            this.btnBottomColourOff.Location = new System.Drawing.Point(248, 67);
            this.btnBottomColourOff.Name = "btnBottomColourOff";
            this.btnBottomColourOff.Size = new System.Drawing.Size(34, 23);
            this.btnBottomColourOff.TabIndex = 9;
            this.btnBottomColourOff.UseVisualStyleBackColor = true;
            // 
            // txtBottomColourOff
            // 
            this.txtBottomColourOff.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "BottomOffColour1", true));
            this.txtBottomColourOff.Location = new System.Drawing.Point(25, 65);
            this.txtBottomColourOff.Name = "txtBottomColourOff";
            this.txtBottomColourOff.Size = new System.Drawing.Size(216, 26);
            this.txtBottomColourOff.TabIndex = 8;
            this.txtBottomColourOff.TextChanged += new System.EventHandler(this.txtBottomColourOff_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.chkBottomFontOverride);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.txtBottomFont);
            this.groupBox6.Controls.Add(this.txtBottomFontSize);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(24, 172);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(612, 106);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Font Settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(389, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 23);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // chkBottomFontOverride
            // 
            this.chkBottomFontOverride.AutoSize = true;
            this.chkBottomFontOverride.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.clockSettingsBindingSource, "BottomFontSizeOverride", true));
            this.chkBottomFontOverride.Location = new System.Drawing.Point(282, 25);
            this.chkBottomFontOverride.Name = "chkBottomFontOverride";
            this.chkBottomFontOverride.Size = new System.Drawing.Size(162, 24);
            this.chkBottomFontOverride.TabIndex = 5;
            this.chkBottomFontOverride.Text = "Override Auto Font";
            this.chkBottomFontOverride.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Font Size";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "Font Name";
            // 
            // txtBottomFont
            // 
            this.txtBottomFont.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "BottomFont", true));
            this.txtBottomFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBottomFont.Location = new System.Drawing.Point(100, 69);
            this.txtBottomFont.Name = "txtBottomFont";
            this.txtBottomFont.Size = new System.Drawing.Size(283, 26);
            this.txtBottomFont.TabIndex = 2;
            // 
            // txtBottomFontSize
            // 
            this.txtBottomFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "BottomFontSize", true));
            this.txtBottomFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBottomFontSize.Location = new System.Drawing.Point(100, 25);
            this.txtBottomFontSize.Name = "txtBottomFontSize";
            this.txtBottomFontSize.Size = new System.Drawing.Size(159, 26);
            this.txtBottomFontSize.TabIndex = 1;
            // 
            // txtBottomText
            // 
            this.txtBottomText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clockSettingsBindingSource, "BottomText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBottomText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBottomText.Location = new System.Drawing.Point(24, 60);
            this.txtBottomText.Multiline = true;
            this.txtBottomText.Name = "txtBottomText";
            this.txtBottomText.Size = new System.Drawing.Size(612, 106);
            this.txtBottomText.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "Text";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(246, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(195, 26);
            this.label16.TabIndex = 12;
            this.label16.Text = "Bottom Text Design";
            // 
            // tabPowerpoint
            // 
            this.tabPowerpoint.Controls.Add(this.button2);
            this.tabPowerpoint.Controls.Add(this.listView2);
            this.tabPowerpoint.Location = new System.Drawing.Point(4, 22);
            this.tabPowerpoint.Name = "tabPowerpoint";
            this.tabPowerpoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerpoint.Size = new System.Drawing.Size(663, 480);
            this.tabPowerpoint.TabIndex = 2;
            this.tabPowerpoint.Text = "Powerpoint Presentations";
            this.tabPowerpoint.UseVisualStyleBackColor = true;
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.Location = new System.Drawing.Point(12, 527);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadProfile.TabIndex = 7;
            this.btnLoadProfile.Text = "Load Profile";
            this.btnLoadProfile.UseVisualStyleBackColor = true;
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(6, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(651, 426);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // clockSettingsBindingSource
            // 
            this.clockSettingsBindingSource.DataSource = typeof(CinemaClockJSON.ClockSettings);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CinemaClockJSON.ClockSettings.PowerpointPresentations);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClockConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 562);
            this.Controls.Add(this.btnLoadProfile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Name = "ClockConfig";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabTopText.ResumeLayout(false);
            this.tabTopText.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabBottomText.ResumeLayout(false);
            this.tabBottomText.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPowerpoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clockSettingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clmProfileName;
        private System.Windows.Forms.ColumnHeader clmTopText;
        private System.Windows.Forms.ColumnHeader clmBottomText;
        private System.Windows.Forms.ColumnHeader clmJsonFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTopText;
        private System.Windows.Forms.TextBox txtTopText;
        private System.Windows.Forms.BindingSource clockSettingsBindingSource;
        private System.Windows.Forms.TextBox txtTopFont;
        private System.Windows.Forms.TextBox txtTopFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTopOverride;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTopFont;
        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.TabPage tabBottomText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBottomColourOn;
        private System.Windows.Forms.TextBox txtBottomColourOn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chkBottomFontOverride;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBottomFont;
        private System.Windows.Forms.TextBox txtBottomFontSize;
        private System.Windows.Forms.TextBox txtBottomText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBottomColourOff;
        private System.Windows.Forms.TextBox txtBottomColourOff;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTopColourOn;
        private System.Windows.Forms.TextBox txtTopColourOn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTopColourOff;
        private System.Windows.Forms.TextBox txtTopColourOff;
        private System.Windows.Forms.TabPage tabPowerpoint;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button2;
    }
}

