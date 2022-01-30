using NUnit.Framework;
using System;

namespace EliteTeam.Model.Tests
{
    public class PlayerTests
    {
        Stats stats = RandomPlayerFactory.RandomStats(PlayerPosition.attacker);

        [Test]
        public void TestName()
        {
            Assert.Throws<HumanNameLengthException>(delegate { new Player(PlayerPosition.attacker, "", 23, "Croatia", stats); });
            Assert.Throws<HumanNameLengthException>(delegate { new Player(PlayerPosition.attacker, " e ", 23, "Croatia", stats); });
            Assert.DoesNotThrow(delegate { new Player(PlayerPosition.attacker, "Yi", 23, "Croatia", stats); });
            Player player = new Player(PlayerPosition.attacker, "Liam", 23, "England", stats);
            Assert.AreEqual("Liam", player.Name); // trim spaces
        }

        [Test]
        public void TestAge()
        {
            Assert.Throws<PlayerAgeException>(delegate { new Player(PlayerPosition.attacker, "Jozo", 16, "Croatia", stats); });
            Assert.Throws<NegativeAgeException>(delegate { new Player(PlayerPosition.attacker, "Jozo", -1, "Croatia", stats); });
            Assert.Throws<PlayerAgeException>(delegate { new Player(PlayerPosition.attacker, "Jozo", 50, "Croatia", stats); });
            Player player = new Player(PlayerPosition.attacker, "Liam", 23, "England", stats);
            Assert.AreEqual(23, player.Age);
        }

        [Test]
        public void TestCountry()
        {
            Assert.Throws<CountryNameLengthException>(delegate { new Player(PlayerPosition.attacker, "Yi", 23, "C", stats); });
            Assert.DoesNotThrow(delegate { new Player(PlayerPosition.attacker, "Take", 23, "Japan", stats); });
        }

        [Test]
        public void TestStats()
        {
            Assert.Throws<ArgumentNullException>(delegate { new Player(PlayerPosition.attacker, "Jozo", 17, "Croatia", null); });
            Assert.DoesNotThrow(delegate { new Player(PlayerPosition.attacker, "Jozo", 17, "Croatia", stats); });
        }
    }
}