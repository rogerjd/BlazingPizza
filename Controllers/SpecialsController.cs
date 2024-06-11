using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;

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

        [HttpGet]
        public async Task<ActionResult<List<dynamic>>> GetSpecials()
        {
            using var conn = _SQLite3CtrlX.Sqlite3Conn;
            var sql = "select * from Pizza";
            var res = conn.Query(sql);
            foreach (var r in res)
            {
                Console.WriteLine(res);
            }

            return res.ToList();
        }
    }
}