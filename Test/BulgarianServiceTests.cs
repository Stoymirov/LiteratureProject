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
    }
}