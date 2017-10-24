using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silnik.ViewModels;
using Silnik.Models;
using Silnik.Factories;

namespace Test
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void LocationAtTest()
        {
            World world = new World();
            world.AddLocation(0, -1, "Dom",
                "Tutaj jest twój dom",
                "/Silnik;component/Resources/Images/Locations/Home.png");

            Location location = world.LocationAt(-10000, 10000);
            Assert.IsNull(location);

            location = world.LocationAt(0, -1);
            Assert.IsTrue(location != null);
            Assert.IsTrue(location.Name.Contains("Dom"));
        }

        [TestMethod]
        public void CreateGameItemTest()
        {
            GameItem gi = ItemFactory.CreateGameItem(-1);
            Assert.IsNull(gi);

            gi = ItemFactory.CreateGameItem(1001);
            Assert.IsNotNull(gi);
        }

        [TestMethod]
        public void GetQuestByIDTest()
        {
            Quest q = QuestFactory.GetQuestByID(1);

            Assert.IsNotNull(q);
            Assert.IsTrue(q.ID == 1);
        }
    }
}
