﻿// Anita Martin
// Email: amartin98@cnm.edu
// Title: InClassInterfaceDemo

// Program.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager
{
    class Program
    {
        static void Main(string[] args)
        {
            HourlyEmployee hourEmp = new HourlyEmployee(2, "Bill", "Gates", 15.00M);
            hourEmp.Hours.Add(80.0);
            hourEmp.Hours.Add(90.0);
            hourEmp.Hours.Add(70.0);
            hourEmp.Phone = "555-1212";
            hourEmp.Email = "bgates@microsoft.com";

            DisplayEmployeeInfo(hourEmp,0,3);

            SalaryEmployee salaryEmp = new SalaryEmployee();
            salaryEmp.EmpNum = 2;
            salaryEmp.FirstName = "Alan";
            salaryEmp.LastName = "Turing";
            salaryEmp.Salary = 40000.0M;
            salaryEmp.Hours.Add(80.0);
            salaryEmp.Hours.Add(80.0);
            salaryEmp.Hours.Add(80.0);
            salaryEmp.Phone = "123-4566";
            salaryEmp.Email = "What's an email?";

            DisplayEmployeeInfo(salaryEmp, 0, 3);

            List<Employee> myEmployees = new List<Employee>();
            myEmployees.Add(salaryEmp);
            myEmployees.Add(hourEmp);
            decimal payroll = 0;
            foreach (Employee employee in myEmployees)
            {
                payroll += employee.Pay(0, 3);
            }
            Console.WriteLine("Payroll total for 0-2: " + payroll.ToString());
            Console.WriteLine();

            foreach (Employee employee in myEmployees)
            {

                Console.WriteLine("Employee: " + employee);
                if (employee is HourlyEmployee)
                {
                    //HourlyEmployee hourlyEmp = employee as HourlyEmployee;
                    HourlyEmployee hourlyEmp = (HourlyEmployee) employee;
                    Console.WriteLine("Hourly rate: " + hourlyEmp.HourlyRate);
                }
                if (employee is SalaryEmployee)
                {
                    SalaryEmployee salEmp = employee as SalaryEmployee;
                    Console.WriteLine("Salary: " + salEmp.Salary);
                }
            }

            Department dep = new Department("Sales Department");
            Department redep = new Department("Department of redundancy department");

            PhoneBook pb = new PhoneBook();
            pb.PhoneBookEntries.Add(hourEmp);
            pb.PhoneBookEntries.Add(salaryEmp);
            pb.PhoneBookEntries.Add(dep);
            pb.PhoneBookEntries.Add(redep);

            Console.WriteLine("\nCompany Phone Book");
            Console.WriteLine(pb.GetPhoneBook());
        }

        private static void DisplayEmployeeInfo(Employee emp, int payStart, int payEnd)
        {
            Console.WriteLine(emp.ToString());
            Console.WriteLine(emp.PaySummary);
            Console.WriteLine("Pay for periods " + payStart + "-" + payEnd + ": "
                + emp.Pay(payStart, payEnd).ToString("c"));
            Console.WriteLine();
        }

    }
}
