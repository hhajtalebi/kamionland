

using _0_Framework.Application;

using AccountManagement.Application.Contracts.RoleApplication;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResulte Create(CreateRole command)
        {
            var operation = new OperationResulte();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var role = new Role(command.Name, new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Edit(EditRole command)
        {
            var operation = new OperationResulte();
            var role = _roleRepository.GetById(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);

            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            role.Edit(command.Name, permissions);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }
    }
}