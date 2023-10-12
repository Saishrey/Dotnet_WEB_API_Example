using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;

namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            _SqlServerContext.Employee.Add(employee);
            _SqlServerContext.SaveChanges();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _SqlServerContext.Employee.ToList();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _SqlServerContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

    }
}
