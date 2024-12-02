using LiteratureProject.Core.Models.TestingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.ViewModelDataConstants
{
    public class AtLeastOneCorrectAnswerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is ProblemTestingModel model)
            {
                bool hasCorrectAnswer = model.IsAnswer1Correct ||
                                        model.IsAnswer2Correct ||
                                        model.IsAnswer3Correct ||
                                        model.IsAnswer4Correct;

                if (!hasCorrectAnswer)
                {
                    return new ValidationResult("At least one answer must be marked as correct.");
                }
            }

            return ValidationResult.Success!;
        }
    }

}
