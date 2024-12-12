using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PMS.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Users()
        {
            return View("Users");
        }

        public ActionResult Departments()
        {
            return View("Departments");
        }

        public ActionResult Projects()
        {
            return View("Projects");
        }

        public ActionResult Teams()
        {
            return View("Teams");
        }

        public ActionResult Leads()
        {
            return View("Leads");
        }


        public ActionResult Tasks()
        {
            return View("Tasks");
        }

        public ActionResult Reports()
        {
            return View("Reports");
        }

        public ActionResult ProfileManagement()
        {
            return View("ProfileManagement");
        }


        // Handle AJAX GET request to fetch data for admin table
        [HttpGet]
        public JsonResult GetAllAdmins()
        {
            try
            {
                // Get the connection string from Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;

                // Initialize a list to hold admin records
                var adminRecords = new List<object>();

                // Use ADO.NET to execute the stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetAllAdmins", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Execute the command and read the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                adminRecords.Add(new
                                {
                                    userName = reader["userName"].ToString(),
                                    email = reader["email"].ToString(),
                                    password = reader["password"].ToString(),
                                    profilePicPath = reader["profilePicPath"].ToString(),
                                    adminType = reader["adminType"].ToString(),
                                    roleDescription = reader["roleDescription"].ToString()
                                });
                            }
                        }
                    }
                }

                // Return the records as JSON
                return Json(new { success = true, data = adminRecords }, JsonRequestBehavior.AllowGet);
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related errors
                return Json(new { success = false, message = "Database error: " + sqlEx.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Handle other errors
                return Json(new { success = false, message = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }







    }
}