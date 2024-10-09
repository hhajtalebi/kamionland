using _0_Framework.Domain;
using SlideManagement.Applicaion.Contracts.SlideApplication;


namespace SlideManagement.Domain.SlideAgg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {

        EditSlideApplication GetDetailes(long id);

        List<SlideViewModel> GetList();
    }
}
