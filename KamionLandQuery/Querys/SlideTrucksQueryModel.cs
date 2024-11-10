using SlideManagement.Infrastucture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamionLandQuery.Contracts.SlideTrucks;

namespace KamionLandQuery.Querys
{
    public class SlideTrucksQueryModel:ISlideTrucksQueryModel
    {
        public readonly SlideContext _SlideContext;

        public SlideTrucksQueryModel(SlideContext slideContext)
        {
            _SlideContext = slideContext;
        }


        public List<SlideTrucksQueryViewModel> GetSlidesTrucks()
        {
            return _SlideContext.Slides.Where(x => x.IsDelete == false).Select(x => new SlideTrucksQueryViewModel()
            {
                Picture = x.Picture,
                PictureAlte = x.PictureAlte,
                PictureTitel = x.PictureTitel,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Link = x.Link,
                Titel = x.Titel,
                IsDelete = x.IsDelete,
                Text = x.Text,
                Picturefull = x.Picturefull,
                
            }).ToList();
        }
    }
}
