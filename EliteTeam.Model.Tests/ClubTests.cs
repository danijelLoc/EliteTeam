using NUnit.Framework;

namespace EliteTeam.Model.Tests
{
    public class ClubTests
    {

        [Test]
        public void TestName()
        {
            Assert.Throws<ClubInvalidNameException>(delegate { new Club("", "RMA", "Rghz", Tactic.counterAttack); });
            Assert.Throws<ClubInvalidNameException>(delegate { new Club("   ", "RMA", "Rghz", Tactic.counterAttack); });
            Assert.Throws<ClubInvalidNameException>(delegate { new Club("Re", "RMA", "Rghz", Tactic.counterAttack); });
            Assert.DoesNotThrow(delegate { new Club("Real", "RMA", "Rghz", Tactic.counterAttack); });
            Club club = new Club(" Real Madrid  ", "RMA", "Rtag", Tactic.counterAttack);
            Assert.AreEqual("Real Madrid", club.Name); // trim spaces
        }

        [Test]
        public void TestShortName()
        {
            Assert.Throws<ClubInvalidShortNameException>(delegate { new Club("Real Madrid", "", "Rghz", Tactic.counterAttack); });
            Assert.Throws<ClubInvalidShortNameException>(delegate { new Club("Real Madrid", "R", "Rghz", Tactic.counterAttack); });
            Assert.Throws<ClubInvalidShortNameException>(delegate { new Club("Real Madrid", "RMADRID", "Rghz", Tactic.counterAttack); });
            Assert.DoesNotThrow(delegate { new Club("Real Madrid", "RMA", "Rghz", Tactic.counterAttack); });
            Club club = new Club("Real Madrid", "  RMA ", "Rtag", Tactic.counterAttack);
            Assert.AreEqual("RMA", club.ShortName); // trim spaces
            club.ShortName = "rmd";
            Assert.AreEqual("RMD", club.ShortName); // upper case
        }
        [Test]
        public void TestManagerName()
        {
            Assert.Throws<HumanNameLengthException>(delegate { new Club("Real Madrid", "RMA", "", Tactic.counterAttack); });
            Assert.Throws<HumanNameLengthException>(delegate { new Club("Real Madrid", "RMA", "R", Tactic.counterAttack); });
            Assert.Throws<HumanNameLengthException>(delegate { new Club("Real Madrid", "RMA", "R ", Tactic.counterAttack); });
            Assert.DoesNotThrow(delegate { new Club("Real Madrid", "RMA", "Rgar", Tactic.counterAttack); });
        }

        [Test]
        public void TestSigned()
        {
            Club club = new Club("Real Madrid", "  RMA ", "Rtagdrd", Tactic.counterAttack);
            // transfers are done through controllers that are checking for consistancy with both player and club repos
            // final change is done in those repositories who are the only ones to change models directly like this 
            club.SignPlayer("TEST_MBAPPE_ID");
            Assert.AreEqual("TEST_MBAPPE_ID", club.ClubSquad[0]);
            Assert.AreEqual(1, club.ClubSquad.Count);
        }

        [Test]
        public void TestFired()
        {
            Club club = new Club("FC Barcelona", "FCB", "Xsdrge", Tactic.possesion);
            club.SignPlayer("TEST_DEMBELE_ID");
            club.FirePlayer("TEST_DEMBELE_ID");
            Assert.AreEqual(0, club.ClubSquad.Count);
        }
    }
}