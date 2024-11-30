using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.DiscountCoustomer
{
    public interface ICoustomerDiscountQuery
    {
        public List<CoustomerDiscountQueryViewModel>? GetDiscountCoustomers();
    }
}
