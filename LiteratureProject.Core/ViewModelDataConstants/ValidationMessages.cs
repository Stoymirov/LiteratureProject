using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.ViewModelDataConstants
{
    public class ValidationMessages
    {
        //Bulgarian DeckFormModel constants

        public const string NameRequired = "Name is required.";
        public const string NameMaxLength = "Name cannot exceed 100 characters.";
        public const string CreatedByRequired = "Created by field is required.";
        public const string CreatedByIdRequired = "Creator's ID is required.";
        public const string TopicRequired = "A topic must be selected.";

        //Bulgarian ProblemFormModel constants

        public const string QuestionRequired = "Question is required.";
        public const string QuestionMaxLength = "Question cannot exceed 500 characters.";
        public const string AnswerRequired = "Each answer is required.";
        public const string AnswerMaxLength = "Each answer cannot exceed 200 characters.";
        public const string ExplanationRequired = "Explanation is required.";
        public const string ExplanationMaxLength = "Explanation cannot exceed 1000 characters.";
        public const string DeckSelectionRequired = "A deck of problems must be selected.";

        //Literature LiteratureWorkViewModel constants

        public const string NameRequiredLiterature = "The literature work name is required.";
        public const string NameMaxLengthLiterature = "The literature work name cannot exceed 200 characters.";
        public const string AuthorRequired = "You must select an author.";
        public const string TeacherRequired = "Teacher information is required.";
        
        //Literature AnalysisPartViewModel constants
        public const string ContentRequired = "Content is required.";
        public const string ContentMaxLength = "Content cannot exceed 2000 characters.";
        public const string InvalidAnalysisPartType = "The selected analysis part type is invalid.";

        //Profile Validation constants
        public const string FullNameRequired = "Full name is required.";
        public const string FullNameMaxLength = "Full name cannot exceed 100 characters.";

        public const string BioMaxLength = "Bio cannot exceed 500 characters.";

        public const string LocationMaxLength = "Location cannot exceed 100 characters.";

        public const string RoleRequired = "Role is required.";
        public const string RoleMaxLength = "Role cannot exceed 50 characters.";

        public const string ProfilePictureFileType = "Only image files are allowed.";
        public const string ProfilePictureMaxSize = "Profile picture cannot exceed 2 MB.";
    }
}
