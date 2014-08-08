using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkoutWeb.Helpers;

namespace WorkoutWeb.Models
{
  public class User
  {
    public User()
    {
      IsAdmin = false;
      Locked = false;
    }
    [Key]
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
    public bool Locked { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime? LastLogon { get; set; }

    public int FailedLogonTries { get; set; }

    public void setPassword(string clearTextPassword)
    {
      PasswordSalt = CryptoHelper.generateSalt();
      Password = CryptoHelper.encryptString(clearTextPassword, PasswordSalt);
    }

    public bool Validate(string clearTextPassword)
    {
      if (String.IsNullOrEmpty(PasswordSalt))
        return false;
      string passWordCandidate = CryptoHelper.encryptString(clearTextPassword, PasswordSalt);
      return (passWordCandidate == Password);
 
    }
  }
}