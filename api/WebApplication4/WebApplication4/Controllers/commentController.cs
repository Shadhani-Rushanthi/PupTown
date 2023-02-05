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
    public class commentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public commentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select userId,postId,cmtId,comment,createdDate,modifiedDate,IsSubcomment from
                            dbo.comment
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
        public JsonResult Post(comment Psu)
        {
            string query = @"
                           insert into dbo.comment
                           ( userId,postId,cmtId,comment,createdDate,modifiedDate,IsSubcomment)
                    values (@userId,@postId,@cmtId,@comments,@createdDate,@modifiedDate,@IsSubcomment)
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
                    myCommand.Parameters.AddWithValue("@postId", Psu.postId);
                    myCommand.Parameters.AddWithValue("@cmtId", Psu.cmtId);
                    myCommand.Parameters.AddWithValue("@comments", Psu.comments);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@IsSubcomment", Psu.IsSubcomment);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(comment Psu)
        {
            string query = @"
                           update dbo.comment
                            set userId=@userId,
                            postId=@postId,
                            comment=@comment,
                            createdDate=@createdDate,
                            modifiedDate=@modifiedDate,
                            IsSubcomment=@IsSubcomment
                            where cmtId=@cmtId
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
                    myCommand.Parameters.AddWithValue("@postId", Psu.postId);
                    myCommand.Parameters.AddWithValue("@cmtId", Psu.cmtId);
                    myCommand.Parameters.AddWithValue("@comment", Psu.comments);
                    myCommand.Parameters.AddWithValue("@createdDate", Psu.createdDate);
                    myCommand.Parameters.AddWithValue("@modifiedDate", Psu.modifiedDate);
                    myCommand.Parameters.AddWithValue("@IsSubcomment", Psu.IsSubcomment);
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
                           delete from dbo.comment
                            where cmtId=@cmtId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cmtId", id);

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
