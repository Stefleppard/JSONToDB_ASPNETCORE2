using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using JSONToDB_ASPNETCORE2.Models;
using JSONToDB_ASPNETCORE2.Data;

namespace ExcelToDB_ASPNETCORE2.Controllers
{
    public class HomeController : Controller
    {
        private PricingContext _context;

        public HomeController(PricingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.PriceInfo.ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("api/index/GetAllPriceInfo/")]
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_context.PriceInfo.ToList());
        }

        [Route("api/index/GetPriceInfo/")]
        [HttpGet]
        //[HttpGet("{id:int}", Name = "GetPriceInfo")]
        public IActionResult GetById(int id)
        {
            var item = _context.PriceInfo.FirstOrDefault(t => t.Time == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }        

        [Route("api/index/PostPriceInfo/")]
        [HttpPost]
        public JsonResult PostPriceInfoJson([FromBody] PriceInfo priceInfo)
        {
            if (priceInfo == null)
            {
                return Json(_context.PriceInfo.ToList()); // return BadRequest();
            }

            if (priceInfo != null)
            {
                _context.PriceInfo.Add(priceInfo);
                _context.SaveChanges();
            }
            
            return Json(new
            {
                state = 0,
                msg = "Successfully Added Rows" 
            });
        }
    }
}
