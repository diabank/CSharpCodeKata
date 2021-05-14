using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console.AwardObjects;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class BlueFirstAwardTests
    {
        [TestMethod]
        public void TestBlueFirstAwardProcessUpdate()
        {
            //Arrange
            BlueFirstAward award = new BlueFirstAward(15, 10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 14);
            Assert.AreEqual(award.Quality, 11);
            Assert.AreEqual(award.ToString(), "Award Name: Blue First, Expires In: 14, Quality: 11");
        }

        [TestMethod]
        public void TestBlueFirstAwardProcessUpdateWithQualityUpperLimit()
        {
            //Arrange
            BlueFirstAward award = new BlueFirstAward(20, 50);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 19);
            Assert.AreEqual(award.Quality, 50);
            Assert.AreEqual(award.ToString(), "Award Name: Blue First, Expires In: 19, Quality: 50");
        }
    }
}
