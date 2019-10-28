using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace E_Commerce_App.Helpers
{
    public class PsswordHelper
    {
        /*
         * public string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, Scope);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }
        */

        


        /*public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, Scope);
            return Encoding.Unicode.GetString(decrypted);
        }*/
    }
}