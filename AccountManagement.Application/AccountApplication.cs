using _0_Framework.Application;
using _0_Framework.Application.AuthHelper;
using _0_Framework.Application.HashPassword;
using AccountManagement.Application.Contracts.AccountApplication;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication:IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper _authHelper;
        public AccountApplication(IAccountRepository accountRepository,
            IPasswordHasher passwordHasher,IFileUploader fileUploader
            ,IRoleRepository roleRepository,IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _roleRepository = roleRepository;
            _authHelper = authHelper;
          
        }
        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.GetById(id);
            return new AccountViewModel()
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile
            };
        }

        public AccountViewModel GetAccountBy(string Mobile)
        {
            return _accountRepository.GetAccountBy(Mobile);
        }

        public OperationResulte Register(RegisterAccount command)
        {
            var operation= new OperationResulte();
           
            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
           
            var path = $"profilePhotos";

            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);

            var securityCode = CodeGenerator.Generate("sc");

            var account = new Account(command.Fullname, command.Username, password, command.Mobile, command.Address,command.RoleId,
                picturePath,securityCode);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Edit(EditAccount command)
        {
            var operation = new OperationResulte();
            var account = _accountRepository.GetById(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                    (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var securityCode = CodeGenerator.Generate("sc");
            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, picturePath, command.Address,securityCode);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte ChangePassword(ChangePassword command)
        {
           var operation=new OperationResulte();
           var account = _accountRepository.GetById(command.Id);
           if (account == null)
              return operation.Failed(ApplicationMeasages.RecordNotFound);
           if (command.Password != command.RePassword)
               return operation.Failed(ApplicationMeasages.PasswordsNotMatch);
           var password = _passwordHasher.Hash(command.Password);
           account.ChangePassword(password);
           _accountRepository.SaveChanges();
           return operation.Succedded();
        }

        public OperationResulte changeSecurityCode(ChangeSecurityCode command)
        {
            var operation = new OperationResulte();
            var account = _accountRepository.GetById(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);
            if (account.SecurityCode != command.UserCode)
                return operation.Failed(ApplicationMeasages.securityCodeNotFound);
            var securityCode = CodeGenerator.Generate("sc");
            account.ChangeSecurityCode(securityCode);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResulte Login(Login command)
        {
            var operation = new OperationResulte();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMeasages.WrongUserPass);
            (bool Verified, bool NeedUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMeasages.WrongUserPass);

            var permissions = _roleRepository.GetById(account.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, account.Username,
                account.Mobile, permissions,account.ProfilePhoto,account.Address);
            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public OperationResulte LoginFromMobile(LoginFromMobile command)
        {
            var operation = new OperationResulte();
            var account = _accountRepository.GetByCode(command.Code);
            if (account == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);
            if (account.SecurityCode != command.Code)
                return operation.Failed(ApplicationMeasages.securityCodeNotFound);

            var securityCode = CodeGenerator.Generate("sc");
            account.ChangeSecurityCode(securityCode);
            _accountRepository.SaveChanges();

            var permissions = _roleRepository.GetById(account.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();
            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, account.Username,
                account.Mobile, permissions, account.ProfilePhoto, account.Address);
            _authHelper.Signin(authViewModel);
           
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
           return _accountRepository.Search(searchModel);
        }

        public void Logout()
        {
           _authHelper.SignOut();

        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public long AccountCount()
        {
            return _accountRepository.AccountCount();
        }
    }
}
