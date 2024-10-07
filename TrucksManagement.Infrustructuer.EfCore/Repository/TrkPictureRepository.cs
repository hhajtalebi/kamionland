
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TrucksManagement.Application.contracts.TrkPictureApplication;
using TrucksManagement.Domain.TruckPictureAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Repository
{
    public class TrkPictureRepository:RepositoryBase<long,TruckPicture>,ITruckPictureRepository
    {
        private readonly TrcksContext _context;
        public TrkPictureRepository(TrcksContext context) : base(context)
        {
            _context = context;
        }

        public TruckPicture? GetTructPictureWithTruckAndCategory(long Id)
        {
            return _context.TruckPicture.Include(x => x.Truck).ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == Id);
        }

        public EditTrkPicture GetDetails(long id)
        {
            return _context.TruckPicture.Select(x => new EditTrkPicture()
            {
                Id = x.Id,
                PictureAlte = x.PictureAlte,
                PictureTitel = x.PictureTitel,
                TruckId = x.TruckId,
                pictureName=x.Picture,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<TrkPictureViewModel> TrkPicturesList()
        {
           return _context.TruckPicture.Include(x => x.Truck).Select(x => new TrkPictureViewModel()
            {
                Id = x.Id,
                PictureAlte = x.PictureAlte,
                PictureTitel = x.PictureTitel,
                TruckId = x.TruckId,
                pictureName = x.Picture,
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
