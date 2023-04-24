using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using QuanLyNhanSu.DAO;
using QuanLyNhanSu.Models;
using System;
namespace QuanLyNhanSu.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAO dao = new EmployeeDAO();
        List<Employee> list = new List<Employee>();
        
        public IActionResult ViewList()
        {
            list = dao.getEmployees();
            return View(list);
        }
        
        public IActionResult DetailViewEmployee(int id)
        {
            
            Employee employee = new Employee();
            employee = dao.getEmployeeById(id);
            return View("DetailViewEmployee", employee);
        }

        
        public IActionResult DeleteEmployee(int id)
        {
            //var count = dao.checkdeleteEmp(EmpID);
            //if (count > 0)
            //{
            //    return Content("Khong the xoa");
            //}

            Employee emp = dao.getEmployeeById(id);
            return View("DeleteEmployee", emp);


            //list = dao.employees();
            //list.RemoveAt(EmpID);
            //return View("ViewList");
        }

        public IActionResult DeleteEmployeeConfirm(int id)
        {

            dao.deleteEmployeeById(id);

            return RedirectToAction(actionName: "ViewList");
        }

        public IActionResult CreateEmployeeForm()
        {
            return View("CreateEmployee");
        }

        public IActionResult CreateEmployee(Employee emp)
        {
            dao.insertEmployee(emp);
            return RedirectToAction(actionName: "ViewList");
        }
        public IActionResult EditEmployeeForm(int id)
        {
            Employee employee = dao.getEmployeeById(id);
            return View("EditEmployee", employee);
        }
        public IActionResult EditEmployee(Employee emp)
        {
            dao.updateEmployee(emp);
            return RedirectToAction(actionName: "ViewList");
        }
    }
}
