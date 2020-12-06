using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace AGsite.Controllers
{
    public class SurveyController : Controller
    {
        // 
        // GET: /Survey

        public IActionResult Survey()
        {
            return View();
        }

        
        // GET: /Survey/Stats

    }
}