using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EmployeeInformation.Models;

namespace EmployeeInformation.DAL
{
    public class DatabaseAccess
    {
        List<Employee> allEmployees = new List<Employee>();

        public bool SaveData(Employee employee)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "spSetEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@EmployeeCity", employee.EmployeeCity);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                SqlParameter outParameter = new SqlParameter();
                outParameter.DbType = DbType.Int32;
                outParameter.Direction = ParameterDirection.Output;
                outParameter.ParameterName = "@EmployeeId";
                cmd.Parameters.Add(outParameter);
                connection.Open();
                int successNumber = (int)cmd.ExecuteNonQuery();
                if (successNumber > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Employee> getDataForGridView()
        {
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

                    int employeeId = (int)reader["EmployeeId"];
                    string employeeName = reader["EmployeeName"].ToString();
                    string employeeGender = reader["EmployeeGender"].ToString();
                    string employeeCity = reader["EmployeeCity"].ToString();
                    string employeeDateOfBirth = reader["DateOfBirth"].ToString();
                    Employee aEmployee = new Employee(employeeName, employeeGender, employeeCity, employeeDateOfBirth, employeeId);
                    allEmployees.Add(aEmployee);
                }
                reader.Close();
                connection.Close();

                return allEmployees;
            }
        }
    }
}