namespace ProcZadania
{
    partial class Modyfikator_Rejestru
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
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.hasloTextBox = new System.Windows.Forms.TextBox();
            this.instancjaTextBox = new System.Windows.Forms.TextBox();
            this.bazaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.sciezkaLabel = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(67, 25);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(245, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // hasloTextBox
            // 
            this.hasloTextBox.Location = new System.Drawing.Point(67, 51);
            this.hasloTextBox.Name = "hasloTextBox";
            this.hasloTextBox.Size = new System.Drawing.Size(245, 20);
            this.hasloTextBox.TabIndex = 2;
            // 
            // instancjaTextBox
            // 
            this.instancjaTextBox.Location = new System.Drawing.Point(67, 77);
            this.instancjaTextBox.Name = "instancjaTextBox";
            this.instancjaTextBox.Size = new System.Drawing.Size(245, 20);
            this.instancjaTextBox.TabIndex = 3;
            // 
            // bazaTextBox
            // 
            this.bazaTextBox.Location = new System.Drawing.Point(67, 103);
            this.bazaTextBox.Name = "bazaTextBox";
            this.bazaTextBox.Size = new System.Drawing.Size(245, 20);
            this.bazaTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Baza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Instancja";
            // 
            // zapiszButton
            // 
            this.zapiszButton.Location = new System.Drawing.Point(127, 129);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(75, 23);
            this.zapiszButton.TabIndex = 9;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Location = new System.Drawing.Point(240, 129);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(72, 23);
            this.zamknijButton.TabIndex = 10;
            this.zamknijButton.Text = "Zamknij";
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // sciezkaLabel
            // 
            this.sciezkaLabel.AutoSize = true;
            this.sciezkaLabel.Location = new System.Drawing.Point(12, 9);
            this.sciezkaLabel.Name = "sciezkaLabel";
            this.sciezkaLabel.Size = new System.Drawing.Size(88, 13);
            this.sciezkaLabel.TabIndex = 11;
            this.sciezkaLabel.Text = "Scieżka rejestru: ";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 129);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 25);
            this.testButton.TabIndex = 12;
            this.testButton.Text = "Test danych ";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // Modyfikator_Rejestru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.ControlBox = false;
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.sciezkaLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.hasloTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.instancjaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bazaTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Modyfikator_Rejestru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modyfikator rejestru";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox hasloTextBox;
        private System.Windows.Forms.TextBox instancjaTextBox;
        private System.Windows.Forms.TextBox bazaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Label sciezkaLabel;
        private System.Windows.Forms.Button testButton;


    }
}