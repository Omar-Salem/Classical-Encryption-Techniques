namespace EncryptionAlgorithms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.nm_Key = new System.Windows.Forms.NumericUpDown();
            this.txt_CypherText = new System.Windows.Forms.TextBox();
            this.txt_PlainText = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.cmb_Algorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.lbl_note = new System.Windows.Forms.Label();
            this.btn_Key = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.euclidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nm_Key)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(31, 258);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(100, 51);
            this.btn_Encrypt.TabIndex = 21;
            this.btn_Encrypt.Text = "&Encrypt";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // nm_Key
            // 
            this.nm_Key.Location = new System.Drawing.Point(117, 148);
            this.nm_Key.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_Key.Name = "nm_Key";
            this.nm_Key.ReadOnly = true;
            this.nm_Key.Size = new System.Drawing.Size(100, 20);
            this.nm_Key.TabIndex = 2;
            this.nm_Key.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txt_CypherText
            // 
            this.txt_CypherText.Location = new System.Drawing.Point(117, 224);
            this.txt_CypherText.Multiline = true;
            this.txt_CypherText.Name = "txt_CypherText";
            this.txt_CypherText.Size = new System.Drawing.Size(195, 30);
            this.txt_CypherText.TabIndex = 3;
            this.txt_CypherText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Text_KeyPress);
            // 
            // txt_PlainText
            // 
            this.txt_PlainText.Location = new System.Drawing.Point(117, 97);
            this.txt_PlainText.Multiline = true;
            this.txt_PlainText.Name = "txt_PlainText";
            this.txt_PlainText.Size = new System.Drawing.Size(195, 30);
            this.txt_PlainText.TabIndex = 1;
            this.txt_PlainText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Text_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(28, 231);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(40, 13);
            this.lbl2.TabIndex = 18;
            this.lbl2.Text = "Cypher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Key";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(28, 100);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(28, 13);
            this.lbl.TabIndex = 15;
            this.lbl.Text = "Text";
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.Location = new System.Drawing.Point(212, 258);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(100, 51);
            this.btn_Decrypt.TabIndex = 22;
            this.btn_Decrypt.Text = "&Decrypt";
            this.btn_Decrypt.UseVisualStyleBackColor = true;
            this.btn_Decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
            // 
            // cmb_Algorithm
            // 
            this.cmb_Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Algorithm.FormattingEnabled = true;
            this.cmb_Algorithm.Items.AddRange(new object[] {
            "Ceaser Cipher",
            "Autokey",
            "Hill Cipher",
            "Monoalphabetic",
            "Playfair Cipher",
            "Rail Fence Cipher",
            "Vigenere",
            "Row Transposition"});
            this.cmb_Algorithm.Location = new System.Drawing.Point(117, 57);
            this.cmb_Algorithm.Name = "cmb_Algorithm";
            this.cmb_Algorithm.Size = new System.Drawing.Size(121, 21);
            this.cmb_Algorithm.TabIndex = 0;
            this.cmb_Algorithm.SelectedIndexChanged += new System.EventHandler(this.cmb_Algorithm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Algorithm";
            // 
            // txt_Key
            // 
            this.txt_Key.Location = new System.Drawing.Point(117, 148);
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(100, 20);
            this.txt_Key.TabIndex = 2;
            this.txt_Key.Visible = false;
            this.txt_Key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Key_KeyPress);
            // 
            // lbl_note
            // 
            this.lbl_note.AutoSize = true;
            this.lbl_note.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_note.Location = new System.Drawing.Point(131, 200);
            this.lbl_note.Name = "lbl_note";
            this.lbl_note.Size = new System.Drawing.Size(0, 13);
            this.lbl_note.TabIndex = 25;
            this.lbl_note.Visible = false;
            // 
            // btn_Key
            // 
            this.btn_Key.Location = new System.Drawing.Point(117, 174);
            this.btn_Key.Name = "btn_Key";
            this.btn_Key.Size = new System.Drawing.Size(75, 39);
            this.btn_Key.TabIndex = 26;
            this.btn_Key.UseVisualStyleBackColor = true;
            this.btn_Key.Visible = false;
            this.btn_Key.Click += new System.EventHandler(this.btn_Key_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.euclidToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // euclidToolStripMenuItem
            // 
            this.euclidToolStripMenuItem.Name = "euclidToolStripMenuItem";
            this.euclidToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.euclidToolStripMenuItem.Text = "Extended Euclidean";
            this.euclidToolStripMenuItem.Click += new System.EventHandler(this.euclidToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 315);
            this.Controls.Add(this.btn_Key);
            this.Controls.Add(this.lbl_note);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Algorithm);
            this.Controls.Add(this.btn_Decrypt);
            this.Controls.Add(this.btn_Encrypt);
            this.Controls.Add(this.txt_CypherText);
            this.Controls.Add(this.txt_PlainText);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txt_Key);
            this.Controls.Add(this.nm_Key);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classical Encryption Techniques";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nm_Key)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.NumericUpDown nm_Key;
        private System.Windows.Forms.TextBox txt_CypherText;
        private System.Windows.Forms.TextBox txt_PlainText;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.ComboBox cmb_Algorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.Label lbl_note;
        private System.Windows.Forms.Button btn_Key;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem euclidToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;



    }
}

