using Microsoft.AspNetCore.Mvc;

namespace TopLearn.Wab.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index() => View();
		
	}
}
