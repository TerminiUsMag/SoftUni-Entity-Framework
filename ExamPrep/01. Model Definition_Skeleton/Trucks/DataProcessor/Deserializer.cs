namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";
        private static XmlHelper xmlHelper;

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportDespatcherDto[] despatcherDtos = xmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();
            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validTruck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType,
                    };
                    validTrucks.Add(validTruck);
                }

                var validDespatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };
                validDespatchers.Add(validDespatcher);
                sb
                    .AppendLine(String.Format(SuccessfullyImportedDespatcher, validDespatcher.Name, validTrucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var clientsDto = JsonConvert.DeserializeObject<HashSet<ImportClientDto>>(jsonString);

            var validClients = new HashSet<Client>();
            var existingTrucks = context.Trucks.Select(t => t.Id).ToArray();

            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validClient = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (var truckId in clientDto.TruckIds.Distinct())
                {
                    if (!existingTrucks.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ct = new ClientTruck()
                    {
                        TruckId = truckId,
                        Client = validClient
                    };
                    validClient.ClientsTrucks.Add(ct);
                }
                validClients.Add(validClient);
                sb
                    .AppendLine(String.Format(SuccessfullyImportedClient, validClient.Name, validClient.ClientsTrucks.Count));
            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}