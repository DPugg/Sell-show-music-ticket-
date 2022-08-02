using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Band.ManageApp
{
    public partial class EncryptPass : Form
    {
        public EncryptPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*encodeTxt.Text = Encrypt(plainTxt.Text);*/
            label.Text = encodeTxt.Text.Length.ToString();
            textBox1.Text = Decrypt(encodeTxt.Text);
/*            label1.Text = (encodeTxt.Text.Equals("+NAaaqZmYnnKU0sUFnLmqvQGrI/LWMkALa4fmbHWL/Y3pFpdc=")) ? "true" : "false";
*/        }
        public string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }
        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
