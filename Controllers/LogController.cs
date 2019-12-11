using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Log.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet("TestInsert")]
        public  async void LogData()
        {
            var connString = "Host=localhost;Username=postgres;Password=postgres;Database=LogDb";
           

            using (var conn = new NpgsqlConnection(connString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("INSERT INTO jsonlogs (info) VALUES (CAST(@jb AS json))", conn))                {
                    var emp = new LogObject{
                        Application = "API",
                        JsonData = new KeyValuePair<string,string>("Parameter","Test"),
                        Type = "API Call",
                        Endpoint = "/API/GetData",
                        CreatedDate = DateTime.Now                


                    };           
                    
                    var jsonstring = JsonSerializer.Serialize(emp);
                    cmd.Parameters.AddWithValue("jb",jsonstring);
                    await cmd.ExecuteNonQueryAsync();
                };
            };

        }
    }
}
