using System;
using System.Collections.Generic;

namespace _054_MT2
{
    // สร้าง enum กำหนดประเภทต่างๆ
    enum Type
    {
        Student = 1,
        Employee
    }

    class Program
    {
        static void Main(string[] args)
        {
            PreparePersonList();
            WelcomeScreen();
        }

        // หน้าจอตอนเรื่มโปรแกรม
        static void WelcomeScreen()
        {
            Console.Clear();
            WelcomeScreenHeader();
            WelcomeScreenMenu();
            WelcomeScreenInputMenu();
        }

        // คำเปรยเริ่มโปรแกรม
        static void WelcomeScreenHeader()
        {
            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("--------------------------");

        }

        // ตัวเลือกเมนู
        static void WelcomeScreenMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");

        }

        // เลือกเมนูที่จะไป
        static void WelcomeScreenInputMenu()
        {
            Console.Write("Select Menu: ");
            int menu = int.Parse(Console.ReadLine());

            if (menu == 1)
            {
                LoginScreen();
            }
            else if (menu == 2)
            {
                RegisterScreen();
            }
            else
            {
                WelcomeScreen();
            }
        }

        // หน้า login 
        static void LoginScreen()
        {
            Console.Clear();
            LoginScreenHeader();
            LoginScreenInput();

        }

        // คำเปรยหน้า login
        static void LoginScreenHeader()
        {
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------");
        }

        // ป้อนข้อมูล Name และ Password ในการ login
        static void LoginScreenInput()
        {
            Console.Write("Input Name: ");
            string userName = Console.ReadLine();;

            Console.Write("Input Password: ");
            string userPassword = Console.ReadLine();

            CheckUserName(userName, userPassword);

        }

        // ตรวจสอบ Name และ Password ว่าถูกไหม
        static void CheckUserName(string userName, string userPassword)
        {
            int counter = 0;
            foreach (Person person in Program.personList.personList)
            {
                if (userName == person.Name)
                {
                    counter++;
                }

                if (userPassword == person.Password)
                {
                    counter++;
                }
            }

            if (counter <= 1)
            {
                WelcomeScreen();
            }
        }

        // หน้าจอตอนสมัครลงทะเบียน Register
        static void RegisterScreen()
        {
            Console.Clear();
            RegisterScreenHeader();
            RegisterScreenInput();
            WelcomeScreen();
        }

        // คำเปรยหน้า Register
        static void RegisterScreenHeader()
        {
            Console.WriteLine("Register New Person");
            Console.WriteLine("-------------------");
        }

        // ป้อนข้อมูลในการลงทะเบียน
        static void RegisterScreenInput()
        {

            string inputName = InputName();
            string inputPassword = InputPassword();
            int inputType = InputType();

            // เช็ก type 1
            if (inputType == 1)
            {
                string inputStudentID = InputStudentID();
                Student student = RegisterStudent(inputName, inputPassword, inputType, inputStudentID);

                // add student เข้า List
                Program.personList.AddNewPerson(student);
            }
            // เช็ก type 2
            else if (inputType == 2)
            {
                string inputEmployeeID = InputEmployeeID();
                Employee employee = RegisterEmployee(inputName, inputPassword, inputType, inputEmployeeID);

                // add employee เข้า List
                Program.personList.AddNewPerson(employee);
            }

        }

        // ลงทะเบียนนักเรียน
        static Student RegisterStudent(string name, string password, int type,string employeeID)
        {
            return new Student(name, password, type, employeeID);
        }

        // ลงทะเบียนพนักงาน
        static Employee RegisterEmployee(string name, string password, int type, string employeeID)
        {
            return new Employee(name, password, type, employeeID);
        }

        // ใส่ชื่อ
        static string InputName()
        {
            Console.Write("Input Name: ");
            return Console.ReadLine();
        }

        // ใส่ password
        static string InputPassword()
        {
            Console.Write("Input Password: ");
            return Console.ReadLine();
        }

        // ใส่ประเภท student หรือ employee
        static int InputType()
        {
            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            int type = int.Parse(Console.ReadLine());
            while(type != 1 && type != 2)
            {
                Console.WriteLine("Please Try Again");
                Console.Write("Input User Type 1 = Student, 2 = Employee: ");
                type = int.Parse(Console.ReadLine());
            }

            return type;
        }

        // ใส่รหัสนักศึกษา
        static string InputStudentID()
        {
            Console.WriteLine("Student ID: ");
            return Console.ReadLine();
        }

        // ใส่รหัสพนักงาน
        static string InputEmployeeID()
        {
            Console.WriteLine("Employee ID: ");
            return Console.ReadLine();
        }

        // เรียกใข้ class PersonList
        static PersonList personList;
        
        // เตรียม List ไว้รองรับ personlist
        static void PreparePersonList()
        {
            Program.personList = new PersonList();
        }
    }

    // คลาส Person
    class Person
    {
        public string Name;
        public string Password;
        public int Type;

        public Person(string name, string password, int type)
        {
            this.Name = name;
            this.Password = password;
            this.Type = type;
        }

        public string GetName()
        {
            return this.Name;
        }
    }

    // คลาส Student ที่สืบทอดมาจาก Person
    class Student: Person
    {
        public string StudentID;

        public Student(string name, string password, int type, string studentID): base(name, password, type)
        {
            this.StudentID = studentID;
        }
    }

    // คลาส Employee ที่สืบทอดมาจาก Person
    class Employee : Person
    {
        public string EmployeeID;

        public Employee(string name, string password, int type, string employeeID) : base(name, password, type)
        {
            this.EmployeeID = employeeID;
        }
    }

    // คลาส PersonList สำหรับสร้าง List
    class PersonList
    {
        public List<Person> personList;
        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person newPerson)
        {
            this.personList.Add(newPerson);
        }

    }
}
