using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutWeb.Helpers
{
  public class CryptoHelper
  {
    public static string encryptString(string plainText, string salt)
    {
      CryptSharp.Sha256Crypter c = new CryptSharp.Sha256Crypter();
      //CryptSharp.MD5Crypter c = new CryptSharp.MD5Crypter();
      string output = "";
      if (salt.Length > 0)
        output = c.Crypt(plainText, salt);
      else
        output = c.Crypt(plainText);
      return output;
    }

    public static string generateSalt()
    {
      CryptSharp.Sha256Crypter c = new CryptSharp.Sha256Crypter();
      string output = c.GenerateSalt();
      return output;
    }
  }
}