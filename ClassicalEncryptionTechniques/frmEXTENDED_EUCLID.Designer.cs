namespace Services
{
    partial class frmEXTENDED_EUCLID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEXTENDED_EUCLID));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_first = new System.Windows.Forms.TextBox();
            this.txt_second = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Find = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Operand";
            // 
            // txt_first
            // 
            this.txt_first.Location = new System.Drawing.Point(144, 61);
            this.txt_first.Name = "txt_first";
            this.txt_first.Size = new System.Drawing.Size(100, 20);
            this.txt_first.TabIndex = 1;
            this.txt_first.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_first_KeyPress);
            // 
            // txt_second
            // 
            this.txt_second.Location = new System.Drawing.Point(144, 112);
            this.txt_second.Name = "txt_second";
            this.txt_second.Size = new System.Drawing.Size(100, 20);
            this.txt_second.TabIndex = 3;
            this.txt_second.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_first_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second Operand";
            // 
            // btn_Find
            // 
            this.btn_Find.Location = new System.Drawing.Point(92, 176);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(87, 50);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.Text = "&Find";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEXTENDED_EUCLID
            // 
            this.AcceptButton = this.btn_Find;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btn_Find);
            this.Controls.Add(this.txt_second);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_first);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEXTENDED_EUCLID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXTENDED_EUCLID";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_first;
        private System.Windows.Forms.TextBox txt_second;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}