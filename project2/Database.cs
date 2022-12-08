using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    internal class Database
    {
        Connectionclass connection=new Connectionclass();
        public int chkdata_name(string name)
        {
            connection.getCommand.CommandText = "select count(*) from Employee where Name='"+name+"'";
           
            int cnt = Convert.ToInt32(connection.getCommand.ExecuteScalar());
            return cnt;
        }
            public int chkdata_dept()
        {
            connection.getCommand.CommandText = "select count(*) from Department";
            int cnt = Convert.ToInt32(connection.getCommand.ExecuteScalar());
            return cnt;
        }
        public int chkdata_desig()
        {
            connection.getCommand.CommandText = "select count(*) from Designation";
            int cnt = Convert.ToInt32(connection.getCommand.ExecuteScalar());
            return cnt;
        }
        public int chkdata_emp()
        {
            connection.getCommand.CommandText = "select count(*) from Employee";
            int cnt = Convert.ToInt32(connection.getCommand.ExecuteScalar());
            return cnt;
        }
        public DataSet getdata()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connection.getCommand.CommandText = "select * from Department";
            adp.SelectCommand = connection.getCommand;
            adp.Fill(ds);
            return ds;
        }
        public void insertDepartment(int depid,string name)
        {
            connection.getCommand.CommandText = "insert into Department(Id,Name) values('" + depid + "','" + name + "')";
            connection.getCommand.ExecuteNonQuery(); 
        }
        public void insertDesignation(int desid,string name)
        {
            connection.getCommand.CommandText = "insert into Designation(Id,Designation) values('" + desid + "','" + name + "')";
            connection.getCommand.ExecuteNonQuery();
        }
        public void insertEmployee(int Id, string name,int Depid,int Desid,int Salary,string mail,long phone)
        {
            connection.getCommand.CommandText = "insert into employee(id,name,Depid,Desid,Salary,mail,phone) values('" + Id + "','" + name + "','" + Depid + "','" + Desid + "','" + Salary + "','" + mail + "','" + phone + "')";
            connection.getCommand.ExecuteNonQuery();
        }

     
        public DataSet getdata(string tableName)
        {
            SqlDataAdapter adb = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connection.getCommand.CommandText = "select * from " + tableName;
            adb.SelectCommand = connection.getCommand;
            adb.Fill(ds);
            return ds;
        }
        public void delete1(int id)
        {
            connection.getCommand.CommandText = "delete from  Department where id='" + id + "'";
            connection.getCommand.ExecuteNonQuery();
        }
        public void delete2(int id)
        {
            connection.getCommand.CommandText = "delete from Designation where id='" + id + "'";
            connection.getCommand.ExecuteNonQuery();
        }
        public void delete3(int id)
        {
            connection.getCommand.CommandText = "delete from Employee where id='" + id + "'";
            connection.getCommand.ExecuteNonQuery();
        }
        public void updateEmp(int id, string name)
        {
            connection.getCommand.CommandText = "update Employee set Name='" + name + "' where id='" + id + "'";
            connection.getCommand.ExecuteNonQuery();
        }
    }
         
}
