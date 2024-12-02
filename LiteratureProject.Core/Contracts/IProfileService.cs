using LiteratureProject.Core.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Contracts
{
    public interface IProfileService
    {
        public Task<UserProfileViewModel> GiveUserProfileViewModel(string userId);
        public Task<bool> EditInformationAsync(UserProfileViewModel model);
    }
}
