using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System;
using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;

namespace CarService.Context
{
    public class CarServiceContext : ICarServiceContext
    {
        private readonly IList<Client> clients;
        private readonly IList<Employee> employees;
        private readonly IList<Part> parts;
        private readonly IList<Repair> repairs;
        private readonly IList<Room> rooms;
        private readonly IList<Service> services;

        public CarServiceContext()
        {
            clients = new List<Client>();
            employees = new List<Employee>();
            parts = new List<Part>();
            repairs = new List<Repair>();
            rooms = new List<Room>();
            services = new List<Service>();
        }

        IEnumerable<Client> ICarServiceContext.Clients => clients;

        IEnumerable<Employee> ICarServiceContext.Employees => employees;

        IEnumerable<Part> ICarServiceContext.Parts => parts;

        IEnumerable<Repair> ICarServiceContext.Repairs => repairs;

        IEnumerable<Room> ICarServiceContext.Rooms => rooms;

        IEnumerable<Service> ICarServiceContext.Services => services;
    }
}
