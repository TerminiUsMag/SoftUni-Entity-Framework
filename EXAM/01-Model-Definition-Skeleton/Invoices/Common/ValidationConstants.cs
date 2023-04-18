using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Common
{
    public class ValidationConstants
    {
        //Product
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;
        public const double ProductPriceMinValue = 5.00;
        public const double ProductPriceMaxValue = 1000.00;
        public const int ProductCategoryTypeMinValue = 0;
        public const int ProductCategoryTypeMaxValue = 4;


        //Address
        //    •	Id – integer, Primary Key
        //•	StreetName – text with length[10…20] (required)
        //•	StreetNumber – integer(required)
        //•	PostCode – text(required)
        //•	City – text with length[5…15] (required)
        //•	Country – text with length[5…15] (required)
        //•	ClientId – integer, foreign key(required)
        //•	Client – Client
        public const int AddressStreetNameMinLength = 10;
        public const int AddressStreetNameMaxLength = 20;
        public const int AddressCityMinLength = 5;
        public const int AddressCityMaxLength = 15;
        public const int AddressCountryMinLength = 5;
        public const int AddressCountryMaxLength = 15;

        //Invoice
        //        •	Id – integer, Primary Key
        //•	Number – integer in range[1, 000, 000, 000…1, 500, 000, 000] (required)
        //•	IssueDate – DateTime(required)
        //•	DueDate – DateTime(required)
        //•	Amount – decimal (required)
        //•	CurrencyType – enumeration of type CurrencyType, with possible values(BGN, EUR, USD) (required)
        //•	ClientId – integer, foreign key(required)
        //•	Client – Client
        public const int InvoiceNumberMinValue = 1000000000;
        public const int InvoiceNumberMaxValue = 1500000000;
        public const int InvoiceCurrencyTypeMinValue = 0;
        public const int InvoiceCurrencyTypeMaxValue = 2;


        //Client
        //    •	Id – integer, Primary Key
        //•	Name – text with length[10…25] (required)
        //•	NumberVat – text with length[10…15] (required)
        //•	Invoices – collection of type Invoicе
        //•	Addresses – collection of type Address
        //•	ProductsClients – collection of type ProductClient
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;
    }
}
