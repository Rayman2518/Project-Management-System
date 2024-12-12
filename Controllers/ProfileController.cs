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
    public class ProfileController : Controller
    {
        // Retrieve the connection string from the web.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;

        [HttpPost]
        public ActionResult AddProfile(FormCollection form)
        {
            string userType = form["UserType"]; // Retrieve user type from form
            string email = form["Email"];
            string password = form["Password"];
            string username = form["Username"];

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    if (userType == "admin")
                    {
                        string adminType = form["AdminType"]; // primary or secondary

                        try
                        {
                            using (SqlCommand command = new SqlCommand(adminType == "primary" ? "AddPrimaryAdmin" : "AddSecondaryAdmin", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@Password", password);
                                command.Parameters.AddWithValue("@UserName", username);

                                command.ExecuteNonQuery();

                                System.Diagnostics.Debug.WriteLine("Admin added successfully.");
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            System.Diagnostics.Debug.WriteLine("SQL Exception occurred while adding Admin:");
                            System.Diagnostics.Debug.WriteLine($"Message: {sqlEx.Message}");
                            System.Diagnostics.Debug.WriteLine($"Number: {sqlEx.Number}");
                            System.Diagnostics.Debug.WriteLine($"State: {sqlEx.State}");
                            System.Diagnostics.Debug.WriteLine($"Procedure: {sqlEx.Procedure}");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception occurred while adding Admin:");
                            System.Diagnostics.Debug.WriteLine($"Message: {ex.Message}");
                        }
                    }
                    else if (userType == "manager")
                    {
                        string domain = form["Domain"];
                        int experienceYears = int.Parse(form["Experience"]);
                        int yearlyPay = int.Parse(form["YearlyPay"]);
                        string depName = form["Department"];

                        try
                        {
                            using (SqlCommand command = new SqlCommand("AddManager", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Add parameters to the command
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@Password", password);
                                command.Parameters.AddWithValue("@UserName", username);
                                command.Parameters.AddWithValue("@Domain", domain);
                                command.Parameters.AddWithValue("@ExperienceYears", experienceYears);
                                command.Parameters.AddWithValue("@YearlyPay", yearlyPay);
                                command.Parameters.AddWithValue("@DepName", depName);

                                // Execute the SQL command
                                command.ExecuteNonQuery();

                                Console.WriteLine("Manager added successfully.");
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            // Log SQL specific errors
                            System.Diagnostics.Debug.WriteLine("SQL Exception occurred:");
                            System.Diagnostics.Debug.WriteLine($"Message: {sqlEx.Message}");
                            System.Diagnostics.Debug.WriteLine($"Number: {sqlEx.Number}");
                            System.Diagnostics.Debug.WriteLine($"State: {sqlEx.State}");
                            System.Diagnostics.Debug.WriteLine($"Procedure: {sqlEx.Procedure}");
                        }
                        catch (Exception ex)
                        {
                            // Log general errors
                            System.Diagnostics.Debug.WriteLine("Exception occurred:");
                            System.Diagnostics.Debug.WriteLine($"Message: {ex.Message}");
                        }
                    }
                    else if (userType == "team-member")
                    {
                        int rank = int.Parse(form["Rank"]);
                        int monthlyPay = int.Parse(form["MonthlyPay"]);
                        int weekWorkHours = int.Parse(form["WorkHours"]);
                        string depName = form["Department"];
                        string managerName = form["Manager"];
                        string teamName = form["Team"];

                        try
                        {
                            using (SqlCommand command = new SqlCommand("AddTeamMember", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@Password", password);
                                command.Parameters.AddWithValue("@UserName", username);
                                command.Parameters.AddWithValue("@Rank", rank);
                                command.Parameters.AddWithValue("@MonthlyPay", monthlyPay);
                                command.Parameters.AddWithValue("@WeekWorkHours", weekWorkHours);
                                command.Parameters.AddWithValue("@DepName", depName);
                                command.Parameters.AddWithValue("@ManagerName", managerName);
                                command.Parameters.AddWithValue("@TeamName", teamName);

                                command.ExecuteNonQuery();

                                System.Diagnostics.Debug.WriteLine("Team Member added successfully.");
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            System.Diagnostics.Debug.WriteLine("SQL Exception occurred while adding Team Member:");
                            System.Diagnostics.Debug.WriteLine($"Message: {sqlEx.Message}");
                            System.Diagnostics.Debug.WriteLine($"Number: {sqlEx.Number}");
                            System.Diagnostics.Debug.WriteLine($"State: {sqlEx.State}");
                            System.Diagnostics.Debug.WriteLine($"Procedure: {sqlEx.Procedure}");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception occurred while adding Team Member:");
                            System.Diagnostics.Debug.WriteLine($"Message: {ex.Message}");
                        }
                    }

                    TempData["Message"] = $"{userType} added successfully!";
                    return RedirectToAction("Users", "Admin");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error adding {userType}: {ex.Message}";
                return RedirectToAction("Users", "Admin");
            }
        }



    }
}