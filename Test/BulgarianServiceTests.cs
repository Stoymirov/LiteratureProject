using LiteratureProject.Core.Models.BulgarianModels;
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
    public class BulgarianServiceTests
    {
        private ApplicationDbContext context;
        private BulgarianService service;

        [SetUp]
        public void Setup()
        {
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            context = new ApplicationDbContext(options);
            service = new BulgarianService(context);
        }

        [TearDown]
        public void Teardown()
        {
           
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddDeckAsync_ShouldAddDeckToDatabase()
        {
            // Arrange
            var deckModel = new DeckFormModel
            {
                Name = "Test Deck",
                SelectedTopic = BulgarianDeckTopic.ProperWriting,
                CreatedBy = "Test User"
            };

            
            var result = await service.AddDeckAsync(deckModel, "test-user-id");

            
            var deck = await context.DecksOfBulgarianProblems.FindAsync(result);
            Assert.That(deck, Is.Not.Null);
            Assert.That(deck.Name, Is.EqualTo("Test Deck"));
            Assert.That(deck.CreatedById, Is.EqualTo("test-user-id"));
        }

        [Test]
        public async Task AddProblemAsync_ShouldAddProblemToDatabase()
        {
            
            var deck = new DeckOfBulgarianProblems { Id = 1, Name = "Sample Deck" };
            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

            var problemModel = new ProblemFormModel
            {
                Question = "Sample Question",
                Answer1 = "Answer 1",
                Answer2 = "Answer 2",
                Answer3 = "Answer 3",
                Answer4 = "Answer 4",
                IsAnswer1Correct = true,
                DeckOfProblemsId = deck.Id
            };

            
            var result = await service.AddProblemAsync(problemModel);

            
            var problem = await context.BulgarianProblems.FindAsync(result);
            Assert.That(problem, Is.Not.Null);
            Assert.That(problem.Question, Is.EqualTo("Sample Question"));
            Assert.That(problem.DeckOfProblemsId, Is.EqualTo(deck.Id));
        }

        [Test]
        public async Task GetAllDecksByUserId_ShouldReturnDecksForUser()
        {
            
            var decks = new List<DeckOfBulgarianProblems>
            {
                new DeckOfBulgarianProblems { Id = 1, Name = "Deck 1", CreatedById = "user-1" },
                new DeckOfBulgarianProblems { Id = 2, Name = "Deck 2", CreatedById = "user-1" },
                new DeckOfBulgarianProblems { Id = 3, Name = "Deck 3", CreatedById = "user-2" }
            };
            await context.DecksOfBulgarianProblems.AddRangeAsync(decks);
            await context.SaveChangesAsync();
            var result = await service.GetAllDecksByUserId("user-1");

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(d => d.Name == "Deck 1"), Is.True);
            Assert.That(result.Any(d => d.Name == "Deck 2"), Is.True);
        }

        [Test]
        public async Task GetDeckByDeckIdAsync_ShouldReturnDeckWithProblems()
        {
            
            var deck = new DeckOfBulgarianProblems
            {
                Id = 1,
                Name = "Test Deck",
                BulgarianProblems = new List<BulgarianProblem>
                {
                    new BulgarianProblem { Id = 1, Question = "Q1" },
                    new BulgarianProblem { Id = 2, Question = "Q2" }
                }
            };

            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();

           
            var result = await service.GetDeckByDeckIdAsync(1);

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.BulgarianProblems.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetProblemByIdAsync_ShouldReturnCorrectProblem()
        {
           
            var problem = new BulgarianProblem
            {
                Id = 1,
                Question = "Test Question",
                Answer1 = "A1",
                Answer2 = "A2",
                Answer3 = "A3",
                Answer4 = "A4",
                IsAnswer1Correct = true
            };

            await context.BulgarianProblems.AddAsync(problem);
            await context.SaveChangesAsync();

           
            var result = await service.GetProblemByIdAsync(1);

            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Question, Is.EqualTo("Test Question"));
            Assert.That(result.IsAnswer1Correct, Is.True);
        }
    }
}
