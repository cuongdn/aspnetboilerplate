using System;
using ContosoUniversity.Entities;

namespace ContosoUniversity.Students
{
    public class Student : Person
    {
        public DateTime? EnrollmentDate { get; set; }
    }
}