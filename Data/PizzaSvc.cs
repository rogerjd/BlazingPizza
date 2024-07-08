using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Models;
using Dapper;

namespace BlazingPizza.Data
{
    public class Pizza
    {

    }

    public class PizzaService
    {
        public async Task<IEnumerable<PizzaSpecial>> GetPizzasAsync(ISQLite3Ctrl _sqc)
        {
            IEnumerable<PizzaSpecial> specials;

            using var conn = _sqc.Sqlite3Conn;

            var sql = "select * from Pizza";
            specials = await conn.QueryAsync<PizzaSpecial>(sql); //todo: param, p); //todo:.ToList(); //todo: using
            return specials;
        }
    }
}