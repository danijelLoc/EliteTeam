using NUnit.Framework;
using EliteTeam.MemoryBasedDAL;
using EliteTeam.Model;

namespace EliteTeam.MamoryBasedDAL.Tests
{
    public class ClubRepositoryTests
    {
        ClubRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = ClubRepository.Shared;
        }

        [TearDown]
        public void Cleanup()
        {
            repository.deleteAllClubs();
        }

        [Test]
        public void TestAddingClub()
        {
            Club club1 = new Club("TestCLub 1", "TES", "Test Manager 1", Tactic.counterAttack);
            Club clubSameName = new Club("TestCLub 1", "TEE", "Test Manager_", Tactic.counterAttack);
            Club clubSameShortName = new Club("TestCLub_", "TES", "Test Manager_", Tactic.counterAttack);
            Club clubSameManager = new Club("TestCLub_", "TET", "Test Manager 1", Tactic.counterAttack);
            Club club2 = new Club("TestCLub 2", "TE2", "Test Manager 2", Tactic.counterAttack);

            repository.addClub(club1);
            Assert.AreEqual("TestCLub 1", repository.getClubByID(club1.Id).Name);
            Assert.AreEqual("TES", repository.getClubByID(club1.Id).ShortName);
            Assert.AreEqual("Test Manager 1", repository.getClubByID(club1.Id).ClubManager);
            Assert.AreEqual(Tactic.counterAttack, repository.getClubByID(club1.Id).Tactic);

            Assert.Throws<ClubTakenNameException>(delegate { repository.addClub(clubSameName); });
            Assert.Throws<ClubTakenShortNameException>(delegate { repository.addClub(clubSameShortName); });
            Assert.Throws<ClubTakenManagerException>(delegate { repository.addClub(clubSameManager); });
            Assert.Throws<ClubTakenIdException>(delegate { repository.addClub(club1); });

            Assert.DoesNotThrow(delegate { repository.addClub(club2); });
            Assert.AreEqual(2, repository.getAllClubs().Count);
        }

        [Test]
        public void TestRemovingClub()
        {
            Club club = new Club("TestCLub", "TES", "Test Manager", Tactic.counterAttack);
            repository.addClub(club);

            repository.deleteClub(club.Id);
            Assert.Throws<ClubIdMissingException>(delegate { repository.deleteClub(club.Id); }); // already deleted

            Assert.AreEqual(null, repository.getClubByID(club.Id));
            Assert.AreEqual(0, repository.getAllClubs().Count);

            repository.addClub(club);
            repository.deleteClubWithName(club.Name);
            Assert.AreEqual(null, repository.getClubByID(club.Id));
            Assert.AreEqual(0, repository.getAllClubs().Count);
            Assert.AreEqual(false, repository.doesClubExists(club.Name));
        }

        [Test]
        public void TestSigningAndFireing()
        {
            Club club = new Club("TestCLub", "TES", "Test Manager", Tactic.counterAttack);
            repository.addClub(club);
            repository.clubSignedPlayer("TEST_PLAYER1_ID", club.Id);
            repository.clubSignedPlayer("TEST_PLAYER2_ID", club.Id);
            // this is not consistency test, transfer service has that obligation, it has to 
            // call both player and club repositories and save changes after transfer
            Assert.AreEqual("TEST_PLAYER1_ID", repository.getClubPlayersIds(club.Id)[0]);
            repository.clubFiredPlayer("TEST_PLAYER1_ID", club.Id);
            Assert.AreEqual("TEST_PLAYER2_ID", repository.getClubPlayersIds(club.Id)[0]);
            Assert.AreEqual(1, repository.getClubPlayersIds(club.Id).Count);

            repository.clubFiredAllPlayers(club.Id);
            Assert.AreEqual(0, repository.getClubPlayersIds(club.Id).Count);
        }

        [Test]
        public void TestUpdatingClub()
        {
            Club club1 = new Club("TestClub 1", "TE1", "Test Manager 1", Tactic.counterAttack);
            Club club2 = new Club("TestClub 2", "TE2", "Test Manager 2", Tactic.counterAttack);
            repository.addClub(club1);
            repository.addClub(club2);

            ClubDescriptor club1UpdatedInfoValid = new ClubDescriptor(club1.Id, club1.ClubSquad, "NK TestClub 1", club1.ClubManager, club1.Tactic, "NKT");
            repository.updateClub(club1UpdatedInfoValid);
            Assert.AreEqual("NK TestClub 1", repository.getClubByID(club1.Id).Name);
            Assert.AreEqual("NKT", repository.getClubByID(club1.Id).ShortName);
            Assert.AreEqual("Test Manager 1", repository.getClubByID(club1.Id).ClubManager);
            Assert.AreEqual(Tactic.counterAttack, repository.getClubByID(club1.Id).Tactic);

            // trying to update club1 using invalid data already taken  by club2
            ClubDescriptor club1UpdatedInfoTakenName = new ClubDescriptor(club1.Id, club1.ClubSquad, club2.Name, club1.ClubManager, club1.Tactic, club1.ShortName);
            ClubDescriptor club1UpdatedInfoTakenManager = new ClubDescriptor(club1.Id, club1.ClubSquad, club1.Name, club2.ClubManager, club1.Tactic, club1.ShortName);
            ClubDescriptor club1UpdatedInfoTakenShortName = new ClubDescriptor(club1.Id, club1.ClubSquad, club1.Name, club1.ClubManager, club1.Tactic, club2.ShortName);

            Assert.Throws<ClubTakenNameException>(delegate { repository.updateClub(club1UpdatedInfoTakenName); });
            Assert.Throws<ClubTakenShortNameException>(delegate { repository.updateClub(club1UpdatedInfoTakenShortName); });
            Assert.Throws<ClubTakenManagerException>(delegate { repository.updateClub(club1UpdatedInfoTakenManager); });

            // trying to update non existant club
            ClubDescriptor missingClubUpdatedInfo = new ClubDescriptor("SOME_ID", club1.ClubSquad, club1.Name, club1.ClubManager, club1.Tactic, club2.ShortName);
            Assert.Throws<ClubIdMissingException>(delegate { repository.updateClub(missingClubUpdatedInfo); });

        }
    }
}