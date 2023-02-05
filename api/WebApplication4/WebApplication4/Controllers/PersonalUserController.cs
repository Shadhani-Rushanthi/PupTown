using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonalUserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select userId,breed,birthday,openforbreading,name,createdDate,modifiedDate,profileImage,coverImage,gender from
                            dbo.Personal_User
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
        public JsonResult Post(PersonalUser Psu)
        {
            string query = @"
                           insert into dbo.Personal_User
                           (userId,breed,birthday,openforbreading,name,createdDate,modifiedDate,profileImage,coverImage,gender)
                    values (@userId,@breed,@birthday,@openforbreading,@name,@createdDate,@modifiedDate,@profileImage,@coverImage,@gender)
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
                    myCommand.Parameters.AddWithValue("@breed", Psu.breed);
                    myCommand.Parameters.AddWithValue("@birthday", Psu.birthday);
                    myCommand.Parameters.AddWithValue("@openforbreading", Psu.openforbreading);
                    myCommand.Parameters.AddWithValue("@name", Psu.name);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@profileImage", Convert.ToByte(Psu.profileImage));
                    myCommand.Parameters.AddWithValue("@coverImage", Convert.ToByte(Psu.coverImage));
                    myCommand.Parameters.AddWithValue("@gender", Psu.gender);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(PersonalUser Psu)
        {
            string query = @"
                           update dbo.Personal_User
                           set breed= @breed,
                            birthday=@birthday,
                            openforbreading=@openforbreading,
                            name=@name,
                            createdDate=@createdDate,
                            modifiedDate=@modifiedDate,
                            profileImage=@profileImage,
                            coverImage=@coverImage,
                            gender=@gender
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
                    myCommand.Parameters.AddWithValue("@breed", Psu.breed);
                    myCommand.Parameters.AddWithValue("@birthday", Psu.birthday);
                    myCommand.Parameters.AddWithValue("@openforbreading", Psu.openforbreading);
                    myCommand.Parameters.AddWithValue("@name", Psu.name);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@profileImage", Convert.ToByte(Psu.profileImage));
                    myCommand.Parameters.AddWithValue("@coverImage", Convert.ToByte(Psu.coverImage));
                    myCommand.Parameters.AddWithValue("@gender", Psu.gender);
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
                           delete from dbo.Personal_User
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
