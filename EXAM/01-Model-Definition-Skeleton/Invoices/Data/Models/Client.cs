using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Invoices.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Addresses = new HashSet<Address>();
            this.ProductsClients = new HashSet<ProductClient>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<ProductClient> ProductsClients { get; set; }
    }
    //    •	Id – integer, Primary Key
    //•	Name – text with length[10…25] (required)
    //•	NumberVat – text with length[10…15] (required)
    //•	Invoices – collection of type Invoicе
    //•	Addresses – collection of type Address
    //•	ProductsClients – collection of type ProductClient

}