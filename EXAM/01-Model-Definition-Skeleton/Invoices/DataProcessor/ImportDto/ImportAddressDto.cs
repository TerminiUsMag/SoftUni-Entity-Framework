using Invoices.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {
        [XmlElement("StreetName")]
        [Required]
        [MinLength(ValidationConstants.AddressStreetNameMinLength)]
        [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
        public string StreetName { get; set; } = null!;
        [XmlElement("StreetNumber")]
        [Required]
        public int StreetNumber { get; set; }
        [XmlElement("PostCode")]
        [Required]
        public string PostCode { get; set; }
        [XmlElement("City")]
        [Required]
        [MinLength(ValidationConstants.AddressCityMinLength)]
        [MaxLength(ValidationConstants.AddressCityMaxLength)]
        public string City { get; set; }
        [XmlElement("Country")]
        [Required]
        [MinLength(ValidationConstants.AddressCountryMinLength)]
        [MaxLength(ValidationConstants.AddressCountryMaxLength)]
        public string Country { get; set; }
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
