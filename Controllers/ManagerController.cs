using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ManagerController : Controller
    {
        // Fetch managers from the database
        public JsonResult GetManagers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;
            List<SelectListItem> managers = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT m.managerId, p.userName FROM Manager m JOIN Profile p ON m.profileId = p.profileId";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        managers.Add(new SelectListItem
                        {
                            Text = reader["userName"].ToString(),
                            Value = reader["managerId"].ToString()
                        });
                    }
                }
            }
            return Json(managers, JsonRequestBehavior.AllowGet);
        }
    }
}
