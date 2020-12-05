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

        public string Stats()
        {
            return "This is the post Survey page but shows a breakdown of relevant stats. You can also go straight here.";
        }
    }
}