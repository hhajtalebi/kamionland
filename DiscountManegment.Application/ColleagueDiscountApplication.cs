using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiscountManegment.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        public OperationResulte Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResulte();
            if (_colleagueDiscountRepository.Exists(x => x.PoroductId == command.PoroductId))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);
            var colleague = new Colleague(command.PoroductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleague);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResulte Edit(EditColleagueDiscount command)
        {
            var colleague = _colleagueDiscountRepository.GetById(command.Id);

            var operation = new OperationResulte();

            if (colleague == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

          
            colleague.Edit(command.PoroductId, command.DiscountRate);

            _colleagueDiscountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Delete(long id)
        {
            var colleague = _colleagueDiscountRepository.GetById(id);

            var operation = new OperationResulte();

            if (colleague == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

           
            colleague.IsInDelete();

            _colleagueDiscountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Restore(long id)
        {
            var colleague = _colleagueDiscountRepository.GetById(id);

            var operation = new OperationResulte();

            if (colleague == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);


            colleague.Restore();

            _colleagueDiscountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetaile(long id)
        {
            return _colleagueDiscountRepository.GetDetaile(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            return _colleagueDiscountRepository.Search(searchmodel);
        }
    }
}
