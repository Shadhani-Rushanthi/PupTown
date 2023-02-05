using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class communitypostsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public communitypostsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select communityId,postId from
                            dbo.community_posts
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(communityposts Psu)
        {
            string query = @"
                           insert into dbo.community_posts
                           ( communityId,postId)
                    values (@communityId,@postId)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@communityId", Psu.communityId);
                    myCommand.Parameters.AddWithValue("@postId", Psu.postId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(communityposts Psu)
        {
            string query = @"
                           update dbo.community_posts
                            set postId=@postId
                            where communityId=@communityId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@communityId", Psu.communityId);
                    myCommand.Parameters.AddWithValue("@postId", Psu.postId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.community_posts
                            where communityId=@communityId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@communityId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
