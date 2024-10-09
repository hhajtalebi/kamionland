using _0_Framework.Infrastructure;
using SlideManagement.Applicaion.Contracts.SlideApplication;
using SlideManagement.Domain.SlideAgg;

namespace SlideManagement.Infrastucture.EfCore.Repository
{
    public class SlideRepository:RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly SlideContext _context;
       
        public SlideRepository(SlideContext context) : base(context)
        {
            _context = context;
          
        }

        public EditSlideApplication? GetDetailes(long id)
        {
            return _context.Slides.Select(x => new EditSlideApplication()
            {
                BtnText = x.BtnText,
                Heading = x.Heading,
                Id = x.Id,
                PictureTitel = x.PictureTitel, 
                pictureNamethum = x.Picturethum,
                Text = x.Text,
                PictureAlte = x.PictureAlte,
                Titel = x.Titel,
                Link = x.Link,
                pictureName = x.Picture,
                CategoryId = x.CategoryId,
                CanonicalId = x.CanonicalId,
                pictureNamefull = x.Picturefull
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
          
            var query= _context.Slides.Select(x=>new SlideViewModel()
            {
                Picture = x.Picture,
                PictureAlte = x.PictureAlte,
                Titel = x.Titel,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Id = x.Id,
                PictureTitel = x.PictureTitel,
                IsDelete = x.IsDelete,
                CreateDate = x.CreationDateTime,
                Link= x.Link,
                Picturethum = x.Picturethum,
                CategoryId = x.CategoryId,
                canonicalId = x.CanonicalId,
                Picturefull = x.Picturefull
            });
                var Querys= query.ToList();
              
                return Querys;
        }
    }
}
