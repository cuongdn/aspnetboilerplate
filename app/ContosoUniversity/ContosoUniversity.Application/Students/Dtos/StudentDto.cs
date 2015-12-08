
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;

namespace ContosoUniversity.Students.Dtos
{
    public class StudentDto : EntityDto<int>, IMapFrom<Student>, IInputDto, ICustomValidate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (FirstName.StartsWith("A"))
            {
                results.Add(new ValidationResult("First name must not be start with A.", new[] { "FirstName" }));
            }
        }
    }

}
