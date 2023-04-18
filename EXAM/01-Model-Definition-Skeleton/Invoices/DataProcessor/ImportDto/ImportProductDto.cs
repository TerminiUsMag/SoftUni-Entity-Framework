using Invoices.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ValidationConstants.ProductNameMinLength)]
        [MaxLength(ValidationConstants.ProductNameMaxLength)]
        public string Name { get; set; }
        [JsonProperty("Price")]
        [Required]
        [Range(ValidationConstants.ProductPriceMinValue,ValidationConstants.ProductPriceMaxValue)]
        public decimal Price { get; set; }
        [JsonProperty("CategoryType")]
        [Required]
        [Range(ValidationConstants.ProductCategoryTypeMinValue,ValidationConstants.ProductCategoryTypeMaxValue)]
        public int CategoryType { get; set; }
        [JsonProperty("Clients")]
        public int[] ClientIds { get; set; }
    }
    //    •	Id – integer, Primary Key
    //•	Name – text with length[9…30] (required)
    //•	Price – decimal in range[5.00…1000.00] (required)
    //•	CategoryType – enumeration of type CategoryType, with possible values(ADR, Filters, Lights, Others, Tyres) (required)
    //•	ProductsClients – collection of type ProductClient
}
