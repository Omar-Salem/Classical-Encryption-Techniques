namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISecurity
    {
        string Encrypt(string token, object[] param);
        string Decrypt(string token, object[] param);
    }
}
