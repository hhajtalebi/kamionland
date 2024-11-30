using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Trucks
{
    public class TruckPicturesQueryViewModel
    {
        public long  Id { get; set; }
        public long TruckId { get; set; }
        public string PictureThum { get; set; }
        public string PictureAverage { get; set; }
        public string PictureFull { get; set; }
        public string PictureAlte { get; set; }
        public string PictureTitel { get; set; }
    }
}
