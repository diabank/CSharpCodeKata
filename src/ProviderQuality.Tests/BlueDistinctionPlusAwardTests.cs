using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.AwardObjects;
using System.Collections.Generic;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class BlueDistinctionPlusAwardTests
    {
        [TestMethod]
        public void TestImmutabilityOfBlueDistinctionPlus()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueDistinctionPlusAward(0)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Distinction Plus");
            Assert.IsTrue(app.Awards[0].Quality == 80);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 80);
        }

        [TestMethod]
        public void TestBlueDistinctionPlusAwardProcessUpdate()
        {
            //Arrange
            BlueDistinctionPlusAward award = new BlueDistinctionPlusAward(10);

            //Act
            award.ProcessUpdate();

            //Assert
            Assert.AreEqual(award.ExpiresIn, 10);
            Assert.AreEqual(award.Quality, 80);
            Assert.AreEqual(award.ToString(), "Award Name: Blue Distinction Plus, Expires In: 10, Quality: 80");
        }

        // +++To Do - 1/10/2013: Discuss with team about adding more tests.  Seems like a lot of work for something
        //                       that probably won't change.  I watched it all in the debugger and know everything works
        //                       plus QA has already signed off and no one has complained.
    }
}
