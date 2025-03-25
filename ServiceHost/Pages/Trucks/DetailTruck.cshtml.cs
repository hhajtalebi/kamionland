using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrucksApplication;
using TrucksManagement.Domain.TruckPictureAgg;

namespace ServiceHost.Pages.Trucks
{
    public class DetailTruckModel : PageModel
    {
        private readonly ITruckPictureRepository _truckPictureRepository;
        private readonly ITrucksApplication _trucksApplication;

        public DetailTruckModel(ITruckPictureRepository truckPictureRepository, ITrucksApplication trucksApplication)
        {
            _truckPictureRepository = truckPictureRepository;
            _trucksApplication = trucksApplication;
        }
        public TruckViewModel? Truck { get; set; }
        public void OnGet(string slug)
        {
            Truck = _trucksApplication.GetTruckBySlug(slug);
        }
    }
}
