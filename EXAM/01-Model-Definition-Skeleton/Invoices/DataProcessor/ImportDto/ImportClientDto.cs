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
    [XmlType("Client")]
    public class ImportClientDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.ClientNameMinLength)]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; }
        [XmlElement("NumberVat")]
        [Required]
        [MinLength(ValidationConstants.ClientNumberVatMinLength)]
        [MaxLength(ValidationConstants.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; }
        public ImportAddressDto[] Addresses { get; set; }
    }
    //    •	Id – integer, Primary Key
    //•	Name – text with length[10…25] (required)
    //•	NumberVat – text with length[10…15] (required)
    //•	Invoices – collection of type Invoicе
    //•	Addresses – collection of type Address
    //•	ProductsClients – collection of type ProductClient

}
