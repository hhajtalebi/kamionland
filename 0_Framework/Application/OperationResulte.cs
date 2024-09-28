namespace _0_Framework.Application
{
    public class OperationResulte
    {
        public bool IsSuccedded { get; set; }
        public string Messege { get; set; }

        public OperationResulte()
        {
            IsSuccedded = false;
        }

        public OperationResulte Succedded(string message="عملیات با موفقیت انجام شد")
        {
            IsSuccedded=true;
            Messege = message;
            return this;
        }
        public OperationResulte Failed(string message )
        {
            IsSuccedded = false;
            Messege = message;
            return this;
        }
    }
}
