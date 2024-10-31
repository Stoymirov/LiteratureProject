using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Enums;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{ 
        public class SeedData
{
    public ApplicationUser TeacherUser { get; set; }
    public ApplicationUser StudentUser { get; set; }
    public Author IvanVazov { get; set; }
    public Author AlekoKonstantinov { get; set; }
    public Author StanislavStratiev { get; set; }
    public AnalysisPart BalkanskiSindromHistory { get; set; }
    public AnalysisPart BalkanskiSindromTheme { get; set; }
    public LiteratureWork BalkanskiSindrom { get; set; }
    public LiteratureWork JelezniqtSvetilnik { get; set; }
    public TeacherLiteratureWork TabachkaBalkanskiSindrom { get; set; }

    public SeedData()
    {
        SeedUsers();
        SendAuthors();
        SeedAnalysisParts();
        SeedLiteratureWorks();
        SeedTeacherLiteratureWorks();
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();
        TeacherUser = new ApplicationUser()
        {
            Id = "dea12856-c198-4129-b3f3-b893d8395082",
            UserName = "teacher@mail.com",
            NormalizedUserName = "teacher@mail.com",
            Email = "teacher@mail.com",
            NormalizedEmail = "teacher@mail.com"
        };
        TeacherUser.PasswordHash = hasher.HashPassword(TeacherUser, "teacher123");
        StudentUser = new ApplicationUser()
        {
            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            UserName = "guest@mail.com",
            NormalizedUserName = "student@mail.com",
            Email = "student@mail.com",
            NormalizedEmail = "student@mail.com"
        };
        StudentUser.PasswordHash = hasher.HashPassword(StudentUser, "guest123");
    }

    private void SendAuthors()
    {
        IvanVazov = new()
        {
            Id = 1,
            Name = "Иван Вазов"
        };
        StanislavStratiev = new()
        {
            Id = 2,
            Name = "Станислав Стратиев"
        };
        AlekoKonstantinov = new()
        {
            Id = 3,
            Name = "Алеко Константинов"
        };
    }

    private void SeedAnalysisParts()
    {
        BalkanskiSindromHistory = new()
        {
            Content = "Написана вчера",
            Id = 1,
            LiteratureWorkId = 3,
            Name = "История на Творбата",
            Type = AnalysisPartType.HistoricalContent
        };
        BalkanskiSindromTheme = new()
        {
            Content = "За една пиеса",
            Id = 2,
            LiteratureWorkId = 3,
            Name = "Име на творбата"
           
        };
    }

    private void SeedLiteratureWorks()
    {
        BalkanskiSindrom = new()
        {
            Id = 3,
            AuthorId = 2,
            Name = "Балкански синдром",
        };
        JelezniqtSvetilnik = new()
        {
            Id = 1,
            AuthorId = 1,
            Name = "Железният Светилник"
        };

    }
    private void SeedTeacherLiteratureWorks()
    {
        TabachkaBalkanskiSindrom = new()
        {
            LiteratureWorkId = 3,
            ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082"
        };
    }
} }