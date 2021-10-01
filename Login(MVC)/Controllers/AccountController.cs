using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC_.Models;
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

       
        void connectionString()
        {
            con.ConnectionString = "data source=B-UPJAY; database=WPF; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='"+acc.Name+"' and password='"+acc.Password+"'";
            reader = com.ExecuteReader();
            if(reader.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
           
        }
    }
}