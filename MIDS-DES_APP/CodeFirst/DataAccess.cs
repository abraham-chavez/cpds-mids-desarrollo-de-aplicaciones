using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class DataAccess
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            String commandText = "SELECT * FROM dbo.Employee";
            //SqlConnection con = new SqlConnection("Server=localhost;Database=DemoDB;Trusted_Connection=True;");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    Object jpn = reader.GetValue(reader.GetOrdinal("JobPhoneNumber"));

                    employees.Add(new Employee()
                    {
                        EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                        JobEmail = reader.GetString(reader.GetOrdinal("JobMail")),
                        JobPhoneNumber = jpn == null ? String.Empty : jpn.ToString(),
                        JobPosition = reader.GetString(reader.GetOrdinal("JobPosition")),
                    });
                }
                reader.Close();
                con.Close();
            }

            return employees;
        }
    }
}
