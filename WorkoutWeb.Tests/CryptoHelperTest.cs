using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutWeb.Helpers;

namespace WorkoutWeb.Tests
{
  [TestClass]
  public class CryptoHelperTest
  {
    private const string PLAININPUT = "Clara la Cour";
    private const string INPUTSALT = "$5$4DmxAwjEF8jb9FOn";
    private const string INPUTCYPHERWITHSALT = "$5$4DmxAwjEF8jb9FOn$ywEB7q1osN80k08bHbvh9kkwu1FP.IjaBid6nWyFzg/";


    [TestMethod]
    public void encryptString_noSalt()
    {
      var result = CryptoHelper.encryptString(PLAININPUT, INPUTSALT);
      Assert.AreEqual(INPUTCYPHERWITHSALT, result);
    }
    [TestMethod]
    public void generateSalt()
    {
      var result = CryptoHelper.generateSalt();
      Assert.IsTrue(!String.IsNullOrEmpty(result), "Salt is empty");
    }

  }
}
