using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutWeb.Models;

namespace WorkoutWeb.Helpers
{
  public class UserNotFoundException : Exception
  {
    public UserNotFoundException(string userName) : base(String.Format("User '{0}' not found",userName))
    {

    }
  }
  public class AuthHelper
  {
  
    public static bool ValidateUser(string userName, string passWord)
    {
      using (var db = new WWDataContext())
      {
        bool output = false;
        var user = db.Users.FirstOrDefault(u => (u.UserName == userName));
        if (user == null)
          throw (new UserNotFoundException(userName));
        //User found!
        var passwordCandidate = CryptoHelper.encryptString(passWord, user.PasswordSalt);
        output = (passwordCandidate == user.Password);
        return output;
      }
    }
  }
}