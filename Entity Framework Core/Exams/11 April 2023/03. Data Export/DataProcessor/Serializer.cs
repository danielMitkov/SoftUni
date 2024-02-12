namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context,DateTime date)
        {
            ExportClientDto[] clientDtos = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientDto
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = (double)i.Amount,
                            DueDate = i.DueDate.ToString("d",CultureInfo.InvariantCulture),
                            Currency = i.CurrencyType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return XmlSerialize(clientDtos,"Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context,int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    Name = p.Name,
                    Price = (double)p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products,Formatting.Indented);
        }
        public static string XmlSerialize<T>(T obj,string rootName) where T : class
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringWriter writer = new();

            XmlSerializerNamespaces namespaces = new();
            namespaces.Add(string.Empty,string.Empty);

            serializer.Serialize(writer,obj,namespaces);

            return writer.ToString();
        }
    }
}