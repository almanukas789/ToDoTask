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
                return null;
            }
        }
        [HttpPost]
        public string Post(string task, int time)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO toDoTable(task,time,status) VALUES ('"+ task +"','"+ time +"','0')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return "Record was inserted!";
            }
            else
            {
                return "Try again!";
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM toDoTable WHERE ID = '"+ id +"'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close(); 
            if (i > 0)
            {
                return "Record was deleted!";
            }
            else
            {
                return "Try again!";
            }
        }
        [HttpPut]
        public string Put(int id, string task, int time, string status)
        {
            SqlCommand cmd = new SqlCommand("UPDATE toDoTable SET task = '"+task+"', status = '"+status+"', time = '"+time+"' WHERE ID = '"+id+"'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return "Record was updated!";
            }
            else
            {
                return "Try again!";
            }
        }

    }
}
