using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeInformation.BLL;
using EmployeeInformation.Models;

namespace EmployeeInformation
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Employee> allEmployees = new List<Employee>();
        BusinessLogic getData = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            SetGridViewContent();
        }

        private List<Employee> GetEmployeeData()
        {

            allEmployees = getData.GetDataForGridView();
            return allEmployees;


        }

        private void SetGridViewContent()
        {


            showInformation.DataSource = GetEmployeeData();
            showInformation.DataBind();

        }
    }
}