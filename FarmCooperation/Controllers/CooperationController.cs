using Microsoft.AspNetCore.Mvc;

namespace FarmCooperation.Controllers
{
	public class CooperationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
