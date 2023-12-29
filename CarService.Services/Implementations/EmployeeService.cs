using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Common.Entity.InterfaceDB;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;
using System.Data;
using CarService.Services.Contracts.ModelsRequest;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarService.Services.Implementations
{
    public class EmployeeService : IEmployeeService, IServiceAnchor
    {
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeWriteRepository employeeWriteRepository;
        private readonly IServiceValidatorService validatorService;
        public EmployeeService(IEmployeeReadRepository employeeReadRepository,
            IEmployeeWriteRepository employeeWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceValidatorService validatorService)
        {
            this.employeeReadRepository = employeeReadRepository;
            this.employeeWriteRepository = employeeWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        async Task<IEnumerable<EmployeeModel>> IEmployeeService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await employeeReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<EmployeeModel>(x));
        }

        async Task<EmployeeModel?> IEmployeeService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await employeeReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Employee>(id);
            }
            return mapper.Map<EmployeeModel>(item);
        }

        async Task<EmployeeModel> IEmployeeService.AddAsync(EmployeeModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();
            await validatorService.ValidateAsync(model, cancellationToken);

            var item = mapper.Map<Employee>(model);

            employeeWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<EmployeeModel>(item);
        }

        async Task<EmployeeModel> IEmployeeService.EditAsync(EmployeeModel source, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(source, cancellationToken);

            var targetClient = await employeeReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(source.Id);
            }

            targetClient = mapper.Map<Employee>(source);

            employeeWriteRepository.Update(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return mapper.Map<EmployeeModel>(targetClient);
        }

        async Task IEmployeeService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetClient = await employeeReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Employee>(id);
            }

            if (targetClient.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Сотрудник с идентификатором {id} уже удален");
            }

            employeeWriteRepository.Delete(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
