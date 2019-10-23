using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using EmployeeInformation.BLL;
using EmployeeInformation.Models;

namespace EmployeeInformation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BusinessLogic saveData = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
            string employeeName = employeeNameTextBox.Value;
            string employeeCity = employeeCityTextBox.Value;
            string employeeDateOfBirth = dateOfBirth.Text;
            string employeeGender = genderDropDownList.SelectedItem.Text;
            Employee newEmployee = new Employee(employeeName, employeeGender, employeeCity, employeeDateOfBirth);
            string msgmsgLabel = saveData.PassEmployee(newEmployee);
            msgLabel.Text = msgmsgLabel;
            GetClear();
            }

        }




        private void GetClear()
        {
            employeeNameTextBox.Value = string.Empty;
            employeeCityTextBox.Value = string.Empty;
        }
    }
}