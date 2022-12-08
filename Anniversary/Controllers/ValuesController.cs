using Anniversary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web;

namespace Anniversary.Controllers
{
    public class ValuesController : ApiController

    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
        Employee emp = new Employee();
        [Route("api/getEmployee")]
        public List<Employee> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAllEmployees", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> lstEmployee = new List<Employee>();
            if (dt.Rows.Count > 0)

            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    emp.EmployeeName = dt.Rows[i]["EmployeeName"].ToString();
                    emp.DateOfJoining = Convert.ToDateTime(dt.Rows[i]["DateOfJoining"]);
                    emp.ActiveStatus = Convert.ToInt32(dt.Rows[i]["ActiveStatus"]);
                    emp.PhotoFileName = dt.Rows[i]["PhotoFileName"].ToString();
                    lstEmployee.Add(emp);
                }
            }
            if (lstEmployee.Count > 0)
            {
                return lstEmployee;
            }
            else
            {
                return null;
            }
        }




        [Route("api/getEmpbyId")]
        public Employee Get(int id, string con)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetEmployeeByID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee emp = new Employee();
            if (dt.Rows.Count > 0)

            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]);
                emp.EmployeeName = dt.Rows[0]["EmpName"].ToString();
                emp.DateOfJoining = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                //emp.ActiveStatus = Convert.ToInt32(dt.Rows[0]["ActiveStatus"]);


            }
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }
        [Route("api/Anniv")]
        public List<Employee> get()
        {
            SqlDataAdapter da = new SqlDataAdapter("Anniv", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> lstEmployee = new List<Employee>();
            if (dt.Rows.Count > 0)

            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    //emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    emp.EmployeeName = dt.Rows[i]["EmployeeName"].ToString();
                    emp.PhotoFileName = dt.Rows[i]["PhotoFileName"].ToString();
                    //emp.DateOfJoining = Convert.ToDateTime(dt.Rows[i]["DateOfJoining"]);
                    //emp.ActiveStatus = Convert.ToInt32(dt.Rows[i]["ActiveStatus"]);
                    lstEmployee.Add(emp);
                }
            }

            if (lstEmployee.Count > 0)
            {
                return lstEmployee;
            }
            else
            {
                return null;
            }
        }


        [Route("api/PostEmployee")]
        public string Post(Employee employee)
        {
            string msg = "";
            if (employee != null)
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                cmd.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
                cmd.Parameters.AddWithValue("@ActiveStatus", employee.ActiveStatus);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Data has been inserted";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        [Route("api/UpdateEmployee")]
        public string Put(Employee employee)
        {
            string msg = "";
            if (employee != null)
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                cmd.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
                cmd.Parameters.AddWithValue("@ActiveStatus", employee.ActiveStatus);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Data has been updated";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }


        [Route("api/DeleteEmployee")]
        public string put(Employee employee)
        {
            string msg = "";
            if (employee != null)
            {

                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Data has been deleted";
                }
                else
                {
                    msg = "Error";
                }
            }

            return msg;
        }
        [Route("api/Employee/SaveFile")]
        public String SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);
                postedFile.SaveAs(physicalPath);
                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }
        

    }
}
    


