using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Services
{
    public partial class frmMain : Form
    {
        #region Global Variables

        ISecurity securityModel;
        int[,] m_Matrix;
        frmMatrix m_frmMatrix;
        bool bKeyGenerated = false;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        #region Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmb_Algorithm.SelectedIndex = 0;
        }

        private void cmb_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_PlainText.Text = txt_CypherText.Text = txt_Key.Text = string.Empty;
            switch (cmb_Algorithm.SelectedIndex)
            {
                case (int)Algorithm.Hill:
                    nm_Key.Visible = true;
                    txt_Key.Visible = false;
                    bKeyGenerated = false;
                    btn_Key.Text = "&Get Key";
                    btn_Key.Visible = true;
                    lbl_note.Visible = false;
                    break;

                case (int)Algorithm.Monoalphabetic:
                    nm_Key.Visible = false;
                    bKeyGenerated = false;
                    btn_Key.Text = "&Generate Key";
                    btn_Key.Visible = true;
                    break;

                case (int)Algorithm.Ceaser:
                case (int)Algorithm.RailFence:
                    nm_Key.Visible = true;
                    txt_Key.Visible = false;
                    btn_Key.Visible = false;
                    lbl_note.Visible = false;
                    break;

                case (int)Algorithm.Playfair:
                case (int)Algorithm.Vigenere:
                case (int)Algorithm.Autokey:
                    txt_Key.Visible = true;
                    btn_Key.Visible = false;
                    lbl_note.Visible = false;
                    break;

                case (int)Algorithm.RowTransposition:
                    txt_Key.Visible = true;
                    btn_Key.Visible = false;
                    lbl_note.Text = "Enter rows seperated by commas";
                    lbl_note.Visible = true;
                    break;
            }
        }

        private void btn_Key_Click(object sender, EventArgs e)
        {
            int nCount;
            string strColHeader;
            m_frmMatrix = new frmMatrix();
            for (int i = 0; i < nm_Key.Value; i++)
            {
                nCount = i + 1;
                strColHeader = "Col " + nCount;
                m_frmMatrix.dgv_Matrix.Columns.Add(strColHeader, strColHeader);
                m_frmMatrix.dgv_Matrix.Columns[i].Width = 40;
                m_frmMatrix.dgv_Matrix.Rows.Add();
            }
            m_Matrix = new int[(int)nm_Key.Value, (int)nm_Key.Value];
            m_frmMatrix.ShowDialog();
            bKeyGenerated = m_frmMatrix.bKeySet;
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateText(txt_PlainText, "Enter text to encrypt"))
            {
                return;
            }
            string strPlainText = txt_PlainText.Text.Trim().ToLower().Replace(" ", "");
            string strCypher = "";
            switch (cmb_Algorithm.SelectedIndex)
            {
                case (int)Algorithm.Ceaser:
                    securityModel = new Ceaser();
                    strCypher = securityModel.Encrypt(strPlainText, new object[1] { nm_Key.Value });
                    break;
                case (int)Algorithm.Autokey:
                    if (ValidateKey())
                    {
                        securityModel = new AutoKey();
                        strCypher = securityModel.Encrypt(strPlainText, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.Hill:
                    if (!bKeyGenerated)
                    {
                        MessageBox.Show("please set key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    securityModel = new Hill();
                    strCypher = securityModel.Encrypt(strPlainText, new object[2] { m_frmMatrix.m_arrMatrix, nm_Key.Value });
                    break;
                case (int)Algorithm.Monoalphabetic:
                    if (!bKeyGenerated)
                    {
                        MessageBox.Show("please set key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    securityModel = new Monoalphabetic();
                    strCypher = securityModel.Encrypt(strPlainText, new object[] { });
                    break;
                case (int)Algorithm.Playfair:
                    if (ValidateKey())
                    {
                        securityModel = new PlayFair();
                        strCypher = securityModel.Encrypt(strPlainText, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.RailFence:
                    securityModel = new RailFence();
                    strCypher = securityModel.Encrypt(strPlainText, new object[1] { nm_Key.Value });
                    break;
                case (int)Algorithm.Vigenere:
                    if (ValidateKey())
                    {
                        securityModel = new Vigenere();
                        strCypher = securityModel.Encrypt(strPlainText, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.RowTransposition:
                    if (ValidateKey())
                    {
                        securityModel = new RowTransposition();
                        strCypher = securityModel.Encrypt(strPlainText, new object[1] { txt_Key.Text });
                    }
                    break;
            }
            txt_CypherText.Text = strCypher;

        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateText(txt_CypherText, "Enter text to decrypt"))
            {
                return;
            }
            string strCypher = txt_CypherText.Text.Trim().ToLower().Replace(" ", "");
            string strPlainText = "";
            switch (cmb_Algorithm.SelectedIndex)
            {
                case (int)Algorithm.Ceaser:
                    securityModel = new Ceaser();
                    strPlainText = securityModel.Decrypt(strCypher, new object[1] { nm_Key.Value });
                    break;
                case (int)Algorithm.Autokey:
                    if (ValidateKey())
                    {
                        securityModel = new AutoKey();
                        strPlainText = securityModel.Decrypt(strCypher, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.Hill:
                    if (!bKeyGenerated)
                    {
                        MessageBox.Show("please set key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    securityModel = new Hill();
                    strPlainText = securityModel.Decrypt(strCypher, new object[2] { m_frmMatrix.m_arrMatrix, nm_Key.Value });
                    break;
                case (int)Algorithm.Monoalphabetic:
                    securityModel = new Monoalphabetic();
                    strPlainText = securityModel.Decrypt(strCypher, new object[] { });
                    break;
                case (int)Algorithm.Playfair:
                    if (ValidateKey())
                    {
                        securityModel = new PlayFair();
                        strPlainText = securityModel.Decrypt(strCypher, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.RailFence:
                    securityModel = new RailFence();
                    strPlainText = securityModel.Decrypt(strCypher, new object[1] { nm_Key.Value });
                    break;
                case (int)Algorithm.Vigenere:
                    if (ValidateKey())
                    {
                        securityModel = new Vigenere();
                        strPlainText = securityModel.Decrypt(strCypher, new object[1] { txt_Key.Text });
                    }
                    break;
                case (int)Algorithm.RowTransposition:
                    if (ValidateKey())
                    {
                        securityModel = new RowTransposition();
                        strPlainText = securityModel.Decrypt(strCypher, new object[1] { txt_Key.Text });
                    }
                    break;
            }
            txt_PlainText.Text = strPlainText;
        }

        private void txt_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //characters only
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space;

        }

        private void txt_Key_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmb_Algorithm.SelectedIndex == (int)Algorithm.RowTransposition)
            {
                //Digits and commas only
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',';
            }
            else
            {
                //characters only
                e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space;
            }
        }

        private void euclidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEXTENDED_EUCLID frmEE = new frmEXTENDED_EUCLID();
            frmEE.ShowDialog();
        }        

        #endregion

        #region Private Methods

        private bool ValidateText(TextBox txtBox, string strMessage)
        {
            if (txtBox.Text.Length == 0)
            {
                errorProvider1.SetError(txtBox, strMessage);
                return false;
            }
            else
            {
                errorProvider1.SetError(txtBox, "");
                return true;
            }
        }

        private bool ValidateKey()
        {
            if (txt_Key.Text.Length == 0)
            {
                errorProvider1.SetError(txt_Key, "Enter Key");
                return false;
            }
            else
            {
                errorProvider1.SetError(txt_Key, "");
                return true;
            }
        } 

        #endregion
    }
}