using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucksManagement.Domain.TruckAgg;

namespace TrucksManagement.Domain.TruckPictureAgg
{
    public class TruckPicture : EntityBase
    {
        public long TruckId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlte { get; private set; }
        public string PictureTitel { get; private set; }
        public bool IsDelete { get; private set; }

        public Truck Truck { get; private set; }
        public TruckPicture(long truckId, string picture,
            string pictureAlte, string pictureTitel)
        {
            TruckId = truckId;
            Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
            IsDelete = false;
        }
        public void Edit(long truckId, string picture, string pictureAlte, string pictureTitel)
        {
            TruckId = truckId;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
        }
        public void Delete()
        {
            this.IsDelete = true;
        }

        public void restor()
        {
            this.IsDelete = false;
        }
    }
}
