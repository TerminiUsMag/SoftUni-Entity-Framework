namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var xmlHelper = new XmlHelper();
            var sb = new StringBuilder();
            ImportClientDto[] clientDtos = xmlHelper.Deserialize<ImportClientDto[]>(xmlString, "Clients");

            ICollection<Client> validClients = new HashSet<Client>();
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                ICollection<Address> validAddresses = new HashSet<Address>();

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var validAdress = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };
                    validAddresses.Add(validAdress);
                }
                var validClient = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                    Addresses = validAddresses,
                };
                validClients.Add(validClient);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, validClient.Name));
            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var invoiceDtos = JsonConvert.DeserializeObject<HashSet<ImportInvoiceDto>>(jsonString);
            var existingClients = context.Clients.Select(c => c.Id);

            var validInvoices = new HashSet<Invoice>();

            foreach (var invoiceDto in invoiceDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime issueDate;
                DateTime dueDate;
                try
                {
                    issueDate = DateTime.Parse(invoiceDto.IssueDate);
                    dueDate = DateTime.Parse(invoiceDto.DueDate);

                }
                catch (Exception)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dueDate < issueDate || !existingClients.Contains(invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validInvoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId,
                };
                validInvoices.Add(validInvoice);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, validInvoice.Number));
            }
            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var validProducts = new HashSet<Product>();

            var productDtos = JsonConvert.DeserializeObject<HashSet<ImportProductDto>>(jsonString);
            var existingClients = context.Clients.Select(c => c.Id);
            foreach (var productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validProduct = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = (CategoryType)productDto.CategoryType,
                };
                foreach (var client in productDto.ClientIds.Distinct())
                {
                    if (!existingClients.Contains(client))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var pc = new ProductClient()
                    {
                        Product = validProduct,
                        ClientId = client
                    };
                    validProduct.ProductsClients.Add(pc);
                }
                validProducts.Add(validProduct);
                sb.AppendLine(String.Format(SuccessfullyImportedProducts, validProduct.Name, validProduct.ProductsClients.Count));
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
