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
    public class communitiesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public communitiesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select userId,communityId,name,birthday,breed,purpose,createdDate,modifiedDate,profileImage,coverImage from
                            dbo.communities
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
        public JsonResult Post(communities Psu)
        {
            string query = @"
                           insert into dbo.communities
                           (userId,communityId,name,birthday,breed,purpose,createdDate,modifiedDate,profileImage,coverImage)
                    values (@userId,@communityId,@name,@birthday,@breed,@purpose,@createdDate,@modifiedDate,@profileImage,@coverImage)
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
                    myCommand.Parameters.AddWithValue("@communityId", Psu.communityId);
                    myCommand.Parameters.AddWithValue("@name", Psu.name);
                    myCommand.Parameters.AddWithValue("@birthday", Psu.birthday);
                    myCommand.Parameters.AddWithValue("@breed", Psu.breed);
                    myCommand.Parameters.AddWithValue("@purpose", Psu.purpose);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@profileImage", Convert.ToByte(Psu.profileImage));
                    myCommand.Parameters.AddWithValue("@coverImage", Convert.ToByte(Psu.coverImage));
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(communities Psu)
        {
            string query = @"
                           update dbo.communities
                            set userId=@userId,
                            name=@name,
                            birthday=@birthday,
                            breed=@breed,
                            purpose=@purpose,
                            createdDate=@createdDate,
                            modifiedDate=@modifiedDate,
                            profileImage=@profileImage,
                            coverImage=@coverImage
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
                    myCommand.Parameters.AddWithValue("@userId", Psu.userId);
                    myCommand.Parameters.AddWithValue("@communityId", Psu.communityId);
                    myCommand.Parameters.AddWithValue("@name", Psu.name);
                    myCommand.Parameters.AddWithValue("@birthday", Psu.birthday);
                    myCommand.Parameters.AddWithValue("@breed", Psu.breed);
                    myCommand.Parameters.AddWithValue("@purpose", Psu.purpose);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@profileImage", Convert.ToByte(Psu.profileImage));
                    myCommand.Parameters.AddWithValue("@coverImage", Convert.ToByte(Psu.coverImage));
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
                           delete from dbo.communities
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
