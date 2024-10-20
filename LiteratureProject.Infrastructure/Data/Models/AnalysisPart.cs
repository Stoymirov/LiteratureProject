using LiteratureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.Data.Models
{
    public class AnalysisPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LiteratureWorkId { get; set; }
        public LiteratureWork LiteratureWork { get; set; } = null!;
    }
}
