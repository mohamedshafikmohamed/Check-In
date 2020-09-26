using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Check_In.Models
{
    public class EmployeeRepos : IEmployeeRepos
    {
        private  readonly FirestoreDb db;
        public EmployeeRepos()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"check-in.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("check-in-10be9");
        }

        public async Task <Employee> AddEmployee(Employee employee)
        {
            
            CollectionReference coll = db.Collection("Employees");
            Employee_informations New_Employee = new Employee_informations { Age = employee.Age, Email = employee.Email, Password = employee.Password, Position = employee.Position,  Salary = employee.Salary, Name = employee.Name,gender=employee.gender.ToString()};
            DocumentReference d = await coll.AddAsync(New_Employee);
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                

                {"Id",d.Id }


            };
            await d.UpdateAsync(data1);

            return employee;  
        }

        public async void  DeleteEmployee(string id)
        {
            await db.Collection("Employees").Document(id).DeleteAsync();
        }

        public async Task<Employee_informations> GetEmployee(string id)
        {
            Query query = db.Collection("Employees");
            QuerySnapshot Employees = await query.GetSnapshotAsync();
            Employee_informations emp;
            foreach (DocumentSnapshot Employee in Employees)
            {
                emp = Employee.ConvertTo<Employee_informations>();

                if (Employee.Id == id)
                {

                    return emp;
                }
            }
            return null;
        }

        public  async Task<IEnumerable<Employee_informations>> GetEmployees()
        {
            Query query = db.Collection("Employees");
            QuerySnapshot Employees = await query.GetSnapshotAsync();
            List<Employee_informations> Employee_List = new List<Employee_informations>();
            foreach (DocumentSnapshot employee in Employees)
            {

                Employee_informations emp = employee.ConvertTo<Employee_informations>();

                Employee_List.Add(emp);
            }


            return Employee_List;
        }

        public  async void UpdateEmployee(Employee_informations employee)
        {
            DocumentReference coll = db.Collection("Employees").Document(employee.Id);
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {

                {"Name",employee.Name },
                {"Age",employee.Age },
                {"Email",employee.Email },
                {"gender",employee.gender },
                {"Password",employee.Password },
                {"Position",employee.Position },
                {"Salary",employee.Salary },
               
            };
            await coll.UpdateAsync(data1);

        }
    }
}
