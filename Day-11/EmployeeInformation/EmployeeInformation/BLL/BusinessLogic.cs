using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeInformation.DAL;
using EmployeeInformation.Models;

namespace EmployeeInformation.BLL
{
    public class BusinessLogic
    {
        DatabaseAccess anyData = new DatabaseAccess();
        Employee employeeData = new Employee();
        public string PassEmployee(Employee newEmployee)
        {
           bool isSaved = anyData.SaveData(newEmployee);
            if (isSaved)
            {
                return "Data Saved Successfully";
            }
            else
            {
                return "Data Saving Failed";
            }
        }

        public List<Employee> GetDataForGridView()
        {
            List<Employee> getDataForGridView = anyData.getDataForGridView();
            return getDataForGridView;

        }
    }
}