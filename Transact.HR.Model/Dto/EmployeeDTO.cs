using Transact.HR.Model.Enumeration;

namespace Transact.HR.Model.Dto
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
