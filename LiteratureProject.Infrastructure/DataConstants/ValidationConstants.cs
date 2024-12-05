using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.DataConstants
{
    public static class ValidationConstants
    {
        public static class Deck
        {
            public const int NameMaxLength = 100;
            public const int CreatedByMaxLength = 50;
            public const int CreatedByIdMaxLength = 36;
        }
        public static class AnalysisPartConstants
        {
            public const int NameMaxLength = 30;
            public const int ContentMaxLength = 2000;
        }
        public static class StudentAnalysis
        {
            public const int ApplicationUserIdMaxLength = 30;
            public const int ContentMaxLength = 2000;

            public const string GradeMinLength = "2";
            public const string GradeMaxLength = "6";
        }
        public class ApplicationUserConstants
        {
            public const int FirstNameMaxLength = 15;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 20;
            public const int LastNameMinLength = 2;

            public const int LocationMinLength = 2;
            public const int LocationMaxLength = 20;

            public const int BioMinLength = 20;
            public const int BioMaxLength = 100;

        }
        public static class Author
        {
            public const int NameMaxLength = 100;
        }

        public static class LiteratureWork
        {
            public const int NameMaxLength = 150;
        }

        public static class StudentWorkComponent
        {
            public const int ContentMaxLength = 5000;
        }

        public static class ApplicationUser
        {
            public const int IdMaxLength = 450;
        }
        public static class Bg
        {
           
            
                public const int QuestionMaxLength = 500;
                public const int AnswerMaxLength = 200;
                public const int ExplanationMaxLength = 2000;

               
                public const int DeckNameMaxLength = 100;
                public const int CreatedByMaxLength = 100;
            
        }
    }

}
