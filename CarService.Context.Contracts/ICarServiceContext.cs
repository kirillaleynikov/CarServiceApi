using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System;
using CarService.Context.Contracts.Models;

namespace CarService.Context.Contracts
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface ICarServiceContext
    {
        IEnumerable<Client> Clients { get; }

        IEnumerable<Employee> Employees { get; }
        IEnumerable<Repair> Repairs { get; }

        IEnumerable<Part> Parts { get; }

        IEnumerable<Room> Rooms { get; }

        IEnumerable<Service> Services { get; }
    }
}