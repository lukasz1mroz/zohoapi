using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace zohotest.Services
{
    public interface IZohoService
    {
        void CreateContact(string firstName, string lastName, string phone, string email, string country, string city, string street, string zip);
        void CreateInvoice(string subject, long contactId, string productId, string pricebookId, string prodDescription, long quantity);
        void UpdateProduct(long? productId, long? stockAmount);
    }
}