using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace ContosoUniversity.Students
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetAllStudents();

    }
}
