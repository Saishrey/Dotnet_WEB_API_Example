using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetEmployees() 
        { 
            try
            {
                var employees = _EmployeeRepository.GetAllEmployees();
                return Ok(employees);
            }
            catch(Exception e)
            {
                return Content(e.Message, "text/plain");
                //return StatusCode(StatusCodes.Status417ExpectationFailed, e.Message);
            }
        }

        [HttpGet]
        public ActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return Content(e.Message, "text/plain");
                //return StatusCode(StatusCodes.Status417ExpectationFailed, e.Message);
            }
        }


        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = _EmployeeRepository.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception e)
            {
                return Content(e.Message, "text/plain");
                //return StatusCode(StatusCodes.Status417ExpectationFailed, e.Message);
            }
        }
    }
}
