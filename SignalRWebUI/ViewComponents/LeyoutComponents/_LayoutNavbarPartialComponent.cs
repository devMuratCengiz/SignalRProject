using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LeyoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
