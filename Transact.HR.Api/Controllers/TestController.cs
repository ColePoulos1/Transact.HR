using Microsoft.AspNetCore.Mvc;
using Transact.HR.DataAccess;
using Transact.HR.Model;
using Transact.HR.Model.Enumeration;

namespace Transact.HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "V1")]
    public class TestController : ControllerBase
    {
        private readonly HrContext _context;

        public TestController(HrContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Populates the Sqlite DB with data (Obviously just for testing purposes)
        /// </summary>
        /// <response code="200">DB populated successfully</response>
        [HttpGet]
        [Route("PopulateDb")]
        public async Task<ActionResult> PopulateDb()
        {
            _context.Employees.RemoveRange(_context.Employees);
            _context.Departments.RemoveRange(_context.Departments);
            _context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "Engineering", Description = "Lorem Ipsum" },
                new Department { Name = "Product", Description = "Lorem Ipsum" },
                new Department { Name = "Business", Description = "Lorem Ipsum" },
                new Department { Name = "Marketing", Description = "Lorem Ipsum" },
                new Department { Name = "Sales", Description = "Lorem Ipsum" }
            };
            _context.Departments.AddRange(departments);
            _context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Bob Walter", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.QA, Name = "Bob Johnson", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Fred Swift", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Emily Mathers", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.QA, Name = "Karly Davis", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Tim Fred", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Jim Josh", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.QA, Name = "Larry Bird", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Engineer, Name = "Larry Wheels", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.QA, Name = "Bobby Wheels", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Engineering") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.ProductManager, Name = "Kate Smith", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Product") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.ProductManager, Name = "John Doe", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Product") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Designer, Name = "Jane Doe", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Marketing") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Manager, Name = "Kim Smith", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Business") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Executive, Name = "Emily Baker", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Business") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Manager, Name = "Helen Wheels", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Business") },
                new Employee { Id = Guid.NewGuid(), Designation = Designation.Executive, Name = "Jared Bobs", PrivateInfo = "Lorem Ipsum", Department = _context.Departments.First(x => x.Name == "Business") },
            };
            _context.Employees.AddRange(employees);
            _context.SaveChanges();

            return Ok();
        }
    }
}