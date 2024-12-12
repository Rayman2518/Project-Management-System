using PMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class DepartmentController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;

        // CREATE DEPARTMENT PAGE (GET)
        public ActionResult Create()
        {
            return View();
        }

        // CREATE DEPARTMENT PAGE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("AddDepartment", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@depName", department.DepName);
                    command.Parameters.AddWithValue("@depLocation", department.DepLocation);
                    command.Parameters.AddWithValue("@depAnnualBudget", department.DepAnnualBudget);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Read");
            }
            return View(department);
        }




        // DELETE DEPARTMENT PAGE (GET)
        public ActionResult Delete(int id)
        {
            Department department = GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = department.DepId;
            ViewBag.DepartmentName = department.DepName;
            return View(department);
        }

        // DELETE DEPARTMENT PAGE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteDepartment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@depId", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Read");
        }




        // EDIT DEPARTMENT PAGE (GET)
        public ActionResult Update(int id)
        {
            Department department = GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // EDIT DEPARTMENT PAGE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int depId, string depName, string depLocation, decimal depAnnualBudget)
        {
            if (!string.IsNullOrEmpty(depName) && !string.IsNullOrEmpty(depLocation))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateDepartment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@depId", depId);
                    command.Parameters.AddWithValue("@depName", depName);
                    command.Parameters.AddWithValue("@depLocation", depLocation);
                    command.Parameters.AddWithValue("@depAnnualBudget", depAnnualBudget);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Read");
            }
            return View();
        }




        // READ DEPARTMENT PAGE
        public ActionResult Read()
        {
            List<Department> departments = GetDepartments(); // Fetch the list of departments from the database
            return View(departments); // Pass the list to the view
        }


        // Helper methods
        private Department GetDepartmentById(int id)
        {
            Department department = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Department WHERE depId = @depId", connection);
                command.Parameters.AddWithValue("@depId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        department = new Department()
                        {
                            DepId = (int)reader["depId"],
                            DepName = reader["depName"].ToString(),
                            DepLocation = reader["depLocation"].ToString(),
                            DepAnnualBudget = (int)reader["depAnnualBudget"]
                        };
                    }
                }
                connection.Close();
            }
            return department;
        }

        private List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ViewAllDepartments", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department()
                        {
                            DepId = (int)reader["depId"],
                            DepName = reader["depName"].ToString(),
                            DepLocation = reader["depLocation"].ToString(),
                            DepAnnualBudget = (int)reader["depAnnualBudget"]
                        });
                    }
                }
                connection.Close();
            }
            return departments;
        }
    }
}
