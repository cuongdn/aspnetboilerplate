using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using ContosoUniversity.Entities;
using ContosoUniversity.Students;

namespace ContosoUniversity.EntityFramework.Repositories
{
    public class StudentRepository : ContosoUniversityRepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(IDbContextProvider<ContosoUniversityDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Student> GetAllStudents()
        {
            return GetAll().OrderBy(x => x.LastName).ToList();
        }
    }
}
