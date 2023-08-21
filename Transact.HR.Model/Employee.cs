using Transact.HR.Model.Enumeration;

namespace Transact.HR.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Designation Designation { get; set; }
        public Department Department { get; set; }
        public string? PrivateInfo { get; set; }
    }
}