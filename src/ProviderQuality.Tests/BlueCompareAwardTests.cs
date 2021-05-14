using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console.AwardObjects;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class BlueCompareAwardTests
    {
        [TestMethod]
        public void TestBlueCompareAwardProcessUpdateWithExpiredInGreaterThan0()
        {
            //Arrange
            BlueCompareAward award = new BlueCompareAward(15, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 14);
            Assert.AreEqual(award.Quality, 11);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Compare, Expires In: 14, Quality: 11");
        }

        [TestMethod]
        public void TestBlueCompareAwardProcessUpdateWithExpiredInEqualsTo0()
        {
            //Arrange
            BlueCompareAward award = new BlueCompareAward(0, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, -1);
            Assert.AreEqual(award.Quality, 0);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Compare, Expires In: -1, Quality: 0");
        }

        [TestMethod]
        public void TestBlueCompareAwardProcessUpdateWithExpiredInlessThan0()
        {
            //Arrange
            BlueCompareAward award = new BlueCompareAward( -5, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, -6);
            Assert.AreEqual(award.Quality, 0);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Compare, Expires In: -6, Quality: 0");
        }

        [TestMethod]
        public void TestBlueCompareAwardProcessUpdateWithExpiredInBetween6And10Included()
        {
            //Arrange
            BlueCompareAward award = new BlueCompareAward(9, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 8);
            Assert.AreEqual(award.Quality, 12);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Compare, Expires In: 8, Quality: 12");
        }

        [TestMethod]
        public void TestBlueCompareAwardProcessUpdateWithExpiredInBetween0And5Included()
        {
            //Arrange
            BlueCompareAward award = new BlueCompareAward(3, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 2);
            Assert.AreEqual(award.Quality, 13);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Compare, Expires In: 2, Quality: 13");
        }
    }
}
