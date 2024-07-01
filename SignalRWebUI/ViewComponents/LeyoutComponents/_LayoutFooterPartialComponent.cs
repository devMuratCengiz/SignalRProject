using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LeyoutComponents
{
	public class _LayoutFooterPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
