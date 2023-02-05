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
    public class personalfollowController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public personalfollowController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select userId,followedBy,StartedDate from
                            dbo.personal_follow
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
        public JsonResult Post(personalfollow Psu)
        {
            string query = @"
                           insert into dbo.personal_follow
                           ( userId,followedBy,StartedDate)
                    values (@userId,@followedBy,@StartedDate)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", Psu.userId);
                    myCommand.Parameters.AddWithValue("@followedBy", Psu.followedBy);
                    myCommand.Parameters.AddWithValue("@StartedDate", Psu.StartedDate);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(personalfollow Psu)
        {
            string query = @"
                           update dbo.personal_follow
                            set followedBy=@followedBy,
                            StartedDate=@StartedDate
                            where userId=@userId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", Psu.userId);
                    myCommand.Parameters.AddWithValue("@followedBy", Psu.followedBy);
                    myCommand.Parameters.AddWithValue("@StartedDate", Psu.StartedDate);
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
                           delete from dbo.personal_follow
                            where userId=@userId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@userId", id);

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
