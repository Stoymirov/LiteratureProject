using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Core.Models.TestingModels;
using LiteratureProject.Core.Services;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data;
using LiteratureProject.Infrastructure.Data.Enums;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteratureProject.Tests.Services
{
    [TestFixture]
    public class TestingServiceTests
    {
        private ApplicationDbContext context;
        private TestingService service;

        [SetUp]
        public void Setup()
        {
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            context = new ApplicationDbContext(options);
            service = new TestingService(context);
        }

        [TearDown]
        public void Teardown()
        {
           
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetAllDecksAsync_ShouldReturnAllDecks()
        {
           
            var decks = new List<DeckOfBulgarianProblems>
            {
                new DeckOfBulgarianProblems { Id = 1, Name = "Deck 1", CreatedBy = "User 1", Topic = BulgarianDeckTopic.Grammer },
                new DeckOfBulgarianProblems { Id = 2, Name = "Deck 2", CreatedBy = "User 2", Topic =BulgarianDeckTopic.Grammer }
            };

            await context.DecksOfBulgarianProblems.AddRangeAsync(decks);
            await context.SaveChangesAsync();

            var result = await service.GetAllDecksAsync();

          
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(d => d.Name == "Deck 1"), Is.True);
            Assert.That(result.Any(d => d.Name == "Deck 2"), Is.True);
        }

        [Test]
        public async Task GetCountOfProblemsByDeckId_ShouldReturnCorrectCount()
        {
            
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Deck 1",
                BulgarianProblems = new List<BulgarianProblem>
                {
                    new BulgarianProblem { Id = 1, Question = "Q1" },
                    new BulgarianProblem { Id = 2, Question = "Q2" }
                }
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

           
            var count = await service.GetCountOfProblemsByDeckId(1);

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetDeckByIdAsync_ShouldReturnCorrectDeck()
        {
           
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Deck 1",
                CreatedBy = "User 1",
                Topic = BulgarianDeckTopic.Grammer
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

           
            var result = await service.GetDeckByIdAsync(1);

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Deck 1"));
            Assert.That(result.CreatedBy, Is.EqualTo("User 1"));
        }

        [Test]
        public async Task GetNextQuestionAsync_ShouldReturnFirstQuestionForProblemNumber1()
        {
          
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Deck 1",
                BulgarianProblems = new List<BulgarianProblem>
                {
                    new BulgarianProblem { Id = 1, Question = "Q1" },
                    new BulgarianProblem { Id = 2, Question = "Q2" }
                }
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

          
            var result = await service.GetNextQuestionAsync(deckId: 1, problemNumber: 1);

         
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Question, Is.EqualTo("Q1"));
        }

        [Test]
        public async Task GetNextQuestionAsync_ShouldReturnNextQuestionForSubsequentProblems()
        {
           
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Deck 1",
                BulgarianProblems = new List<BulgarianProblem>
                {
                    new BulgarianProblem { Id = 1, Question = "Q1" },
                    new BulgarianProblem { Id = 2, Question = "Q2" }
                }
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

         
            var result = await service.GetNextQuestionAsync(deckId: 1, problemNumber: 2, problemId: 1);

         
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Question, Is.EqualTo("Q2"));
        }

        [Test]
        public async Task GetNextQuestionAsync_ShouldReturnNullWhenNoMoreQuestions()
        { 
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Deck 1",
                BulgarianProblems = new List<BulgarianProblem>
                {
                    new BulgarianProblem { Id = 1, Question = "Q1" }
                }
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

          
            var result = await service.GetNextQuestionAsync(deckId: 1, problemNumber: 2, problemId: 1);

         
            Assert.That(result, Is.Null);
        }
    }
}
