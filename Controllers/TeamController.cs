using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class TeamController : Controller
    {
        // Fetch teams from the database
        public JsonResult GetTeams()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;
            List<SelectListItem> teams = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT teamId, teamName FROM Team";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new SelectListItem
                        {
                            Text = reader["teamName"].ToString(),
                            Value = reader["teamId"].ToString()
                        });
                    }
                }
            }
            return Json(teams, JsonRequestBehavior.AllowGet);
        }
    }
}
