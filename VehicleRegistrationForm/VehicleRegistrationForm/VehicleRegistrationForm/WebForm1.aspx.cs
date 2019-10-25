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
using System.Security.Cryptography.X509Certificates;

namespace VehicleRegistrationForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string manufacturer = manufacturerTextBox.Text;
                string modelYear = modelYearTextBox.Text;
                string color = colorTextBox.Text;
                string insuranceNumber = insuranceNumberTextBox.Text;
                string ownerName = ownerNameTextBox.Text;
                string registrationCity = cityTextBox.Text;
                Vehicle newVehicle = new Vehicle(manufacturer,modelYear,color,insuranceNumber,ownerName, registrationCity);
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS1"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "spNewVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OwnerName", newVehicle.OwnerName);
                    cmd.Parameters.AddWithValue("@ModelYear", newVehicle.ModelYear);
                    cmd.Parameters.AddWithValue("@Color", newVehicle.Color);
                    cmd.Parameters.AddWithValue("@InsuranceNumber", newVehicle.InsuranceNumber);
                    cmd.Parameters.AddWithValue("@RegistrationCity", newVehicle.RegistrationCity);
                    cmd.Parameters.AddWithValue("@Manufacturer", newVehicle.Manufacturer);
                    SqlParameter outParameter = new SqlParameter();
                    outParameter.DbType = DbType.Int32;
                    outParameter.Direction = ParameterDirection.Output;
                    outParameter.ParameterName = "@RegistrationNumber";
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    int excutted = cmd.ExecuteNonQuery();
                    if (excutted>0)
                    {
                        msgLabel.Text = "Vehicle Registred Successfully, Registration Number: " + outParameter.Value;
                        msgLabel.ForeColor = Color.Green;
                        FillGridView();
                        ClearAll();
                    }
                    else
                    {
                        msgLabel.Text = "Vehicle Registration Failed!! Please check all the inputs";
                        msgLabel.ForeColor = Color.Red;
                    }
                }

            }
            else
            {
                msgLabel.Text = "Vehicle Registration Failed!! Please check all the inputs";
                msgLabel.ForeColor = Color.Red;
            }
        }

        public List<Vehicle> BringInformation()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS1"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Vehicle> aVehicle = new List<Vehicle>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM vehcileDatabase ORDER BY VehicleId DESC;";
                connection.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
                {
                    string manufacturer = reader["Manufacturer"].ToString();
                    string modelYear = reader["ModelYear"].ToString();
                    string color = reader["Color"].ToString();
                    string insuranceNumber = reader["InsuranceNumber"].ToString();
                    string ownerName = reader["VehicleOwner"].ToString();
                    string registrationcity = reader["RegistrationCity"].ToString();
                    int registrationNumber = Convert.ToInt32(reader["RegistrationNumber"]);
                    Vehicle newVehicle = new Vehicle(manufacturer, modelYear, color, insuranceNumber, ownerName, registrationcity, registrationNumber);
                    aVehicle.Add(newVehicle);
                }
                    return aVehicle;

            }
        }

        private void FillGridView()
        {
            showAllGridView.DataSource = BringInformation();
            showAllGridView.DataBind();
        }

        private void ClearAll()
        {
            manufacturerTextBox.Text = string.Empty;
            modelYearTextBox.Text = string.Empty;
            colorTextBox.Text = String.Empty;
            insuranceNumberTextBox.Text = String.Empty;
            ownerNameTextBox.Text = string.Empty;
            cityTextBox.Text = string.Empty;
        }
    }
}