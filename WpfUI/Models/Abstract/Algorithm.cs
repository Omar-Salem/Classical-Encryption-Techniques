using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncryptionAlgorithms;

namespace WpfUI
{
    public interface Algorithm
    {
        string AlgorithmName { get; }
        bool StringKeyVisible { get; }
        bool NumericKeyVisible { get; }
        bool MatrixKeyVisible { get; }
        SecurityAlgorithm SecurityAlgorithm { get; }
        string StringKey { get; set; }
        int NumericKey { get; set; }
        int[,] MatrixKey { get; set; }
    }
}