using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console.AwardObjects;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class BlueStarAwardTests
    {
        [TestMethod]
        public void TestBlueStarAwardProcessUpdate()
        {
            //Arrange
            BlueStarAward award = new BlueStarAward(15, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 14);
            Assert.AreEqual(award.Quality, 8);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Star, Expires In: 14, Quality: 8");
        }

        [TestMethod]
        public void TestBlueStarAwardProcessUpdateWithQualityLowerLimit()
        {
            //Arrange
            BlueStarAward award = new BlueStarAward(20, 1);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 19);
            Assert.AreEqual(award.Quality, 0);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Star, Expires In: 19, Quality: 0");
        }
    }
}
