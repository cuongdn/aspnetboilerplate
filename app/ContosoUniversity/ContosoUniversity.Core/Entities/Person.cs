using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace ContosoUniversity.Entities
{
    [Table("Person")]
    public abstract class Person : Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
