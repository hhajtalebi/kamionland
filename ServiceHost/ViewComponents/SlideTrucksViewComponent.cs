using KamionLandQuery.Contracts.SlideTrucks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideTrucksViewComponent:ViewComponent
    {
        private readonly ISlideTrucksQueryModel _slideTrucks;

        public SlideTrucksViewComponent(ISlideTrucksQueryModel slideTrucks)
        {
            _slideTrucks = slideTrucks;
        }

        public IViewComponentResult Invoke()
        {
            var slide = _slideTrucks.GetSlidesTrucks();
            return View(slide);
        }
    }
}
