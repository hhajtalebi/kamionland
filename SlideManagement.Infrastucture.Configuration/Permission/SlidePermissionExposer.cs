using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;

namespace SlideManagement.Infrastucture.Configuration.Permission
{
    public class SlidePermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "مدیریت اسلایدر",new List<PermissionDto>
                    {
                        new PermissionDto(SlidePermissions.ListSlide,"لیست اسلایدر ها"),
                        new PermissionDto(SlidePermissions.CreateSlide,"افزودن اسلایدر"),
                        new PermissionDto(SlidePermissions.EditSlide,"ویرایش اسلایدر"),
                    }
                }
            };
        }
    }
}
