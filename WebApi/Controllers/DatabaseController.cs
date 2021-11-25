using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/database")]
    public class DatabaseController : ControllerBase
    {
        private readonly IHostEnvironment _environment;
        private readonly IDatabaseManager _databaseManager;

        public DatabaseController(IDatabaseManager databaseManager, IHostEnvironment environment)
        {
            _databaseManager = databaseManager;
            _environment = environment;
        }

        [HttpGet]
        [Route("init")]
        public IActionResult CreateDatabaseAndTables()
        {
            if (_environment.IsProduction())
                return BadRequest("Only in dev");
            
            _databaseManager.CreateDatabaseAndTables();
            return Ok("Database and tables created successfully");
        }

        [HttpGet]
        [Route("data")]
        public IActionResult FillTables()
        {
            if (_environment.IsProduction())
                return BadRequest("Only in dev");
            
            _databaseManager.FillTables();
            return Ok("Tables have been filled");
        }
    }
}