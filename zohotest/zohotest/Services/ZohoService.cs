using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.CRUD;
using zohotest.Models;

namespace zohotest.Services
{
    public class ZohoService : IZohoService
    {
        public void CreateContact(string firstName, string lastName, string phone, string email, string country, string city, string street, string zip)
        {
            ZCRMRecord record;
            record = ZCRMRecord.GetInstance("Contacts", null);
            record.SetFieldValue("First_Name", firstName); 
            record.SetFieldValue("Last_Name", lastName); 
            record.SetFieldValue("Phone", phone); 
            record.SetFieldValue("Email", email); 
            record.SetFieldValue("Mailing_City", city); 
            record.SetFieldValue("Mailing_Street", street); 
            record.SetFieldValue("Mailing_Country", country); 
            record.SetFieldValue("Mailing_Zip", zip);

            List<string> trigger = new List<string>() { "workflow", "approval", "blueprint" };
            string larID = "3477061000004353013";
            APIResponse response = record.Create(trigger, larID); 

            ZCRMRecord record1 = (ZCRMRecord)response.Data;

        }
        public JArray CreateProductDetails(string productId, string pricebookId, string prodDescription, long quantity)
        {
            ProductDetails productDetails = new ProductDetails();
            productDetails.product = JObject.FromObject(new Product(productId));
            productDetails.quantity = quantity;
            productDetails.product_description = prodDescription;
            productDetails.book = pricebookId;
            JArray result = new JArray(JObject.FromObject(productDetails));
            return result;
        }
        public void CreateInvoice(string subject, long contactId, string productId, string pricebookId, string prodDescription, long quantity)
        {
            ZCRMRecord record;
            record = ZCRMRecord.GetInstance("Invoices", null);
            //record.SetFieldValue("Account_Name", accountName);
            record.SetFieldValue("Subject", subject);
            record.SetFieldValue("Contact_Name", contactId);
            //record.SetFieldValue("Billing_Country", billingCountry);
            //record.SetFieldValue("Billing_City", billingCity);
            //record.SetFieldValue("Billing_Street", billingStreet);
            //record.SetFieldValue("Billing_Code", billingCode);
            //record.SetFieldValue("Due_Date", dueDate.ToShortDateString());
            record.SetFieldValue("Product_Details", CreateProductDetails(productId, pricebookId, prodDescription, quantity));

            List<string> trigger = new List<string>() { "workflow", "approval", "blueprint" };
            string larID = "3477061000004353013";
            APIResponse response1 = record.Create(trigger, larID);
            ZCRMRecord record1 = (ZCRMRecord)response1.Data;
        }
        public void UpdateProduct(long? productId, long? stockAmount)
        {
            ZCRMRecord record = ZCRMRecord.GetInstance("Products", productId);
            record.SetFieldValue("Qty_in_Stock", stockAmount);

            List<string> trigger = new List<string>() { "workflow", "approval", "blueprint" };
            APIResponse response = record.Update(trigger);

            ZCRMRecord record1 = (ZCRMRecord)response.Data;
        }
    }
}
