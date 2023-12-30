using CarService.General;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Models;
using FluentValidation;
using CarService.Services.Validator;


namespace CarService.Services
{
    internal class ServicesValidatorService : IServiceValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ServicesValidatorService(IClientReadRepository clientReadRepository, IEmployeeReadRepository employeeReadRepository,
            IPartReadRepository partReadRepository, IRoomReadRepository roomReadRepository,IServiceReadRepository serviceReadRepository)
        {
            validators.Add(typeof(ClientModel), new ClientModelValidator());
            validators.Add(typeof(EmployeeModel), new EmployeeModelValidator());
            validators.Add(typeof(PartModel), new PartModelValidator());
            validators.Add(typeof(RoomModel), new RoomModelValidator());
            validators.Add(typeof(ServiceModel), new ServiceModelValidator());
            validators.Add(typeof(RepairModel), new RepairModelValidator(clientReadRepository,
                employeeReadRepository, partReadRepository, roomReadRepository, serviceReadRepository));
        }

        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new CarServiceValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
