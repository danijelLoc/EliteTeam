using NUnit.Framework;
using EliteTeam.MemoryBasedDAL;
using EliteTeam.Model;

namespace EliteTeam.MamoryBasedDAL.Tests
{
    public class PlayerepositoryTests
    {
        PlayerRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = PlayerRepository.Shared;
        }

        [TearDown]
        public void Cleanup()
        {
            repository.deleteAllPlayers();
        }

        [Test]
        public void TestAddingPlayer()
        {
            Player player1 = new Player(PlayerPosition.attacker, "Aamir Khan", 32, "India", RandomPlayerFactory.RandomStats(PlayerPosition.attacker), AIFactory.CreateAI(PlayerPosition.attacker));
            // same names are not that rare amongst players
            Player playerSameName = new Player(PlayerPosition.defender, "Aamir Khan", 23, "Pakistan", RandomPlayerFactory.RandomStats(PlayerPosition.defender));
            playerSameName.PlayerAI = AIFactory.CreateAI(playerSameName.Position); // AI can be given or changed when needed

            repository.addPlayer(player1);
            Assert.DoesNotThrow(delegate { repository.addPlayer(playerSameName); });

            Assert.AreEqual("Aamir Khan", repository.getPlayerByID(player1.Id).Name);
            Assert.AreEqual(32, repository.getPlayerByID(player1.Id).Age);
            Assert.AreEqual(2, repository.getAllPlayers().Count);

            Player playerWithNoBrain = new Player(PlayerPosition.attacker, "Pepe", 38, "Portugal", RandomPlayerFactory.RandomStats(PlayerPosition.defender));
            Assert.Throws<PlayerAIMissingException>(delegate { repository.addPlayer(playerWithNoBrain); });
        }

        [Test]
        public void TestRemovingPlayer()
        {
            Player player1 = new Player(PlayerPosition.attacker, "Aamir Khan", 32, "India", RandomPlayerFactory.RandomStats(PlayerPosition.attacker), AIFactory.CreateAI(PlayerPosition.attacker));

            repository.addPlayer(player1);
            Assert.DoesNotThrow(delegate { repository.deletePlayer(player1.Id); });
            Assert.AreEqual(0, repository.getAllPlayers().Count);

            // already deleted
            Assert.Throws<PlayerIdMissingException>(delegate { repository.deletePlayer(player1.Id); });

        }

        [Test]
        public void TestSigningAndLeavingTheClub()
        {
            Player player1 = new Player(PlayerPosition.attacker, "Aamir Khan", 32, "India", RandomPlayerFactory.RandomStats(PlayerPosition.attacker), AIFactory.CreateAI(PlayerPosition.attacker));
            repository.addPlayer(player1);
            // consistancy between clubs and players are controllers job
            // controllers(playerC clubC) call both repositories and update players and clubs after signing or resignation
            repository.playerSignedForClub(player1.Id, "TEST_CLUB_ID"); // only testing saving changes on player repo part
            Assert.AreEqual("TEST_CLUB_ID", repository.getPlayerByID(player1.Id).ClubId);

            Assert.Throws<PlayerIsTakenException>(delegate { repository.playerSignedForClub(player1.Id, "TEST_CLUB2_ID"); }); // player must leave first club before signing for new one
            // direct transfers between clubs are not possible in this application, only CLUB1 -> FREE_AGENT -> CLUB2

            repository.playerLeavesClub(player1.Id);
            Assert.AreEqual(null, repository.getPlayerByID(player1.Id).ClubId);
            Assert.Throws<PlayerIsFreeAgentException>(delegate { repository.playerLeavesClub(player1.Id); }); // player already left the club
        }

        [Test]
        public void TestUpdatingPlayer()
        {
            Player player1 = new Player(PlayerPosition.attacker, "Aamir Khan", 32, "India", RandomPlayerFactory.RandomStats(PlayerPosition.attacker), AIFactory.CreateAI(PlayerPosition.attacker));
            repository.addPlayer(player1);
            repository.updatePlayerStatsAndName(player1.Id, player1.Stats, "Amir Khan");
            Assert.AreEqual("Amir Khan", repository.getPlayerByID(player1.Id).Name);

            // trying to update non existant player
            Assert.Throws<PlayerIdMissingException>(delegate { repository.updatePlayerStatsAndName("iddd", null, ""); });
        }
    }
}