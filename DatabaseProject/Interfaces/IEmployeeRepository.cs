using DatabaseProject.Models;

namespace DatabaseProject.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        Employee AddEmployee(Employee employee);

        Employee GetEmployeeById_AdoNet(int id);

    }
}
