using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.comment
{
    public interface ICommentQuery
    {
        public List<CommentQueryModel> GetDetailes(long Id, int type);
    }
}
