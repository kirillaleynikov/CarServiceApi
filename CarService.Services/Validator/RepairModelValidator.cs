using CarService.Repositories.Contracts;
using CarService.Services.Contracts.ModelsRequest;
using CarService.Services.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services.Validator
{
    internal class RepairModelValidator : AbstractValidator<RepairRequestModel>
    {
        private readonly IClientReadRepository clientReadRepository;
        private readonly IEmployeeReadRepository employeeReadRepository;
        private readonly IPartReadRepository partReadRepository;
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IServiceReadRepository serviceReadRepository;

        public RepairModelValidator(IClientReadRepository clientReadRepository, 
           IEmployeeReadRepository employeeReadRepository,
           IPartReadRepository partReadRepository,
           IRoomReadRepository roomReadRepository,
           IServiceReadRepository serviceReadRepository)
        {
            this.clientReadRepository = clientReadRepository;
            this.employeeReadRepository = employeeReadRepository;
            this.partReadRepository = partReadRepository;
            this.roomReadRepository = roomReadRepository;
            this.serviceReadRepository = serviceReadRepository;

            RuleFor(x => x.Service)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .MustAsync(async (x, cancellationToken) => await this.serviceReadRepository.IsNotNullAsync(x, cancellationToken))
                .WithMessage(MessageForValidation.NotFoundGuidMessage);

            RuleFor(x => x.PartToChange)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .MustAsync(async (x, cancellationToken) => await this.partReadRepository.IsNotNullAsync(x, cancellationToken))
                .WithMessage(MessageForValidation.NotFoundGuidMessage);

            RuleFor(x => x.ClientName)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .MustAsync(async (x, cancellationToken) => await this.clientReadRepository.IsNotNullAsync(x, cancellationToken))
                .WithMessage(MessageForValidation.NotFoundGuidMessage);

            RuleFor(x => x.RoomNumber)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .MustAsync(async (x, cancellationToken) => await this.roomReadRepository.IsNotNullAsync(x, cancellationToken))
                .WithMessage(MessageForValidation.NotFoundGuidMessage);

            RuleFor(x => x.StartRepair)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .GreaterThan(DateTimeOffset.UtcNow.AddMinutes(1)).WithMessage(MessageForValidation.InclusiveBetweenMessage);

            RuleFor(x => x.EndRepair)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .GreaterThan(DateTimeOffset.UtcNow.AddMinutes(1)).WithMessage(MessageForValidation.InclusiveBetweenMessage);

            RuleFor(x => x.Price)
                .InclusiveBetween(100, 5000).WithMessage(MessageForValidation.InclusiveBetweenMessage);

            RuleFor(x => x.MarkCar)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .WithMessage(MessageForValidation.NotFoundGuidMessage);

            RuleFor(x => x.GosNumber)
                .NotEmpty().WithMessage(MessageForValidation.DefaultMessage)
                .WithMessage(MessageForValidation.NotFoundGuidMessage);
        }
    }
}
