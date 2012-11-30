namespace EncryptionAlgorithms
{
    partial class frmMatrix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatrix));
            this.dgv_Matrix = new System.Windows.Forms.DataGridView();
            this.btn_Back = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Matrix
            // 
            this.dgv_Matrix.AllowUserToAddRows = false;
            this.dgv_Matrix.AllowUserToDeleteRows = false;
            this.dgv_Matrix.AllowUserToResizeColumns = false;
            this.dgv_Matrix.AllowUserToResizeRows = false;
            this.dgv_Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Matrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Matrix.Location = new System.Drawing.Point(0, 0);
            this.dgv_Matrix.Name = "dgv_Matrix";
            this.dgv_Matrix.Size = new System.Drawing.Size(292, 266);
            this.dgv_Matrix.TabIndex = 0;
            this.dgv_Matrix.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Matrix_EditingControlShowing);
            // 
            // btn_Back
            // 
            this.btn_Back.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Back.Location = new System.Drawing.Point(0, 231);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(292, 35);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "&Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMatrix
            // 
            this.AcceptButton = this.btn_Back;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.dgv_Matrix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMatrix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_Matrix;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.ErrorProvider errorProvider1;


    }
}