namespace CommentManagement.Application.Contracts.CommentApplication
{
    public class AddComment
    {
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string Message { get; set; }
        public string Website { get; set; }
        public long OwnerRecordId { get; set; }
        public int Type { get; set; }
        public long ParentId { get; set; }
    }
}
