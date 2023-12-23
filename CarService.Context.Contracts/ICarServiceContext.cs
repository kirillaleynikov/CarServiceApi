using CarService.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.Context.Contracts
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface ICarServiceContext
    {
        DbSet<Client> Clients { get; }

        DbSet<Employee> Employees { get; }

        DbSet<Repair> Repairs { get; }

        DbSet<Part> Parts { get; }

        DbSet<Room> Rooms { get; }

        DbSet<Service> Services { get; }
    }
}