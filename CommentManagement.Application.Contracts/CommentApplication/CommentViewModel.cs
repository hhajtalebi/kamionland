namespace CommentManagement.Application.Contracts.CommentApplication
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public long OwnerRecordId { get; set; }
        public string OwnerName { get; set; }
        public int Type { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string CommentDate { get; set; }
    }
}
