﻿namespace Trucks.DataProcessor
{
    using Data;
    using Microsoft.Data.SqlClient.Server;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            ExportDespatcherDto[] despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                    .Select(t => new ExportTruckDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            var xmlHelper = new XmlHelper();

            return xmlHelper.Serialize<ExportDespatcherDto>(despatchers, "Despatchers");

        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(c => c.ClientsTrucks)
                .ThenInclude(ct => ct.Truck)
                .AsNoTracking()
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                              .Where(ct => ct.Truck.TankCapacity >= capacity)
                              .Select(ct => new
                              {
                                  TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                                  VinNumber = ct.Truck.VinNumber,
                                  TankCapacity = ct.Truck.TankCapacity,
                                  CargoCapacity = ct.Truck.CargoCapacity,
                                  CategoryType = ct.Truck.CategoryType.ToString(),
                                  MakeType = ct.Truck.MakeType.ToString()
                              })
                              .OrderBy(t => t.MakeType)
                              .ThenByDescending(t => t.CargoCapacity)
                              .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10);

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
