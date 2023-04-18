using Invoices.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
        public string StreetName { get; set; } = null!;
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(ValidationConstants.AddressCityMaxLength)]
        public string City { get; set; } = null!;
        [Required]
        [MaxLength(ValidationConstants.AddressCountryMaxLength)]
        public string Country { get; set; }
        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
    //    •	Id – integer, Primary Key
    //•	StreetName – text with length[10…20] (required)
    //•	StreetNumber – integer(required)
    //•	PostCode – text(required)
    //•	City – text with length[5…15] (required)
    //•	Country – text with length[5…15] (required)
    //•	ClientId – integer, foreign key(required)
    //•	Client – Client

}
