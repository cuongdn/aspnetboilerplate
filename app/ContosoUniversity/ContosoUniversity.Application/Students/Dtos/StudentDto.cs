
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ContosoUniversity.Students.Dtos
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : EntityDto<int>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
