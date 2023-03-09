using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareSikkerhedSymmetriskKryptering
{
    public class Encryption
    {
        public byte[] Encrypt(byte[] plainText, SymmetricAlgorithm symmetric)
        {         
            // Create the streams used for encryption.
            MemoryStream msEncrypt = new MemoryStream();

            CryptoStream csEncrypt = new CryptoStream(msEncrypt, symmetric.CreateEncryptor(), CryptoStreamMode.Write);
            csEncrypt.Write(plainText, 0, plainText.Length);
            csEncrypt.Close();
            return msEncrypt.ToArray();
        }

        public byte[] Decrypt(byte[] message, SymmetricAlgorithm symmetric)
        {
            byte[] plaintText = new byte[message.Length];

            MemoryStream msDecrypt = new MemoryStream(message);

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, symmetric.CreateDecryptor(), CryptoStreamMode.Read);
            csDecrypt.Read(plaintText, 0, message.Length);
            csDecrypt.Close();

            return plaintText;
        }
    }
}
