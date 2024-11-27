using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public long OwnerRecordId { get; set; }
        public int Type { get; set; }
        public long? ParentId { get; set; }
        public string CreateDate { get; set; }
        public double? dayByDate { get; set; }

    }
}
