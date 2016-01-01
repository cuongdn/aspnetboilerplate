using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.UI;
using ContosoUniversity.Students.Dtos;

namespace ContosoUniversity.Students
{
    public class StudentAppService : ContosoUniversityAppServiceBase, IStudentAppService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentAppService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public List<StudentDto> GetStudents()
        {
            return _studentRepo.GetAllStudents().MapTo<List<StudentDto>>();
        }

        public StudentDto GetStudent(int id)
        {
            return _studentRepo.Get(id).MapTo<StudentDto>();
        }

        public Student Update(StudentDto student)
        {
            var entity = _studentRepo.Get(student.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("Student not found.");
            }
            return _studentRepo.Update(student.MapTo(entity));
        }
    }
}