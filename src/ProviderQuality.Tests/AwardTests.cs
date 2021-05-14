using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.CustomException;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class AwardTests
    {
        [TestMethod]
        public void TestAwardProcessUpdateWithExpiredInGreaterThan0()
        {
            //Arrange
            Award award = new Award("Test Award", 10, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 9);
            Assert.AreEqual(award.Quality, 9);
            Assert.AreEqual(award.ToString(), "Award Name: Test Award, Expires In: 9, Quality: 9");
        }

        [TestMethod]
        public void TestAwardProcessUpdateWithExpiredInEqualsTo0()
        {
            //Arrange
            Award award = new Award("Test Award", 0, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, -1);
            Assert.AreEqual(award.Quality, 8);
            Assert.AreEqual(award.ToString(), "Award Name: Test Award, Expires In: -1, Quality: 8");
        }

        [TestMethod]
        public void TestAwardProcessUpdateWithExpiredInlessThan0()
        {
            //Arrange
            Award award = new Award("Test Award", -5, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, -6);
            Assert.AreEqual(award.Quality, 8);
            Assert.AreEqual(award.ToString(), "Award Name: Test Award, Expires In: -6, Quality: 8");
        }

        /// <summary>
        /// Quality should never be lower than 0
        /// </summary>
        [TestMethod]
        public void TestAwardProcessUpdateWithQualityLowerLimit()
        {
            //Arrange
            Award award = new Award("Test Award", -5, 0);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, -6);
            Assert.AreEqual(award.Quality, 0);
            Assert.AreEqual(award.ToString(), "Award Name: Test Award, Expires In: -6, Quality: 0");
        }

        [TestMethod]
        [ExpectedException(typeof(AwardCustomException), "Invalid Quality")]
        public void TestAwardConstructorWithInvalidQualityGreaterThan50()
        {
            //Arrange //Act //Assert
            Award award = new Award("Test Award", -5, 65);
        }

        [TestMethod]
        [ExpectedException(typeof(AwardCustomException), "Invalid Quality")]
        public void TestAwardConstructorWithInvalidQualityLowerThan0()
        {
            //Arrange //Act //Assert
            Award award = new Award("Test Award", -5, -3);
        }
    }
}
