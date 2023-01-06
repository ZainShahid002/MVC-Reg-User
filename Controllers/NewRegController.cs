using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Reg_User.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;



namespace MVC_Reg_User.Controllers
{
    public class NewRegController : Controller
    {
        // GET: NewReg
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc,HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery= "insert into [dbo].[MVCregUser] (Uname,Uemail,Upwd,Gender,Uimg) values(@Uname,@Uemail,@Upwd,@Gender,@Uimg)";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcom.Parameters.AddWithValue("@Uname", uc.Uname);
            sqlcom.Parameters.AddWithValue("Uemail", uc.Uemail);
            sqlcom.Parameters.AddWithValue("@Upwd", uc.Upwd);
            sqlcom.Parameters.AddWithValue("@Gender", uc.Gender);
            if(file!=null && file.ContentLength>0)
                {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/User-Images/"), filename);
                file.SaveAs(imgpath);

            }
            sqlcom.Parameters.AddWithValue("@Uimg", "~/User-Images/" + file.FileName);
            sqlcom.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = "User Record" + uc.Uname + "is saved successfully !";


            return View();
        }

    }
}