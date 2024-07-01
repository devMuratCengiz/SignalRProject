using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LeyoutComponents
{
	public class _LayoutScriptPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
