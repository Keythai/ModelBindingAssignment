using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Assignment.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [Route("[controller]")]
        public IActionResult Index([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
                return BadRequest(errors);
                
            }
            else
            {
                Random rand = new Random();
                int orderNumber = rand.Next(1, 99999);
                Order responseOrder = order;
                responseOrder.Id = orderNumber;
                return Json(new { responseOrder.Id });
            }
        }
    }
}
