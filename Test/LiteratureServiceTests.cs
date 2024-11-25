using Moq;
using Xunit;
using LiteratureProject.Core.Services;
using LiteratureProject.Data;
using LiteratureProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Models;
using NuGet.DependencyResolver;

namespace LiteratureProject.Tests
{
    public class LiteratureWorkServiceTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly LiteratureWorkService _service;

        public LiteratureWorkServiceTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _service = new LiteratureWorkService(_mockContext.Object);
        }

        [Test]
        public async Task GetAuthorsAsync_ShouldReturnAllAuthors()
        {
            // Arrange
            var mockAuthors = new List<Author>
            {
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Author>>();
            mockSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(mockAuthors.Provider);
            mockSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(mockAuthors.Expression);
            mockSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(mockAuthors.ElementType);
            mockSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(mockAuthors.GetEnumerator());

            _mockContext.Setup(c => c.Authors).Returns(mockSet.Object);

            // Act
            var result = await _service.GetAuthorsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, a => a.Name == "Author 1");
            Assert.Contains(result, a => a.Name == "Author 2");
        }

        [Test]
        public async Task AuthorExistsAsync_ShouldReturnTrue_WhenAuthorExists()
        {
            // Arrange
            var authorId = 1;
            _mockContext.Setup(c => c.Authors.AnyAsync(a => a.Id == authorId)).ReturnsAsync(true);

            // Act
            var result = await _service.AuthorExistsAsync(authorId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task AuthorExistsAsync_ShouldReturnFalse_WhenAuthorDoesNotExist()
        {
            // Arrange
            var authorId = 99;
            _mockContext.Setup(c => c.Authors.AnyAsync(a => a.Id == authorId)).ReturnsAsync(false);

            // Act
            var result = await _service.AuthorExistsAsync(authorId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetLiteratureWorkViewModelById_ShouldReturnCorrectModel()
        {
            // Arrange
            var literatureWorkId = 1;
            var mockLiteratureWork = new LiteratureWork
            {
                Id = literatureWorkId,
                Name = "Sample Work",
                AuthorId = 1,
                Author = new Author { Id = 1, Name = "Author 1" },
                TeacherLiteratureWorks = new List<TeacherLiteratureWork>
                {
                    new TeacherLiteratureWork { Teacher = new Teacher { Id = 1, FirstName = "Teacher 1" } }
                },
                AnalysisParts = new List<AnalysisPart>
                {
                    new AnalysisPart { Id = 1, Content = "Part 1" }
                }
            };

            var mockSet = new Mock<DbSet<LiteratureWork>>();
            mockSet.As<IQueryable<LiteratureWork>>().Setup(m => m.Provider).Returns(new List<LiteratureWork> { mockLiteratureWork }.AsQueryable().Provider);
            mockSet.As<IQueryable<LiteratureWork>>().Setup(m => m.Expression).Returns(new List<LiteratureWork> { mockLiteratureWork }.AsQueryable().Expression);
            mockSet.As<IQueryable<LiteratureWork>>().Setup(m => m.ElementType).Returns(new List<LiteratureWork> { mockLiteratureWork }.AsQueryable().ElementType);
            mockSet.As<IQueryable<LiteratureWork>>().Setup(m => m.GetEnumerator()).Returns(new List<LiteratureWork> { mockLiteratureWork }.AsQueryable().GetEnumerator());

            _mockContext.Setup(c => c.LiteratureWorks).Returns(mockSet.Object);
            _mockContext.Setup(c => c.Authors).Returns(new Mock<DbSet<Author>>().Object);

            // Act
            var result = await _service.GetLiteratureWorkViewModelById(literatureWorkId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sample Work", result.Name);
            Assert.Equal("Author 1", result.AuthorId);
            Assert.Contains(result.Parts, p => p.Content == "Part 1");
        }

        [Test]
        public async Task WorkExistsAsync_ShouldReturnTrue_WhenWorkExists()
        {
            // Arrange
            var workId = 1;
            _mockContext.Setup(c => c.LiteratureWorks.AnyAsync(lw => lw.Id == workId)).ReturnsAsync(true);

            // Act
            var result = await _service.WorkExistsAsync(workId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task DeleteWorkAsync_ShouldReturnTrue_WhenWorkIsDeleted()
        {
            // Arrange
            var workId = 1;
            var mockLiteratureWork = new LiteratureWork { Id = workId, IsDeleted = false };

            var mockSet = new Mock<DbSet<LiteratureWork>>();
            mockSet.Setup(m => m.FindAsync(workId)).ReturnsAsync(mockLiteratureWork);
            _mockContext.Setup(c => c.LiteratureWorks).Returns(mockSet.Object);

            // Act
            var result = await _service.DeleteWorkAsync(workId);

            // Assert
            Assert.True(result);
            Assert.True(mockLiteratureWork.IsDeleted);
        }

        [Test]
        public async Task DeleteWorkAsync_ShouldReturnFalse_WhenWorkDoesNotExist()
        {
            // Arrange
            var workId = 999;

            _mockContext.Setup(c => c.LiteratureWorks.FirstOrDefaultAsync(lw => lw.Id == workId)).ReturnsAsync((LiteratureWork)null);

            // Act
            var result = await _service.DeleteWorkAsync(workId);

            // Assert
            Assert.False(result);
        }
    }
}
