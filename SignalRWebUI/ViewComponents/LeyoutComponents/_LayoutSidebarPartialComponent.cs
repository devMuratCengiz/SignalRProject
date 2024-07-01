using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace SignalRWebUI.ViewComponents.LeyoutComponents
{
	public class _LayoutSidebarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
