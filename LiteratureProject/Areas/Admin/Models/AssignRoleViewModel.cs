using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiteratureProject.Areas.Admin.Models
    {
        public class AssignRoleViewModel
        {
            public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

            public string SelectedUserId { get; set; } = string.Empty;
            public string SelectedRole { get; set; } = string.Empty;
        }
    }
