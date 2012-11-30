using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EncryptionAlgorithms;

namespace WpfUI
{
    [Export(typeof(Algorithm))]
    public class HillModel : Algorithm
    {
        public string AlgorithmName
        {
            get { return "Hill Cypher"; }
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
            get { return true; }
        }

        public SecurityAlgorithm SecurityAlgorithm
        {
            get { return new Hill(MatrixKey); }
        }

        public string StringKey { get; set; }

        public int NumericKey { get; set; }

        public int[,] MatrixKey { get; set; }
    }
}