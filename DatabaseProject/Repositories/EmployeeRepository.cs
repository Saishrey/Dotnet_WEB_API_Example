using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using System.Data.SqlClient;

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

        public Employee GetEmployeeById_AdoNet(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=EngineersDesk;Trusted_Connection=True;Encrypt=False"))
            {
                // connection.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=EngineersDesk;Trusted_Connection=True;Encrypt=False";
                connection.Open(); 

                SqlCommand cmd = new SqlCommand("Select * from Employee where EmployeeId=@Id", connection);
                cmd.Parameters.Add(new SqlParameter("Id", id));

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Employee employee1 = new Employee()
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            EmployeeName = (string)reader["EmployeeName"],
                            City = (string)reader["City"],
                            DateOfJoining = (DateTime)reader["DateOfJoining"],
                            Salary = (decimal)reader["Salary"]

                        };
                        employee =  employee1;

                    }
                }
            }
            return employee;
        }
    }
}
