﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OvertimePayCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Company has located on Germany/Berlin.

            TimeZoneInfo berlinTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

            var employeeManager = new EmployeeManager();

            var employee = new Employee(1, "Aysegul", "Aydin");
            var employee2 = new Employee(2, "Yusuf", "Aydin");

            employeeManager.AddEmployee(employee);
            employeeManager.AddEmployee(employee2);

            List<Employee> employeeList = employeeManager.GetEmployeeList();

            EmployeeEnterence:

            int breakCount = 0;

            Console.WriteLine("Enter your Id for check-in.");

            try
            {
                int id = int.Parse(Console.ReadLine());

                var currentEmployee = employeeManager.GetEmployee(id);

                if (currentEmployee != null) {
                    
                    DateTimeOffset checkInTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, berlinTimeZone);

                    int breakTimeAsMinute = 0;

                    Console.WriteLine($"Welcome {currentEmployee.Name}. Check-in at {checkInTime.ToString("yyyy-MM-dd HH:mm:ss")} ");

                    Console.WriteLine("Enter b (break) for 15 minute break and q  (quit) for check-out");

                    var employeeStatus = Console.ReadLine().ToLower();

                    while( employeeStatus != "q")
                    {
                        if (employeeStatus == "b" && breakCount <= 2)
                        {
                            breakCount++;

                            Console.WriteLine("You give 15 min break.");

                            breakTimeAsMinute += 15;

                            Console.WriteLine($"Your break time for today is {breakTimeAsMinute} minute.");

                            employeeStatus = Console.ReadLine().ToLower();

                        }
                        else if (employeeStatus == "b" && breakCount > 2)
                        {
                            breakCount++;

                            Console.WriteLine($"You've run out of breaks for today.");

                            employeeStatus = Console.ReadLine().ToLower();

                        }
                        else
                        {
                            Console.WriteLine("Invalid value! Try again!");

                            employeeStatus = Console.ReadLine().ToLower();
                        }
                    }
                    if (employeeStatus == "q")
                    {
                        DateTimeOffset checkOutTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, berlinTimeZone).AddHours(10); //For mocking the check out time, 10 hours added to the current time.

                        double overtimePay = CalculateOvertimePay(checkInTime, checkOutTime, breakTimeAsMinute);

                        Console.WriteLine($"Check-out at {checkOutTime.ToString("yyyy-MM-dd HH:mm:ss")}. Have a nice day. Your overtime Pay for today is {overtimePay} TL.");

                    }

                }
                else // if the employee with given id is not valid
                {
                    Console.WriteLine("The employee with given id is not valid. Try again.");

                    goto EmployeeEnterence;
                }

            }
            catch
            {
                Console.WriteLine("Warning: Unexpected value. Try again.");

                goto EmployeeEnterence;
                
            }

            Console.WriteLine("Do you want to enter id for new employee or quit the program? y for yes or anything else for no.");

            var programStatus = Console.ReadLine().ToLower();

            if (programStatus == "y")
            {
                goto EmployeeEnterence;
            }
            
        }   




        static double CalculateOvertimePay(DateTimeOffset checkInTime, DateTimeOffset checkOutTime, int breakTimeAsMinute)
        {
            TimeSpan workingTime = checkOutTime - checkInTime;

            double overtime = workingTime.TotalHours - 8 - (float)breakTimeAsMinute/60;  // consider the casual working hours as 8 hours

            double overtimePay = 50 * overtime; // overtime pay is 50 TL per hour

            return overtimePay;

        }

    }

    public class EmployeeManager
    {
        public List<Employee> EmployeeList { get; set; }

        public EmployeeManager()
        {
            EmployeeList = new List<Employee>();
        }

        public int AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);

            return employee.Id;
        }

        public Employee GetEmployee(int id)
        {
            foreach(Employee employee in EmployeeList)
            {
                if (employee.Id == id)
                    return employee;
                
            }
            return null;
        }

        public List<Employee> GetEmployeeList()
        {
            return EmployeeList;
        }

    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Employee(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

    }
}
