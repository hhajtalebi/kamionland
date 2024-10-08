using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManegment.Domain.CustomerDiscountAgg;

namespace DiscountManegment.Application
{
    public class CoustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CoustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }
        public OperationResulte Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResulte();

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId&&x.DiscountRate==command.DiscountRate))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var endDate=command.EndDate.ToGeorgianDateTime();
            var customerdiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, startdate,
                endDate, command.Reason);

            _customerDiscountRepository.Create(customerdiscount);
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResulte Edit(EditCustomerDiscount command)
        {
            var customerdiscount = _customerDiscountRepository.GetById(command.Id);
            var operation = new OperationResulte();
            if (customerdiscount == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId&&x.DiscountRate==command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var startdate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerdiscount.Edit(command.ProductId, command.DiscountRate,startdate,
                endDate, command.Reason);
        
            _customerDiscountRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditCustomerDiscount GetDetaile(long id)
        {
            return _customerDiscountRepository.GetDetaile(id);

        }

        public List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel)
        {
           return _customerDiscountRepository.Search(searchmodel);
        }
    }
}
