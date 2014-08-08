using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutWeb.Helpers;

namespace WorkoutWeb.Tests
{
  public class AuthHelperTest
  {
    private const string VALIDUSER = "lacour";
    private const string INVALIDUSER = "mlacour";

    private const string VALIDPASSWORD = "clara";
    private const string INVALIDPASSWORD = "222";

    [TestMethod]
    public void ValidateUser_Success()
    {
      bool expected = true;
      var result = AuthHelper.ValidateUser(VALIDUSER, VALIDPASSWORD);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ValidateUser_InvalidPassword()
    {
      bool expected = false;
      var result = AuthHelper.ValidateUser(VALIDUSER, INVALIDPASSWORD);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(UserNotFoundException))]
    public void ValidateUser_InvalidUser()
    {
      bool expected = false;
      var result = AuthHelper.ValidateUser(INVALIDUSER, VALIDPASSWORD);
    }



  }
}
