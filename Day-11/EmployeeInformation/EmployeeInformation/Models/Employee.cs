using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeInformation.Models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string EmployeeCity { get; set; }
        public string DateOfBirth { get; set; }
        public int EmployeeId { get; set; }

        

        public Employee(string employeeName, string gender, string employeeCity, string dateOfBirth)
        {
            EmployeeName = employeeName;
            Gender = gender;
            EmployeeCity = employeeCity;
            DateOfBirth = dateOfBirth;
        }

        public Employee(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public Employee(string employeeName, string gender, string employeeCity, string dateOfBirth, int employeeId) : this(employeeName, gender, employeeCity, dateOfBirth)
        {
            EmployeeId = employeeId;
        }

        public Employee()
        {
        }
    }
}