namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context,string xmlString)
        {
            ImportClientDto[] clientDtos = XmlDeserialize<ImportClientDto[]>(xmlString,"Clients");

            List<Client> clients = new();
            StringBuilder sb = new();

            foreach(ImportClientDto clientDto in clientDtos)
            {
                if(!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };
                foreach(ImportAddressDto addressDto in clientDto.Addresses)
                {
                    if(!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    client.Addresses.Add(new Address
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    });
                }
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients,client.Name));
            }
            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context,string jsonString)
        {
            ImportInvoiceDto[] invoiceDtos = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString)!;

            List<Invoice> invoices = new();
            StringBuilder sb = new();

            int[] clientIds = context.Clients
                .Select(c => c.Id)
                .ToArray();

            foreach(ImportInvoiceDto invoiceDto in invoiceDtos)
            {
                bool isIssueDateValid = DateTime.TryParse(invoiceDto.IssueDate
                    ,CultureInfo.InvariantCulture
                    ,DateTimeStyles.None
                    ,out DateTime issueDate);

                bool isDueDateValid = DateTime.TryParse(invoiceDto.DueDate
                    ,CultureInfo.InvariantCulture
                    ,DateTimeStyles.None
                    ,out DateTime dueDate);

                if(!IsValid(invoiceDto)
                    || !isIssueDateValid
                    || !isDueDateValid
                    || dueDate < issueDate
                    || !clientIds.Contains(invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Invoice invoice = new Invoice
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };
                invoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices,invoice.Number));
            }
            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context,string jsonString)
        {
            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            List<Product> products = new();
            StringBuilder sb = new();

            int[] clientIds = context.Clients
            .Select(c => c.Id)
            .ToArray();

            foreach(ImportProductDto productDto in productDtos)
            {
                if(!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Product product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = (CategoryType)productDto.CategoryType
                };
                foreach(int id in productDto.Clients.Distinct())
                {
                    if(!clientIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    product.ProductsClients.Add(new ProductClient
                    {
                        Product = product,
                        ClientId = id
                    });
                }
                products.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts,product.Name,product.ProductsClients.Count));
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static T XmlDeserialize<T>(string xml,string rootName)
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringReader reader = new(xml);

            return (T)serializer.Deserialize(reader)!;
        }
        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto,validationContext,validationResult,true);
        }
    }
}
