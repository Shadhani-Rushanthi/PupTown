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
    public class matchController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public matchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{breed}")]
        public JsonResult Get(string breed)
        {
            string query = @"
                            select userId,breed,birthday,openforbreading,name,createdDate,modifiedDate,profileImage,gender from
                            dbo.Personal_User where breed = @breed and openforbreading = 'open'
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PupTowncon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@breed", breed);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
