using System.Collections.Generic;
using ContosoUniversity.Students.Dtos;

namespace ContosoUniversity.Students
{
    public interface IStudentAppService
    {
        List<StudentDto> GetStudents();
        StudentDto GetStudent(int id);
        Student Update(StudentDto student);
    }
}
