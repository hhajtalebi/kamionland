using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrucksManagement.Application.contracts.TrkPictureApplication
{
    public class CreateTrkPicture
    {
        public long TruckId { get;  set; }
        public IFormFile Picture { get;  set; }
        public string PictureAlte { get;  set; }
        public string PictureTitel { get;  set; }
       

    }
}
