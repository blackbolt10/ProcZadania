namespace ProcZadania
{
    partial class rodzajUmowy
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
            this.listaUmowListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaUmowListBox
            // 
            this.listaUmowListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaUmowListBox.FormattingEnabled = true;
            this.listaUmowListBox.Location = new System.Drawing.Point(12, 51);
            this.listaUmowListBox.Name = "listaUmowListBox";
            this.listaUmowListBox.Size = new System.Drawing.Size(487, 173);
            this.listaUmowListBox.TabIndex = 1;
            this.listaUmowListBox.DoubleClick += new System.EventHandler(this.listaUmowListBox_DoubleClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(15, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(487, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wybierz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wykryto conajmmniej dwie umowy dla pracownika w danym okresie czasu, proszę wskaz" +
    "ać dla której mają zostać zapisane dane:";
            // 
            // rodzajUmowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 287);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listaUmowListBox);
            this.MinimumSize = new System.Drawing.Size(270, 220);
            this.Name = "rodzajUmowy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór umowy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaUmowListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;

    }
}