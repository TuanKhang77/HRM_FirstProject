using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QuanLyNhanSu.Models;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace QuanLyNhanSu.DAO
{
    public class EmployeeDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<Employee> getEmployees()
        {
            List<Employee> list = new List<Employee>();
            string str = "SELECT * FROM Employee";
            IDataReader dr = dataProvider.executeQuery2(str);
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.EmpID = dr.GetInt32(0);
                emp.Name = dr.GetString(1);
                emp.Birthday = dr.GetString(2);
                emp.Male = dr.GetString(3);
                emp.Phone = dr.GetString(4);
                emp.Address = dr.GetString(5);
                emp.Qualification = dr.GetString(6);
                list.Add(emp);
            }
            dr.Close();
            return list;
        }
        public Employee getEmployeeById(int id)
        {
            Employee emp = new Employee();
            string str = "SELECT * FROM Employee Where EmpID =" + id;
            IDataReader dr = dataProvider.executeQuery2(str);
            
            while (dr.Read())
            {
                
                    emp.EmpID = dr.GetInt32(0);
                    emp.Name = dr.GetString(1);
                    emp.Birthday = dr.GetString(2);
                    emp.Male = dr.GetString(3);
                    emp.Phone = dr.GetString(4);
                    emp.Address = dr.GetString(5);
                    emp.Qualification = dr.GetString(6);
                
            }
            dr.Close();
            return emp;
        }
        
        public void deleteEmployeeById(int id)
        {
            string strDelete = "Delete from Employee where EmpId = @id";
            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@id", id),
            };
            dataProvider.executeNonQuery(strDelete, param1);
        }

        public void insertEmployee(Employee emp)
        {
            string strcreate = "insert into employee values ( @empID, @name, @birthday, @male, @phone, @address, @qualification)";
            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@empID", emp.EmpID),
                new SqlParameter("@name", emp.Name),
                new SqlParameter("@birthday", emp.Birthday),
                new SqlParameter("@male", emp.Male),
                new SqlParameter("@phone", emp.Phone),
                new SqlParameter("@address", emp.Address),
                new SqlParameter("@qualification", emp.Qualification),
            };
            dataProvider.executeNonQuery(strcreate, param1);
        }

        public void updateEmployee(Employee emp)
        {
            string strupdate = "update Employee set " +               
                "Name = @name, " +
                "Birthday = @birthday, " +
                "Male = @male, " +
                "Phone = @phone, " +
                "Address = @address, " +
                "Qualification = @qualification" + " where EmpID = @empID";
            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@empID", emp.EmpID),
                new SqlParameter("@name", emp.Name),
                new SqlParameter("@birthday", emp.Birthday),
                new SqlParameter("@male", emp.Male),
                new SqlParameter("@phone", emp.Phone),
                new SqlParameter("@address", emp.Address),
                new SqlParameter("@qualification", emp.Qualification),
            };
            dataProvider.executeNonQuery(strupdate, param1);
        }
    }
}
