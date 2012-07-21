namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum Algorithm
    {
        Ceaser = 0,
        Autokey = 1,
        Hill = 2,
        Monoalphabetic = 3,
        Playfair = 4,
        RailFence = 5,
        Vigenere = 6,
        RowTransposition = 7
    }

    internal enum Mode
    {
        Encrypt, Decrypt
    }
}