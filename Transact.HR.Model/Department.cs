using System.ComponentModel.DataAnnotations;

namespace Transact.HR.Model
{
    public class Department
    {
        [Key]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
