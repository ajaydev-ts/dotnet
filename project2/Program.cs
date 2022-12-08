// See https://aka.ms/new-console-template for more information
using project2;
using System.Data;
using System.Net.Mail;
using System.Numerics;

//Console.WriteLine("Hello, World!");


//Console.WriteLine("Enter side of sqare");
//int sqside=Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter length and breadth of rectangle");
//int rectlen=Convert.ToInt32(Console.ReadLine());
//int rectbred=Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter d1,d2 of rhombus");
//int rhombd1=Convert.ToInt32(Console.ReadLine());

//int rhombd2=Convert.ToInt32(Console.ReadLine());
//Display d = new Display();
//d.Displayarea( sqside,  rectlen,  rectbred,  rhombd1,  rhombd2);
////Area a = new Area();
////a.Square(sqside, sqside);
////a.Rectangle(rectlen, rectbred);
////a.Rhombus(rhombd2, rhombd1);
///

Database data = new Database();
////data.insertdepartment(1, "HR");
//data.insertdepartment(2, "Developer");
//data.insertdepartment(3, "Tester");
//Database data = new Database();
//data.insertdesignation(1, ".Net");
//data.insertdesignation(2, ".Net");
//data.insertdesignation(3, ".Net");
//Database data = new Database();
//data.insertemployee(1, "Nikil", 1, 1, 100000, "nik@gmail.com", 9495682451);
//data.insertemployee(2, "Ajay", 2, 2, 50000, "ajay@gmail.com", 9495682456);
//data.insertemployee(3, "Abhi", 3, 3, 10000, "abhi@gmail.com", 9495682445);

//Database data = new Database();

//DataSet ds = new DataSet();
//ds = data.getdata();
//foreach(DataRow dr in ds.Tables[0].Rows)
//{
//    Console.Write("ID :" + dr[0]);
//    Console.Write("\t");
//    Console.Write("Name:"+dr[1]);
//    Console.Write("\n\n");
//}
int Id, Depid, Desid, Salary, phone,a;
string mail, Name,s;
bool flag = true;
while (flag == true)
{
    Console.WriteLine("Enter the details to insert data 1.Dept 2.Desig 3.Employee 4.Exit 5.Display 6.Delete");
    int c = Convert.ToInt32(Console.ReadLine());

    switch (c)
    {
        case 1:
            Console.WriteLine("Enter dept id");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter dept name");
            Name = Console.ReadLine();
            data.insertDepartment(Id, Name);
            break;
        case 2:

            Console.WriteLine("Enter desig id");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter desig name");
            Name = Console.ReadLine();
            data.insertDesignation(Id, Name);
            break;
        case 3:
            int cntDept = data.chkdata_dept();
            int cntDesig = data.chkdata_desig();
            if (cntDept != 0 && cntDesig != 0)
            {
                Console.WriteLine("Enter id");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  name");
                Name = Console.ReadLine();
                if (data.chkdata_name(Name)!=0)
                        {
                    Console.WriteLine("Duplicate value");
                            break;
                         }
                
                Console.WriteLine("Enter Depid");
                Depid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  Desid");
                Desid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  Sallary");
                Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  mail");
                mail = Console.ReadLine();
                Console.WriteLine("Enter  PhNo");
                phone = Convert.ToInt32(Console.ReadLine());

                data.insertEmployee(Id, Name, Depid, Desid, Salary, mail, phone);

            }
            else
            {
                Console.WriteLine("Designation and Department table is empty enter  that  first");
            }
            break;
        case 4:
            flag = false;
            break;
        case 5:
            
                Console.WriteLine("Enter the table name to view: (Department, Designation, Employee)");
                int disp = Convert.ToInt32(Console.ReadLine());
                switch (disp)
                {

                    case 1:

                        DataSet ds = new DataSet();

                        s = "Department";
                        ds = data.getdata(s);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Console.Write("ID : " + dr[0]);
                            Console.Write("\t");
                            Console.Write("Name : " + dr[1]);
                            Console.Write("\n\n");
                        }

                        break;
                     case 2:



                         s = "Designation";
                         ds = data.getdata(s);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Console.Write("ID : " + dr[0]);
                            Console.Write("\t");
                            Console.Write("Name : " + dr[1]);
                            Console.Write("\n\n");
                        }


                        break;
                     case 3:
                            s= "Employee";
                            ds = data.getdata(s);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                Console.Write("ID : " + dr[0]);
                                Console.Write("\t");
                                Console.Write("Name : " + dr[1]);
                                Console.Write("\t");
                                Console.Write("Department ID : " + dr[2]);
                                Console.Write("\t");
                                Console.Write("Designation ID : " + dr[3]);
                                Console.Write("\t");
                                Console.Write("Salary : " + dr[4]);
                                Console.Write("\t");
                                Console.Write("Phone : " + dr[5]);
                                Console.WriteLine("\n\n");
                       
                            }
                            break;
            
                 }
            break ;
        case 6:
            Console.WriteLine("ENter the table to be deleted dep des emp");
            int d=Convert.ToInt32(Console.ReadLine());
            switch(d)
            {
                case 1:
                    Console.WriteLine("Enter the id to be deleted in Dept table");
                    a = Convert.ToInt32(Console.ReadLine());
                    data.delete1(a);
                    break;
                case 2:
                    Console.WriteLine("Enter the id to be deleted in Desig table");
                     a= Convert.ToInt32(Console.ReadLine());
                    data.delete2(a);
                    break;
                case 3:
                    Console.WriteLine("Enter the id to be deleted in Employee table");
                    a = Convert.ToInt32(Console.ReadLine());
                    data.delete3(a);
                    break;

            }
            break ;
        case 7:
            Console.WriteLine("Enter the id and name to be updated");
            int ide = Convert.ToInt32(Console.ReadLine());
            string namee=Console.ReadLine();
            data.updateEmp(ide, namee);
            break;
        default:
            Console.WriteLine("Invalid entry");
            break;
    }
}