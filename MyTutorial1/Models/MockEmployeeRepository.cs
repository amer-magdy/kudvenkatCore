using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        //ctor + two times tab to create constructor 
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="mego",Email="mego@gmail.com",Department=Dept.SWE},
                new Employee(){Id=2,Name="mahmoud",Email="mahmoud@gmail.com",Department=Dept.SWE },
                new Employee() {Id=3,Name="mayar",Email="mayar@gmail.com",Department=Dept.SWE },
                new Employee() {Id=4,Name="3amer",Email="3amer@gmail.com",Department=Dept.SWE },
                new Employee(){Id=5,Name="israa",Email="israa@gmail.com",Department=Dept.SWE}
            };
        }

        //public Employee Add(Employee employee)
        //{
        //    employee.Id = _employeeList.Max(e => e.Id) + 1;
        //    _employeeList.Add(employee);
        //    return employee;
        //}

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;//mustbe6tocreatenewemployee
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
