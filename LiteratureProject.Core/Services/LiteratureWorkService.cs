using LiteratureProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureProject.Core.Models;
using LiteratureProject.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.IdentityModel.Tokens;
using LiteratureProject.Core.Models.LiteratureWorkModels;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LiteratureProject.Core.Services
{
    public class LiteratureWorkService:ILiteratureWorkService
    {
        private ApplicationDbContext context;
        public LiteratureWorkService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AuthorServiceModel>> GetAuthorsAsync()
        {
            return await context.Authors
                .Select(x=>new AuthorServiceModel()
            {
                Id = x.Id,
                Name = x.Name,
            }   
            ).ToListAsync();
        }
        public async Task<bool> AuthorExistsAsync(int authorId)
        {
            return await context.Authors.AnyAsync(x => x.Id == authorId);
        }
        public async Task<int> CreateAsync(LiteratureWorkViewModel model,string teacherId)
        {
            var literatureWork = new LiteratureWork
            {
                Name = model.Name,
                AuthorId = model.AuthorId,
                Id = model.Id,

            };

           
            context.LiteratureWorks.Add(literatureWork);
            await context.SaveChangesAsync();

            
            if (model.Parts != null && model.Parts.Count > 0)
            {
                foreach (var part in model.Parts)
                {
                    part.LiteratureWorkId = literatureWork.Id;
                
                    part.LiteratureWork = literatureWork;
                }

              
                context.AnalysisParts.AddRange(model.Parts);
                await context.SaveChangesAsync();
            }

            var teacherLiteratureWork = new TeacherLiteratureWork
            {
                ApplicationUserId = teacherId, 
                LiteratureWorkId = literatureWork.Id
            };
            context.Set<TeacherLiteratureWork>().Add(teacherLiteratureWork);
            await context.SaveChangesAsync();
            return literatureWork.Id;

        }

        public async Task<IEnumerable<LiteratureWork>> AllLiteratureWorksByTeacherId(string teacherId)
        {
            return await context.UserLiteratureWorks
                .Include(x => x.LiteratureWork.Author)
              .Include(x => x.LiteratureWork)
            .ThenInclude(lw => lw.TeacherLiteratureWorks)
                .ThenInclude(tlw => tlw.Teacher)
         .Where(tlw => tlw.ApplicationUserId == teacherId && tlw.LiteratureWork.IsDeleted ==false)
         .Select(tlw => tlw.LiteratureWork)
         .ToListAsync();
        }

        public async Task<LiteratureWorkDetailsViewModel> GetWorkByIdAsync(int id, int part)
        {
            var literatureWork = await context.LiteratureWorks
             .Include(lw => lw.Author)
             .Include(lw => lw.AnalysisParts)
             .Include(lw => lw.TeacherLiteratureWorks)
                 .ThenInclude(tlw => tlw.Teacher)
             .FirstOrDefaultAsync(lw => lw.Id == id);

            if (literatureWork == null)
            {
                return null; 
            }

            var teacherName = literatureWork.TeacherLiteratureWorks.FirstOrDefault()?.Teacher.FirstName;

            var model = new LiteratureWorkDetailsViewModel
            {
                Id = literatureWork.Id,
                Name = literatureWork.Name,
                AuthorName = literatureWork.Author.Name,
                TeacherName = teacherName,
                AnalysisParts = literatureWork.AnalysisParts.ToList(),
                CurrentPart = part
            };

            return model;
        }

        public async Task<bool> WorkExistsAsync(int workId)
        {
            return await context.LiteratureWorks.AnyAsync(x => x.Id == workId);
            
        }

        public async Task<LiteratureWorkViewModel> GetLiteratureWorkViewModelById(int id)
        {
            var literatureWork = await context.LiteratureWorks
        .Include(lw => lw.Author)
        .Include(lw => lw.TeacherLiteratureWorks)
            .ThenInclude(tlw => tlw.Teacher)
        .Include(lw => lw.AnalysisParts) 
        .FirstOrDefaultAsync(lw => lw.Id == id);

            if (literatureWork == null)
            {
                return null;
            }

            var allAuthors = await context.Authors
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                
                .ToListAsync();
            return new LiteratureWorkViewModel
            {
                Id = literatureWork.Id,
                Name = literatureWork.Name,
                AuthorId = literatureWork.AuthorId,
                TeacherId = literatureWork.TeacherLiteratureWorks.Where(x => x.LiteratureWorkId == id).Select(x => x.Teacher.Id).FirstOrDefault()
                ,
                Parts = literatureWork.AnalysisParts.ToList()
                ,
                Authors = allAuthors
            };
        }

        public async Task<LiteratureWork> GetLiteratureWorkNormalByIdAsync(int id)
        {
            return await context.LiteratureWorks.FindAsync(id);
        }

        public async Task EditAsync(LiteratureWorkViewModel model)
        {
            var literatureModel = await context.LiteratureWorks.Include(lw => lw.AnalysisParts)
                .FirstOrDefaultAsync(x=>x.Id ==model.Id);

            if (literatureModel != null)
            {
                literatureModel.AuthorId = model.AuthorId;

                literatureModel.Name = model.Name;
                foreach (var part in literatureModel.AnalysisParts)
                {
                    var updatedPart = model.Parts.FirstOrDefault(x => x.Id == part.Id);
                    if (updatedPart != null)
                    {
                        part.Content = updatedPart.Content;
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteWorkAsync(int workId)
        {
            var house =await context.LiteratureWorks.FirstOrDefaultAsync(x => x.Id == workId);
            if(house != null)
            {
                house.IsDeleted = true;
                return true;
            }
            return false;
        }
    }
}
