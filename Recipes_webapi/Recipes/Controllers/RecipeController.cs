using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipes.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;



namespace Recipes.Controllers
{
    public class RecipeController : ApiController
    {
        
        // GET: Recipe
        public HttpResponseMessage Get()
        {
            string query = @"select * from dbo.Recipe";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString))
            using (var cmd = new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        public string Post(Recipe rec)
        {
            try
            {
                string query = @"
                    insert into dbo.Recipe values
                    (
                    '" + rec.Title + @"',
                    '" + rec.Description + @"',
                    '" + rec.Serving + @"',
                    '" + rec.Cuisine + @"',
                    '" + rec.Preptime + @"',
                    '" + rec.Tottime + @"',
                    '" + rec.Ingradients + @"',
                    '" + rec.Steps1 + @"',
                    '" + rec.Steps2 + @"',
                    '" + rec.Steps3 + @"',
                    '" + rec.Steps4 + @"',
                    '" + rec.Steps5 + @"',
                    '" + rec.Steps6 + @"',
                    '" + rec.Steps7 + @"',
                    '" + rec.Steps8 + @"',
                    '" + rec.Steps9 + @"',
                    '" + rec.Photo + @"',
                    '" + rec.PostedBy + @"'
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
        public string Put(Recipe rec)
        {
            try
            {
                string query = @"
                    update dbo.Recipe set 
                    Title='" + rec.Title + @"',
                    Description='" + rec.Description + @"',
                    Serving='" + rec.Serving + @"',
                    Cuisine='" + rec.Cuisine + @"',
                    Preptime='" + rec.Preptime + @"',
                    Tottime='" + rec.Tottime + @"',
                    Ingradients='" + rec.Ingradients + @"',
                    Steps1='" + rec.Steps1 + @"',
                    Steps2='" + rec.Steps2 + @"',
                    Steps3='" + rec.Steps3 + @"',
                    Steps4='" + rec.Steps4 + @"',
                    Steps5='" + rec.Steps5 + @"',
                    Steps6='" + rec.Steps6 + @"',
                    Steps7='" + rec.Steps7 + @"',
                    Steps8='" + rec.Steps8 + @"',
                    Steps9='" + rec.Steps9 + @"',
                    Photo='" + rec.Photo + @"',
                    PostedBy='" + rec.PostedBy + @"'
                    where RecipeID=" + rec.RecipeID + @"
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
                delete from dbo.Recipe where RecipeID=" + id + @"";
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

        [Route("api/Recipe/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalpath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);
                postedFile.SaveAs(physicalpath);
                return filename;
            }
            catch (Exception)
            {

                return "food.png";
            }
        }
    }
}