using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QuanLyNhanSu.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Male { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }

        public Employee()
        {}
        public Employee(int empID, string name, string birthday, string male, string phone, string address, string qualification)
        {
            EmpID = empID;
            Name = name;
            Birthday = birthday;
            Male = male;
            Phone = phone;
            Address = address;
            Qualification = qualification;
        }
    }
}
