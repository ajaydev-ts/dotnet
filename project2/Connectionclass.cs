using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace project2
{
    internal class Connectionclass
    {
        SqlConnection connection = new SqlConnection("Data Source=AJAYDEVTS-991\\SQLEXPRESS;Initial Catalog=DB1;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        public Connectionclass()
        {
            connection.Open();
            command.Connection = connection;

        }
        public SqlCommand getCommand
        {
            get { return command; }
        }
    }
}
