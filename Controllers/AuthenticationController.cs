using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PMS.Models;
using System.Configuration;

namespace PMS.Controllers
{
    public class AuthenticationController : Controller
    {
        // Displays the login form
        public ActionResult Login()
        {
            return View("LoginForm");
        }

        // Handles the login action (checks email and password)
        [HttpPost]
        public ActionResult HandleLogin(string email, string password)
        {
            var user = AuthenticateUser(email, password);

            if (user != null)
            {
                // Store user data in session
                Session["userId"] = user.UserId;
                Session["userType"] = user.UserType;

                // Role-based routing
                if (user.UserType == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.UserType == "manager")
                {
                    return RedirectToAction("Index", "Manager");
                }
                else if (user.UserType == "teamMember")
                {
                    return RedirectToAction("Index", "TeamMember");
                }
            }

            // If user is null or authentication failed, return the login form view with an error message
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View("LoginForm");  // Make sure it returns a view in case of failure
        }



        // Authenticate the user by checking email and password from the database
        private dynamic AuthenticateUser(string email, string password)
        {
            // Declare a variable to hold user data
            dynamic user = null;

            // Retrieve the connection string from the web.config
            string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;

            // SQL query to check if the email and password match in the Profile table
            string query = "SELECT userId, userType FROM Profile WHERE email = @Email AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Prevent SQL Injection by using parameters
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            user = new
                            {
                                UserId = reader["userId"],
                                UserType = reader["userType"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return user;
        }


    }
}
