using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace insertdata.Controllers
{
   
    public class InsertController : Controller
    {
         
        // GET: /Insert/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult insertdata()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertdata( )
        {

           // addemployee(name, email, gender, contact);
            return View();
        }

        public void addemployee(string name, string email, string gender, string contact)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\\users\\admin\\documents\\visual studio 2013\\Projects\\insertdata\\insertdata\\App_Data\\Database1.mdf;Integrated Security=True;");
            string s = "insert into employee(name,email,gender,contact)values('" + name + "','" + email + "','" + gender + "','" + contact + "')";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
	}
}