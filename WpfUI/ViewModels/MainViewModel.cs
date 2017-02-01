using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncryptionAlgorithms;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Input;

namespace WpfUI
{
    public class MainViewModel : ViewModelBase
    {
        #region Member Variables

        Algorithm _selectedAlgorithm;
        string _message;
        string _processedMessage;
        string _selectedAlgorithmName;
        readonly IMatrixEntryForm _matrixEntryForm;

        #endregion

        #region Properties

        public Algorithm SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                if (_selectedAlgorithm != value)
                {
                    _selectedAlgorithm = value;
                    OnPropertyChanged("SelectedAlgorithm");
                }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public string ProcessedMessage
        {
            get { return _processedMessage; }
            set
            {
                if (_processedMessage != value)
                {
                    _processedMessage = value;
                    OnPropertyChanged("ProcessedMessage");
                }
            }
        }

        public string SelectedAlgorithmName
        {
            get { return _selectedAlgorithmName; }
            set
            {
                if (_selectedAlgorithmName != value)
                {
                    _selectedAlgorithmName = value;
                    SelectedAlgorithm = Algorithms.Single(a => a.AlgorithmName == _selectedAlgorithmName);
                    OnPropertyChanged("SelectedAlgorithmName");
                }
            }
        }

        public IEnumerable<string> AlgorithmsNames
        {
            get
            {
                return Algorithms.Select(a => a.AlgorithmName).OrderBy(a => a);
            }
        }

        [ImportMany]
        IEnumerable<Algorithm> Algorithms { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IMatrixEntryForm matrixEntryForm)
        {
            this._matrixEntryForm = matrixEntryForm;
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddPart(this);
            container.Compose(batch);
        }

        #endregion

        #region Commands

        public ICommand Encrypt
        {
            get { return new RelayCommand(EncryptExecute, () => _selectedAlgorithm != null); }
        }

        public ICommand Decrypt
        {
            get { return new RelayCommand(DecryptExecute, () => true); }
        }

        public ICommand ShowMatrixForm
        {
            get { return new RelayCommand(ShowMatrixFormExecute, () => _selectedAlgorithm != null); }
        }

        #endregion

        #region Command Methods

        void EncryptExecute()
        {
            ProcessedMessage = _selectedAlgorithm.SecurityAlgorithm.Encrypt(Message.ToLower());
        }

        void DecryptExecute()
        {
            ProcessedMessage = _selectedAlgorithm.SecurityAlgorithm.Decrypt(Message.ToLower());
        }

        void ShowMatrixFormExecute()
        {
            MatrixKeyViewModel matrixKeyViewModel = new MatrixKeyViewModel(_matrixEntryForm, _selectedAlgorithm.NumericKey);
            _matrixEntryForm.Show(matrixKeyViewModel);
        }

        #endregion
    }
}
