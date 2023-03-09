using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareSikkerhedSymmetriskKryptering
{
    public partial class Form1 : Form
    {
        Encryption encrypt = new Encryption();
        ComboBoxHandler combo = new ComboBoxHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerateKeyIV_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithm sym;

            sym = combo.Generate(comboBox1.Text);

            textBoxKey.Text = Convert.ToBase64String(sym.Key);
            textBoxIV.Text = Convert.ToBase64String(sym.IV);
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithm sym;
            sym = combo.Generate(comboBox1.Text);

            sym.Key = Convert.FromBase64String(textBoxKey.Text);
            sym.IV = Convert.FromBase64String(textBoxIV.Text);

            var encrypted = encrypt.Encrypt(Encoding.ASCII.GetBytes(textBoxPlainTextASCII.Text), sym);   
            textBoxCipherASCII.Text = Convert.ToBase64String(encrypted);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithm sym;
            sym = combo.Generate(comboBox1.Text);
            sym.Key = Convert.FromBase64String(textBoxKey.Text);
            sym.IV = Convert.FromBase64String(textBoxIV.Text);

            byte[] decrypt = encrypt.Decrypt(Convert.FromBase64String(textBoxCipherASCII.Text), sym);

            textBoxCipherHEX.Text = Encoding.Default.GetString(decrypt);
        }
    }
}
