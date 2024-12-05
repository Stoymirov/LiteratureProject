using LiteratureProject.Core.Models;
using LiteratureProject.Core.Services;
using LiteratureProject.Data;
using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class LiteratureWorkServiceTests
{
    private ApplicationDbContext mockContext;
    private LiteratureWorkService service;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        mockContext = new ApplicationDbContext(options);
        service = new LiteratureWorkService(mockContext);
    }
    //[Test]
    //public async Task GetAuthorsAsync_ReturnsAllAuthors()
    //{
       
    //    mockContext.Authors.Add(new Author { Id = 1, Name = "Author1" });
    //    mockContext.Authors.Add(new Author { Id = 2, Name = "Author2" });
    //    await mockContext.SaveChangesAsync();

    //    var result = await service.GetAuthorsAsync();

    //    Assert.That(result, Is.Not.Null);
    //    Assert.That(result, Has.Exactly(2).Items);
    //    Assert.That(result, Has.Some.Matches<Author>(a => a.Name == "Author1"));
    //    Assert.That(result, Has.Some.Matches<Author>(a => a.Name == "Author2"));
    //}
    [Test]
    public async Task CreateAsync_AddsLiteratureWorkAndTeacherRelation()
    {

        var teacherId = "Teacher1";
        var author = new Author { Id = 1, Name = "Author1" };
        mockContext.Authors.Add(author);
        await mockContext.SaveChangesAsync();

        var model = new LiteratureWorkViewModel
        {
            Name = "Work1",
            AuthorId = author.Id,
            Parts = new List<AnalysisPart>
        {
            new AnalysisPart { Content = "Part1" },
            new AnalysisPart { Content = "Part2" }
        }
        };


        var result = await service.CreateAsync(model, teacherId);


        var work = await mockContext.LiteratureWorks.FindAsync(result);
        Assert.That(work, Is.Not.Null);
        Assert.That(work.Name, Is.EqualTo("Work1"));

        var teacherRelation = await mockContext.UserLiteratureWorks
            .FirstOrDefaultAsync(ulw => ulw.ApplicationUserId == teacherId && ulw.LiteratureWorkId == work.Id);

        Assert.That(teacherRelation, Is.Not.Null);
    }
   
    [Test]
    public async Task GetWorkByIdAsync_ReturnsCorrectWorkDetails()
    {
       
        var author = new Author { Id = 1, Name = "Author1" };
        var work = new LiteratureWork
        {
            Id = 1,
            Name = "Work1",
            Author = author,
            AnalysisParts = new List<AnalysisPart>
        {
            new AnalysisPart { Id = 1, Content = "Part1" },
            new AnalysisPart { Id = 2, Content = "Part2" }
        }
        };

        mockContext.Authors.Add(author);
        mockContext.LiteratureWorks.Add(work);
        await mockContext.SaveChangesAsync();

        
        var result = await service.GetWorkByIdAsync(work.Id, 1);

       
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Work1"));
        Assert.That(result.AuthorName, Is.EqualTo(author.Name));
        Assert.That(result.AnalysisParts, Has.Count.EqualTo(2));
        Assert.That(result.CurrentPart, Is.EqualTo(1));
    }
    [Test]
    public async Task DeleteWorkAsync_SetsIsDeletedToTrue()
    {
        
        var work = new LiteratureWork { Id = 1, Name = "Work1", IsDeleted = false };
        mockContext.LiteratureWorks.Add(work);
        await mockContext.SaveChangesAsync();

       
        var result = await service.DeleteWorkAsync(work.Id);

     
        var deletedWork = await mockContext.LiteratureWorks.FindAsync(work.Id);
        Assert.That(result, Is.True);
        Assert.That(deletedWork, Is.Not.Null);
        Assert.That(deletedWork.IsDeleted, Is.True);
    }

    [Test]
    public async Task DeleteWorkAsync_ReturnsFalseIfWorkDoesNotExist()
    {
       
        var result = await service.DeleteWorkAsync(99);

       
        Assert.That(result, Is.False);
    }


    [TearDown]
    public void TearDown()
    {
        mockContext.Dispose();
    }
}
