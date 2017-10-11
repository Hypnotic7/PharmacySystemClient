using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using PharmacySystemDataAccess.Models;
using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemBusinessLogic.Utilities.Encryption
{
    public class EncryptionUtility
    {
        public static string ComputePasswordHashValue(string password)
        {
            var hasBytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();

            for (var i = 0; i < hasBytes.Length; i++)
            {
                stringBuilder.Append(hasBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
