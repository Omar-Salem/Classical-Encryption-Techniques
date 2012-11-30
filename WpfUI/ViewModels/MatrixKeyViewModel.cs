using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data;

namespace WpfUI
{
    public class MatrixKeyViewModel : ViewModelBase
    {
        #region Member Variables

        DataTable _matrix;
        readonly IMatrixEntryForm _matrixEntryForm;

        #endregion

        #region Constructor

        public MatrixKeyViewModel(IMatrixEntryForm matrixEntryForm, int matrixSize)
        {
            this._matrix = CreateMatrix(matrixSize);
            this._matrixEntryForm = matrixEntryForm;
        }

        private DataTable CreateMatrix(int matrixSize)
        {
            DataTable matrix = new DataTable();

            for (int i = 0; i < matrixSize; i++)
            {
                matrix.Columns.Add();
            }
            for (int i = 0; i < matrixSize; i++)
            {
                matrix.Rows.Add(matrix.NewRow());
            }

            return matrix;
        }

        #endregion

        #region Properties

        public DataTable Matrix
        {
            get { return _matrix; }
            set
            {
                if (_matrix != value)
                {
                    _matrix = value;
                    OnPropertyChanged("Matrix");
                }
            }
        }

        #endregion

        #region Commands

        public ICommand ReturnMatrix
        {
            get { return new RelayCommand(ReturnMatrixExecute, () => true); }
        }

        #endregion

        #region Command Methods

        void ReturnMatrixExecute()
        {
            _matrixEntryForm.Close();
        }

        #endregion
    }
}