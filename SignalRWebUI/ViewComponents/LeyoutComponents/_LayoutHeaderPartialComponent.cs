using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LeyoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
