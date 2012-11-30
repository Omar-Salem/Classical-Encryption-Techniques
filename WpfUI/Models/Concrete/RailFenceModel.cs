using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EncryptionAlgorithms;

namespace WpfUI
{
    [Export(typeof(Algorithm))]
    public class RailFenceModel : Algorithm
    {
        public string AlgorithmName
        {
            get { return "RailFence"; }
        }

        public bool StringKeyVisible
        {
            get { return false; }
        }

        public bool NumericKeyVisible
        {
            get { return true; }
        }

        public bool MatrixKeyVisible
        {
            get { return false; }
        }

        public SecurityAlgorithm SecurityAlgorithm
        {
            get { return new RailFence(NumericKey); }
        }

        public string StringKey { get; set; }

        public int NumericKey { get; set; }

        public int[,] MatrixKey { get; set; }
    }
}