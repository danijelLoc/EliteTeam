using NUnit.Framework;
using EliteTeam.MemoryBasedDAL;
using EliteTeam.Model;

namespace EliteTeam.MamoryBasedDAL.Tests
{
    public class MatchResultRepositoryTests
    {
        MatchResultRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = MatchResultRepository.Shared;
        }

        [TearDown]
        public void Cleanup()
        {
            repository.deleteAll();
        }

        [Test]
        public void TestAddingMatchResult()
        {
            Club clubA = new Club("Manchester City", "MCI", "Pep Guardiola", Tactic.possesion);
            Club clubH = new Club("Manchester United", "MUN", "Ole Gunnar Solskjær", Tactic.possesion);
            MatchResult result = new MatchResult(clubH, clubA, 0, 2, new System.DateTime(2021, 11, 6));

            repository.addMatchResult(result);
            Assert.AreEqual("Manchester City", repository.getMatchResultByID(result.Id).AwayClubName);
            Assert.AreEqual(1, repository.getAllMatchResults().Count);
        }

        [Test]
        public void TestRemovingAll()
        {
            Club clubA = new Club("Manchester City", "MCI", "Pep Guardiola", Tactic.possesion);
            Club clubH = new Club("Manchester United", "MUN", "Ole Gunnar Solskjær", Tactic.possesion);
            MatchResult result = new MatchResult(clubH, clubA, 0, 2, new System.DateTime(2021, 11, 6));

            repository.addMatchResult(result);
            repository.deleteAll();
            Assert.AreEqual(0, repository.getAllMatchResults().Count);
        }
    }
}