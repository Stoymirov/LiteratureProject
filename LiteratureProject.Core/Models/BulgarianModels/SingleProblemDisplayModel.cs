﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.BulgarianModels
{
    public class SingleProblemDisplayModel
    {
        public ProblemDisplayModel Problem { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int DeckId { get; set; }
    }
}
