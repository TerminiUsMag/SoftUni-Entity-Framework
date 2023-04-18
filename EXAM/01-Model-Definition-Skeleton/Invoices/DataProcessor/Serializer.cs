namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            throw new NotImplementedException();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            throw new NotImplementedException();
            //var products = context.Products
            //    .Include(p=>p.ProductsClients)
            //    .ThenInclude(pc=>pc.Client)
            //    .Where(p=>p.ProductsClients.Any)
        }
    }
}