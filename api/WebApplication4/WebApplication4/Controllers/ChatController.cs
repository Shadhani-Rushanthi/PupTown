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
    public class ChatController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ChatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select chatId,userId,message,sentTo,createdDate,modifiedDate from
                            dbo.chat
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
        public JsonResult Post(Chat Psu)
        {
            string query = @"
                           insert into dbo.chat
                           ( userId,message,sentTo,createdDate,modifiedDate)
                    values (@userId,@message,@sentTo,@createdDate,@modifiedDate)
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
                    myCommand.Parameters.AddWithValue("@message", Psu.message);
                    myCommand.Parameters.AddWithValue("@sentTo", Psu.sentTo);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Chat Psu)
        {
            string query = @"
                           update dbo.chat
                            set userId=@userId,
                            message=@message,
                            sentTo=@sentTo,
                            createdDate=@createdDate,
                            modifiedDate=@modifiedDate
                            where chatId=@chatId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@chatId", Psu.chatId);
                    myCommand.Parameters.AddWithValue("@userId", Psu.userId);
                    myCommand.Parameters.AddWithValue("@message", Psu.message);
                    myCommand.Parameters.AddWithValue("@sentTo", Psu.sentTo);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
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
                           delete from dbo.chat
                            where chatId=@chatId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@chatId", id);

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
