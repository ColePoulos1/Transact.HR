using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Transact.HR.Model;
using Transact.HR.Model.Filter;

namespace Transact.HR.DataAccess
{
    public class HrContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public HrContext(DbContextOptions<HrContext> options): base(options){}

        public IEnumerable<Employee> GetFilteredEmployees(EmployeePaginationFilter filter)
            => Employees
                .Where(x => x.Department.Name == filter.DepartmentName)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
    }
}
