using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;

/*
Attribute Routing: The [Route] attribute on your controller and actions allows you to 
    specify routes directly on the controller. This means that requests to /specials 
    will be routed to your SpecialsController without needing additional configuration 
    in the Program.cs file.
Minimal Hosting Model: In .NET 6 and later, the minimal hosting model is used, 
    which simplifies the setup. When you call app.MapControllers(), it enables 
    attribute routing for all controllers decorated with [ApiController] and [Route]. 
Your SpecialsController works without the app.MapControllerRoute line 
    because of attribute routing enabled by the [Route] and [ApiController] attributes. 
    The app.MapControllerRoute line is useful for defining conventional routes for MVC 
    controllers but is not necessary for API controllers that use attribute routing. 

Explicit Route Attribute
Using [Route("specials")] explicitly defines the route for the SpecialsController. 
    This means that the controller will respond to requests at /specials.
Default Routing Convention
    If you don't use the [Route] attribute, the default routing convention can 
    infer the route based on the controller's name, but this requires you to set up a 
    conventional route in the Program.cs file.          
*/

//json
//  controller action that returns an object will, by default, return JSON when the [ApiController] attribute is used
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