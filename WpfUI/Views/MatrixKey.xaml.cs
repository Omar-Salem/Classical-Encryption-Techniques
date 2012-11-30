using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel.Composition;

namespace WpfUI
{
    [Export(typeof(IMatrixEntryForm))]
    public partial class MatrixKey : Window, IMatrixEntryForm
    {
        public MatrixKey()
        {
            InitializeComponent();
        }

        void IMatrixEntryForm.Show(MatrixKeyViewModel matrixKeyViewModel)
        {
            this.DataContext = matrixKeyViewModel;
            this.ShowDialog();
        }

        void IMatrixEntryForm.Close()
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = true;
        }
    }
}