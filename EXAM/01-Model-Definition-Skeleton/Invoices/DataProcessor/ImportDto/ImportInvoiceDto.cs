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
    public class ImportInvoiceDto
    {
        [JsonProperty("Number")]
        [Required]
        [Range(ValidationConstants.InvoiceNumberMinValue, ValidationConstants.InvoiceNumberMaxValue)]
        public int Number { get; set; }
        [JsonProperty("IssueDate")]
        [Required]
        public string IssueDate { get; set; }
        [JsonProperty("DueDate")]
        [Required]
        public string DueDate { get; set; }
        [JsonProperty("Amount")]
        [Required]
        public decimal Amount { get; set; }
        [JsonProperty("CurrencyType")]
        [Required]
        [Range(ValidationConstants.InvoiceCurrencyTypeMinValue, ValidationConstants.InvoiceCurrencyTypeMaxValue)]
        public int CurrencyType { get; set; }
        [JsonProperty("ClientId")]
        [Required]
        public int ClientId { get; set; }
    }
    //    •	Id – integer, Primary Key
    //•	Number – integer in range[1, 000, 000, 000…1, 500, 000, 000] (required)
    //•	IssueDate – DateTime(required)
    //•	DueDate – DateTime(required)
    //•	Amount – decimal (required)
    //•	CurrencyType – enumeration of type CurrencyType, with possible values(BGN, EUR, USD) (required)
    //•	ClientId – integer, foreign key(required)
    //•	Client – Client

}
