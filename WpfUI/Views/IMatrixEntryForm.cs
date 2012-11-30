using System;

namespace WpfUI
{
    public interface IMatrixEntryForm
    {
        void Show(MatrixKeyViewModel matrixKeyViewModel);
        void Close();
    }
}