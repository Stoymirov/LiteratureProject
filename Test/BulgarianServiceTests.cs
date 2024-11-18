using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Core.Services;
using LiteratureProject.Data;
using NUnit.Framework;
using Moq;
using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Enums;
using LiteratureProject.Core.Contracts;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
namespace Test
{
    
    [TestFixture]
    public class BulgarianServiceTests
    {
       
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddDeckAsync_ShouldAddDeck_WhenValidModelIsProvided()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
    var mockContext = new ApplicationDbContext(options);

    var service = new BulgarianService(mockContext);

    var model = new DeckFormModel { Name = "New Deck", CreatedBy = "user123", SelectedTopic = BulgarianDeckTopic.Punctuation };
    var userId = "user123";

    
    var result = await service.AddDeckAsync(model, userId);

    
    Assert.That(result, Is.Not.EqualTo(0));
            var addedDeck = await mockContext.DecksOfBulgarianProblems
                                      .FirstOrDefaultAsync(d => d.Name == "New Deck");
            Assert.That(addedDeck,Is.Not.Null);
            Assert.That("New Deck",Is.EqualTo(addedDeck.Name));
            Assert.That("user123", Is.EqualTo(addedDeck.CreatedBy));
        }


        [Test]
        public async Task AddProblemAsync_ShouldAddProblem_WhenValidModelIsProvided()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
            var mockContext = new ApplicationDbContext(options);
            var service = new BulgarianService(mockContext);
           
            var model = new ProblemFormModel
            {
                Question = "What is a cat?",
                Answer1 = "love",
                Answer2 = "hatred",
                Answer3 = "animal",
                Answer4 = "roblox",
                Explanation = "cats don't exist.",
                IsAnswer1Correct = true,
                IsAnswer2Correct = false,
                IsAnswer3Correct = false,
                IsAnswer4Correct = false,
                DeckOfProblemsId = 1
            };

            var result = await service.AddProblemAsync(model);

            Assert.That(result, Is.Not.EqualTo(0)); 
            var addedProblem = await mockContext.BulgarianProblems
                                                .FirstOrDefaultAsync(p => p.Question == "What is a cat?");
            Assert.That(addedProblem, Is.Not.Null);
            Assert.That(addedProblem.Question, Is.EqualTo("What is a cat?"));
        }

    }
}