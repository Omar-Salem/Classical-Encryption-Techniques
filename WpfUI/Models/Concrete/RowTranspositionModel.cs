using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EncryptionAlgorithms;

namespace WpfUI
{
    [Export(typeof(Algorithm))]
    public class RowTranspositionModel : Algorithm
    {
        public string AlgorithmName
        {
            get { return "RowTransposition"; }
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
            get
            {
                int[] key = StringKey.Split(',').Select(int.Parse).ToArray();
                return new RowTransposition(key);
            }
        }

        public string StringKey { get; set; }

        public int NumericKey { get; set; }

        public int[,] MatrixKey { get; set; }
    }
}