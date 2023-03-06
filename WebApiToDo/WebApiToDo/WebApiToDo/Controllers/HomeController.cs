using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace WebApiToDo.Controllers
{
    [ApiController]
    [Route("todo")]
    public class HomeController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-EDJE2GU\\SQLEXPRESS; database=toDoDB; Integrated Security=true;");
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM toDoTable", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }
        [HttpPost]
        public string Post(string task, string date)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO toDoTable(task,date,status) VALUES ('"+ task +"','"+ date +"','1')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return "Record was inserted!";
            }
            else
            {
                return "Try again!";
            }
        }
    }
}
