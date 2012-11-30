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
    public partial class frmEXTENDED_EUCLID : Form
    {
        public frmEXTENDED_EUCLID()
        {
            InitializeComponent();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            if (txt_first.Text.Length == 0)
            {
                errorProvider1.SetError(txt_first, "please enter first operand");
                return;
            }
            else
                errorProvider1.SetError(txt_first, "");
            if (txt_second.Text.Length == 0)
            {
                errorProvider1.SetError(txt_second, "please enter second operand");
                return;
            }
            else
                errorProvider1.SetError(txt_second, "");
            #region Variables
            int nQ = 0;
            int nA1 = 1, nA2 = 0, nA3 = int.Parse(txt_first.Text);
            int nB1 = 0, nB2 = 1, nB3 = int.Parse(txt_second.Text);
            int nPrev_A1, nPrev_A2, nPrev_A3;
            int nPrev_B1, nPrev_B2, nPrev_B3;
            #endregion

            while (true)
            {
                nPrev_A1 = nA1;
                nPrev_A2 = nA2;
                nPrev_A3 = nA3;
                nPrev_B1 = nB1;
                nPrev_B2 = nB2;
                nPrev_B3 = nB3;

                try
                {
                    nQ = nA3 / nB3;
                }
                catch(DivideByZeroException)
                {
                    MessageBox.Show("Divide By Zero Exception", "EXTENDED_EUCLID");
                    break;
                }

                nA1 = nPrev_B1;
                nA2 = nPrev_B2;
                nA3 = nPrev_B3;

                nB1 = nPrev_A1 - (nQ * nPrev_B1);
                nB2 = nPrev_A2 - (nQ * nPrev_B2);
                nB3 = nPrev_A3 - (nQ * nPrev_B3);


                if (nA3 == 1)
                {
                    MessageBox.Show("No multiplicative inverse","EXTENDED_EUCLID");
                    break;
                }
                if (nB3 == 1)
                {
                    if (nB2 < 0)
                    {
                        nB2 += nA3;
                    }
                    MessageBox.Show(nB2.ToString(),"EXTENDED_EUCLID");
                    break;
                }
            }
        }

        private void txt_first_KeyPress(object sender, KeyPressEventArgs e)
        {
            //numbers only
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
