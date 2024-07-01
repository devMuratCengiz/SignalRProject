using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class SİgnalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
