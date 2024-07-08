using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;

//json
//https://learn.microsoft.com/en-us/training/modules/interact-with-data-blazor-web-apps/5-exercise-access-data-from-blazor-components        
namespace BlazingPizza.Controllers
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController : Controller
    {
        readonly ISQLite3Ctrl _SQLite3CtrlX;
        public SpecialsController(ISQLite3Ctrl SQLite3CtrlX)
        {
            _SQLite3CtrlX = SQLite3CtrlX;
        }

        //json
        //https://learn.microsoft.com/en-us/training/modules/interact-with-data-blazor-web-apps/5-exercise-access-data-from-blazor-components        
        [HttpGet]
        public async Task<ActionResult<List<dynamic>>> GetSpecials()
        {
            using var conn = _SQLite3CtrlX.Sqlite3Conn;
            var sql = "select * from Pizza";
            var res = conn.Query(sql);
            return res.ToList();
        }
    }
}