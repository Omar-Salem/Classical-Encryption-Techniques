using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EncryptionAlgorithms;

namespace WpfUI
{
    [Export(typeof(Algorithm))]
    public class AutoKeyModel : Algorithm
    {
        public string AlgorithmName
        {
            get { return "AutoKey"; }
        }

        public bool StringKeyVisible
        {
            get { return true; }
        }

        public bool NumericKeyVisible
        {
            get { return false; }
        }

        public bool MatrixKeyVisible
        {
            get { return false; }
        }

        public SecurityAlgorithm SecurityAlgorithm
        {
            get { return new AutoKey(StringKey); }
        }

        public string StringKey { get; set; }

        public int NumericKey { get; set; }

        public int[,] MatrixKey { get; set; }
    }
}