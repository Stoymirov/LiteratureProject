﻿using LiteratureProject.Core.Models;
using LiteratureProject.Core.Models.LiteratureWorkModels;
using LiteratureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LiteratureProject.Core.Contracts
{
    public interface ILiteratureWorkService
    {
        public Task<IEnumerable<AuthorServiceModel>> GetAuthorsAsync();
        public Task<bool> AuthorExistsAsync(int authorId);
        public Task<int> CreateAsync(LiteratureWorkViewModel literatureWork,string teacherId);
        public Task<IEnumerable<LiteratureWork>> AllLiteratureWorksByTeacherId(string teacherId);

        //this is for detailsview
        public Task<LiteratureWorkDetailsViewModel> GetWorkByIdAsync(int id, int part);
        public Task<bool> WorkExistsAsync(int workId);
        public Task<LiteratureWorkViewModel> GetLiteratureWorkViewModelById(int id);
        public Task<LiteratureWork> GetLiteratureWorkNormalByIdAsync(int id);
        public Task EditAsync(LiteratureWorkViewModel model);
        public Task<bool> DeleteWorkAsync(int workId);

        public Task<IEnumerable<LiteratureWorkDisplayViewModel>> GetAllWorksAsync();
       
    }
}
