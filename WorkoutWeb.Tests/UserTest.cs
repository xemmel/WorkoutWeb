using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutWeb.Models;

namespace WorkoutWeb.Tests
{
  public class UserTest
  {
    private const string USERNAME = "Clara";
    private const string PASSWORD = "IamCute";
    private const string WRONGPASSWORD = "cuteme";
   
    [TestMethod]
    public void SetPassWordAndValidate_Success()
    {
      bool expected = true;
      var user = new User() { UserName = USERNAME };
      user.setPassword(PASSWORD);
      var result = user.Validate(PASSWORD);
      Assert.AreEqual(expected, result);
    }


    [TestMethod]
    public void SetPassWordAndValidate_Fail()
    {
      bool expected = false;
      var user = new User() { UserName = USERNAME };
      user.setPassword(PASSWORD);
      var result = user.Validate(WRONGPASSWORD);
      Assert.AreEqual(expected, result);
    }
  }
}
