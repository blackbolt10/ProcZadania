namespace ProcZadania
{
    partial class procentyProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(procentyProgram));
            this.panelMenu = new System.Windows.Forms.MenuStrip();
            this.plikTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikTSMI,
            this.pomocTSMI});
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.Name = "panelMenu";
            // 
            // plikTSMI
            // 
            this.plikTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.toolStripSeparator1,
            this.zamknijTSMI});
            this.plikTSMI.Name = "plikTSMI";
            resources.ApplyResources(this.plikTSMI, "plikTSMI");
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            resources.ApplyResources(this.otwórzToolStripMenuItem, "otwórzToolStripMenuItem");
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // zamknijTSMI
            // 
            this.zamknijTSMI.Name = "zamknijTSMI";
            resources.ApplyResources(this.zamknijTSMI, "zamknijTSMI");
            this.zamknijTSMI.Click += new System.EventHandler(this.zamknijTSMI_Click);
            // 
            // pomocTSMI
            // 
            this.pomocTSMI.Name = "pomocTSMI";
            resources.ApplyResources(this.pomocTSMI, "pomocTSMI");
            this.pomocTSMI.Click += new System.EventHandler(this.pomocTSMI_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Podpowiedź";
            // 
            // dataTimePicker
            // 
            resources.ApplyResources(this.dataTimePicker, "dataTimePicker");
            this.dataTimePicker.Name = "dataTimePicker";
            this.dataTimePicker.ValueChanged += new System.EventHandler(this.dataTimePicker_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // zapiszButton
            // 
            resources.ApplyResources(this.zapiszButton, "zapiszButton");
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsFormsApplication1.Properties.Resources.open_file;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            // 
            // procentyProgram
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.dataTimePicker);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelMenu);
            this.MainMenuStrip = this.panelMenu;
            this.Name = "procentyProgram";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.procentyProgram_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip panelMenu;
        private System.Windows.Forms.ToolStripMenuItem plikTSMI;
        private System.Windows.Forms.ToolStripMenuItem pomocTSMI;
        private System.Windows.Forms.ToolStripMenuItem zamknijTSMI;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.DateTimePicker dataTimePicker;
        public System.Windows.Forms.Button zapiszButton;
    }
}

