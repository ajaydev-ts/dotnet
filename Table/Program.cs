// See https://aka.ms/new-console-template for more information
using System.Data;
using Table;

//Console.WriteLine("Hello, World!");
//DataTable dt = new DataTable();
//dt.Columns.Add(new DataColumn("Name"));
//dt.Columns.Add(new DataColumn("Age"));
//DataRow dr = dt.NewRow();
//dr[0] = "Manu";
//dr[1] = "20";
//dt.Rows.Add(dr);
//dr = dt.NewRow();
//dr[0] = "Sugu";
//dr[1] = "21";
//dt.Rows.Add(dr);
//dr = dt.NewRow();
//dr[0] = "Damu";
//dr[1] = "22";
//dt.Rows.Add(dr);
//Console.Write(dt);


//foreach (DataRow dr1 in dt.Rows)
//{

//    Console.WriteLine(dr1[0]);
//    Console.WriteLine(dr1[1]);
//}

var stud = new List<Student>()
{
    new Student() {Name="manu",Rollno=1},
    new Student() {Name="raju",Rollno=2},
};
foreach (Student student in stud)
{
    Console.WriteLine(student.Name);
    Console.WriteLine(student.Rollno);
}