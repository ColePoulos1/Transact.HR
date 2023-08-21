using FastMapper;
using Microsoft.AspNetCore.Mvc;
using Transact.HR.DataAccess;
using Transact.HR.Model;
using Transact.HR.Model.Dto;
using Transact.HR.Model.Filter;

namespace Transact.HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "V1")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly HrContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, HrContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        ///     Returns a list of employees within the specified department
        /// </summary>
        /// <response code="200">List of employees returned</response>
        /// <response code="404">Specified department not found</response>
        [HttpGet]
        [Route("GetEmployees")]
        public ActionResult<IEnumerable<EmployeeDTO>> GetEmployees([FromQuery] EmployeePaginationFilter filter)
        {
            if (_context.Departments.FirstOrDefault(x => x.Name == filter.DepartmentName) is null)
            {
                _logger.LogWarning($"GetEmployees: department with filter {filter.DepartmentName} not found.");
                return NotFound("Specified department not found");
            }

            IEnumerable<Employee> employees = _context.GetFilteredEmployees(filter);

            return Ok(TypeAdapter.Adapt<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees));
        }
    }
}