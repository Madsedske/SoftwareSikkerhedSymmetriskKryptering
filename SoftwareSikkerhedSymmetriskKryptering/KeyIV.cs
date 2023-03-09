using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareSikkerhedSymmetriskKryptering
{
    public class KeyIV
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                rng.GetBytes(randomNumber);
                
                return randomNumber;
            }
        }

        public string PrintKey(SymmetricAlgorithm sym) 
        {
            string textKey = "";
            foreach (var c in sym.Key)
            {
                textKey = textKey + c.ToString();
            }
            return textKey;
        }

        public string PrintIV(SymmetricAlgorithm sym)
        {
            string textIV = "";
            foreach (var c in sym.IV)
            {
                textIV= textIV + c.ToString();
            }
            return textIV;
        }
    }
}
