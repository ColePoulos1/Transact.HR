using Transact.HR.Model.Enumeration;

namespace Transact.HR.Model.Filter
{
    public class EmployeePaginationFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string DepartmentName { get; set; }
    }
}
