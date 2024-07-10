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
        public int PizzaId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Vegetarian { get; set; }

        public bool Vegan { get; set; }
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