using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Common.Entity.InterfaceDB;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;
using System.Data;

namespace CarService.Services.Implementations
{
    public class EmployeeService : IEmployeeService, IServiceAnchor
    {
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeWriteRepository employeeWriteRepository;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository,
            IEmployeeWriteRepository employeeWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.employeeReadRepository = employeeReadRepository;
            this.employeeWriteRepository = employeeWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<EmployeeModel>> IEmployeeService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await employeeReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<EmployeeModel>>(result);
        }

        async Task<EmployeeModel?> IEmployeeService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await employeeReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }
            return mapper.Map<EmployeeModel>(item);
        }

        async Task<EmployeeModel> IEmployeeService.AddAsync(string name, DateTime dateOfBirth, string phoneNumber, string email, CancellationToken cancellationToken)
        {
            var item = new Client
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email
            };

            employeeWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<EmployeeModel>(item);
        }

        async Task<EmployeeModel> IEmployeeService.EditAsync(EmployeeModel source, CancellationToken cancellationToken)
        {
            var targetClient = await employeeReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(source.Id);
            }

            targetClient.Name = source.Name;
            targetClient.DateOfBirth = source.DateOfBirth;
            targetClient.PhoneNumber = source.PhoneNumber;
            targetClient.Email = source.Email;
            employeeWriteRepository.Update(targetClient);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<EmployeeModel>(targetClient);
        }

        async Task IEmployeeService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetClient = await employeeReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }

            if (targetClient.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Клиент с идентификатором {id} уже удален");
            }

            employeeWriteRepository.Delete(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
