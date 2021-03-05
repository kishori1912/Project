using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class FeedbackController : ApiController
    {
        // GET: Feedback
        public HttpResponseMessage Get()
        {
            string query = @"select * from dbo.Feedback";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Feedback fed)
        {
            try
            {
                string query = @"
                    insert into dbo.Feedback values
                    (
                    '" + fed.Name + @"',
                    '" + fed.Message + @"'
                    )";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!!!";
            }
            catch (Exception)
            {

                return "Faild to Add!!!";
            }
        }
        public string Put(Feedback fed)
        {
            try
            {
                string query = @"
                    update dbo.Feedback set 
                    Name='" + fed.Name + @"'
                    ,Message='" + fed.Message + @"'
                    where FeedbackID=" + fed.FeedbackID + @"
                    ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Update Successfully!!!";
            }
            catch (Exception)
            {

                return "Faild to Update!!!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                delete from dbo.Feedback where FeedbackID=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully!!!";
            }
            catch (Exception)
            {

                return "Faild to Delete!!!";
            }
        }
    }
}