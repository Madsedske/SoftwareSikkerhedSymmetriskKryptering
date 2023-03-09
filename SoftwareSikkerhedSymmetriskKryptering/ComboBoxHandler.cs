using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareSikkerhedSymmetriskKryptering
{
    public class ComboBoxHandler
    {
        SymmetricAlgorithm mySymmetricAlg;
        KeyIV ky = new KeyIV();

        public SymmetricAlgorithm Generate(string cipher)
        {
            switch (cipher)
            {
                case "DES":
                    mySymmetricAlg = DES.Create();
                    mySymmetricAlg.Key = ky.GenerateRandomNumber(8);
                    mySymmetricAlg.IV = ky.GenerateRandomNumber(8);
                    break;
                case "3DES":
                    mySymmetricAlg = TripleDES.Create();
                    mySymmetricAlg.Key = ky.GenerateRandomNumber(16);
                    mySymmetricAlg.IV = ky.GenerateRandomNumber(8);
                    break;
                case "Rijndael":
                    mySymmetricAlg = Rijndael.Create();
                    mySymmetricAlg.Key = ky.GenerateRandomNumber(16);
                    mySymmetricAlg.IV = ky.GenerateRandomNumber(16);
                    break;
            }
            return mySymmetricAlg;
        }
    }
}
