using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class DepartmentController : Controller
    {
        // Fetch departments from the database
        public JsonResult GetDepartments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;
            List<SelectListItem> departments = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT depId, depName FROM Department";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(new SelectListItem
                        {
                            Text = reader["depName"].ToString(),
                            Value = reader["depId"].ToString()
                        });
                    }
                }
            }
            return Json(departments, JsonRequestBehavior.AllowGet);
        }
    }
}
