﻿using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteratureProject.Core.Models
{
    public class LiteratureWorkViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string TeacherId { get; set; }
        
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        public List<AnalysisPart> Parts { get; set; } = new List<AnalysisPart>
        {
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
        };
    }
}
