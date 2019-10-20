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
using EmployeeInformation.Models;

namespace EmployeeInformation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetGridViewContent();
        }

        

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string employeeName = employeeNameTextBox.Value;
            string employeeCity = employeeCityTextBox.Value;
            string employeeDateOfBirth = dateOfBirth.Text;
            string employeeGender = genderDropDownList.SelectedItem.Text;
            Employee newEmployee = new Employee(employeeName,employeeGender,employeeCity,employeeDateOfBirth);
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "spSetEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", newEmployee.EmployeeName);
                cmd.Parameters.AddWithValue("@Gender", newEmployee.Gender);
                cmd.Parameters.AddWithValue("@EmployeeCity", newEmployee.EmployeeCity);
                cmd.Parameters.AddWithValue("@DateOfBirth", newEmployee.DateOfBirth);
                SqlParameter outParameter = new SqlParameter();
                outParameter.DbType = DbType.Int32;
                outParameter.Direction = ParameterDirection.Output;
                outParameter.ParameterName = "@EmployeeId";
                cmd.Parameters.Add(outParameter);
                connection.Open();
               int successNumber =(int) cmd.ExecuteNonQuery();
                if (successNumber>0)
                {
                    msgLabel.Text = "Employee Added Successfully, Employee Id: " + outParameter.Value;
                    msgLabel.ForeColor = Color.Green;
                    GetClear();
                    SetGridViewContent();
                }
                else
                {
                    msgLabel.Text = "Process Failed, Please check your inputs";
                    msgLabel.ForeColor = Color.Red;
                }
            }
        }
        private List<Employee> GetEmployeeData()
        {
            List<Employee> allEmployees = new List<Employee>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tblEmploye ORDER BY EmployeeId DESC;";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    int employeeId = (int) reader["EmployeeId"];
                    string employeeName = reader["EmployeeName"].ToString();
                    string employeeGender = reader["EmployeeGender"].ToString();
                    string employeeCity = reader["EmployeeCity"].ToString();
                    string employeeDateOFBirth = reader["DateOfBirth"].ToString();
                    Employee aEmployee = new Employee(employeeName,employeeGender,employeeCity,employeeDateOFBirth,employeeId);
                    allEmployees.Add(aEmployee);
                }
                connection.Close();

                return allEmployees;
            }
        }

        private void SetGridViewContent()
        {
            showInformation.DataSource = GetEmployeeData();
            showInformation.DataBind();
        }

        private void GetClear()
        {
            employeeNameTextBox.Value = string.Empty;
            employeeCityTextBox.Value = string.Empty;
        }
    }
}