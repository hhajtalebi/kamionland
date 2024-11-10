using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.SlideTrucks
{
    public interface ISlideTrucksQueryModel
    {
        public List<SlideTrucksQueryViewModel> GetSlidesTrucks();
        
    }
}
