// See https://aka.ms/new-console-template for more information
using project1;

//using Yourclass;

//Class1 n =new Class1();
//n.yourdata();

Console.WriteLine("Hello, World!");
int a, b,c;
int flag=1;
Myclass m = new Myclass();
m.mydata();
while (flag == 1)
{
    Console.WriteLine("Enter the first number");
    a = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("Enter the second number");
    b = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("Enter the operation to be performed");
    c = Convert.ToInt16(Console.ReadLine());

    switch (c)
    {
        case 0:
            c = a + b;
            Console.WriteLine(c);
            break;
        case 1:
            c = a - b;
            Console.WriteLine(c);
            break;
        case 2:
            c = a * b;
            Console.WriteLine(c);
            break;
        case 3:
            c = a / b;
            Console.WriteLine(c);
            break;
        default:
            Console.WriteLine("Enter a valid operation");
            break;


    }
    Console.WriteLine("if u wish to cont press 1 els 0");
    flag = Convert.ToInt16(Console.ReadLine());
    if (flag==0)
    {
        break;
    }
   
}
   
