using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptionAlgorithms
{
    public partial class frmMatrix : Form
    {
        public int[,] m_arrMatrix;

        public bool bKeySet = false;

        public frmMatrix()
        {
            InitializeComponent();
        }
        
        private void btn_Back_Click(object sender, EventArgs e)
        {
            int nColumns = dgv_Matrix.Columns.Count;
            if (!ValidateInput(nColumns))
                return;
            m_arrMatrix = new int[nColumns, nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    m_arrMatrix[i, j] = Convert.ToInt32(dgv_Matrix[i, j].Value);
                }
            }
            bKeySet = true;
            this.Close();
        }

        private bool ValidateInput(int nColumns)
        {
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    if (dgv_Matrix[i, j].Value == null)
                    {
                        MessageBox.Show("please enter all cells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void dgv_Matrix_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt_Cell = e.Control as TextBox;
            txt_Cell.KeyPress += new KeyPressEventHandler(txt_Cell_KeyPress);
        }

        void txt_Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numbers only
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
