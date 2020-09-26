using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Check_In.Models
{
   public  interface IEmployeeRepos
    {
        Task<IEnumerable<Employee_informations>> GetEmployees();
        Task<Employee_informations> GetEmployee(string id);
        Task<Employee> AddEmployee(Employee employee);
        void UpdateEmployee(Employee_informations employee);
        void DeleteEmployee(string id);
    }
}
