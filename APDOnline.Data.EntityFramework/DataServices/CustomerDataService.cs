using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online.Interfaces;
using Online.Business.Entities;
using System.Linq.Dynamic;

namespace Online.Data.EntityFramework
{
    public class CustomerDataService : EntityFrameworkService, ICustomerDataService
    {
        /// <summary>
        /// Validate Duplicate Customer
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public Boolean ValidateDuplicateCustomer(string customerCode)
        {
            Customer customer = dbConnection.Customers.Where(c => c.CustomerCode == customerCode).SingleOrDefault();
            if (customer == null) return true;
            return false;
        }        

        public void CreateCustomer(Business.Entities.Customer customer)
        {
            DateTime now = DateTime.Now;
            Customer custom = new EntityFramework.Customer();
            custom.DateCreated = now;
            custom.DateUpdated = now;
            dbConnection.Customers.Add(custom);
        }

        public void UpdateCustomer(Business.Entities.Customer customer)
        {
            customer.DateUpdated = DateTime.Now;
        }

        Business.Entities.Customer ICustomerDataService.GetCustomer(int customerID)
        {
            Business.Entities.Customer custom = new Business.Entities.Customer();
            Customer customer = dbConnection.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault();
            if (custom != null)
            {
                custom.AddressLine1 = customer.AddressLine1;
                custom.AddressLine2 = customer.AddressLine2;
                custom.City = customer.City;
                custom.CompanyName = customer.CompanyName;
                custom.CustomerCode = customer.CustomerCode;
                custom.CustomerID = customer.CustomerID;
                custom.DateCreated = customer.DateCreated;
                custom.DateUpdated = customer.DateUpdated;
                custom.PhoneNumber = customer.PhoneNumber;
                custom.State = customer.State;
                custom.ZipCode = customer.ZipCode;
            }
            return custom;
        }

        List<Business.Entities.Customer> ICustomerDataService.GetCustomers(string customerCode, string companyName, int currentPageNumber, int pageSize, string sortDirection, string sortExpression, out int totalRows)
        {

            if (sortExpression.Length == 0) sortExpression = "CompanyName";

            if (sortDirection.Length == 0) sortDirection = "ASC";

            sortExpression = sortExpression + " " + sortDirection;

            var customerQuery = dbConnection.Customers.AsQueryable();

            if (customerCode != null && customerCode.Trim().Length > 0)
            {
                customerQuery = customerQuery.Where(c => c.CustomerCode.StartsWith(customerCode));
            }

            if (companyName != null && companyName.Trim().Length > 0)
            {
                customerQuery = customerQuery.Where(c => c.CompanyName.StartsWith(companyName));
            }

            totalRows = customerQuery.Count();

            List<Customer> customers = customerQuery.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
            List<Business.Entities.Customer> custom = new List<Business.Entities.Customer>();
            for (int i = 0; i <= customers.Count - 1; i++)
            {
                Business.Entities.Customer cust = new Business.Entities.Customer();
                cust.AddressLine1 = customers[i].AddressLine1;
                cust.AddressLine2 = customers[i].AddressLine2;
                cust.City = customers[i].City;
                cust.CompanyName = customers[i].CompanyName;
                cust.CustomerCode = customers[i].CustomerCode;
                cust.CustomerID = customers[i].CustomerID;
                cust.DateCreated = customers[i].DateCreated;
                cust.DateUpdated = customers[i].DateUpdated;
                cust.PhoneNumber = customers[i].PhoneNumber;
                cust.State = customers[i].State;
                cust.ZipCode = customers[i].ZipCode;
                custom.Add(cust);
            }
            totalRows = customers.Count;
            return custom;
        }

        List<Business.Entities.Customer> ICustomerDataService.GetCustomers(string customerCode)
        {
            List<Business.Entities.Customer> custom = new List<Business.Entities.Customer>();
            List<Customer> customers = dbConnection.Customers.Where(c => c.CustomerCode == customerCode).ToList();
            for (int i = 0; i <= customers.Count - 1; i++)
            {
                Business.Entities.Customer cust = new Business.Entities.Customer();
                cust.AddressLine1 = customers[i].AddressLine1;
                cust.AddressLine2 = customers[i].AddressLine2;
                cust.City = customers[i].City;
                cust.CompanyName = customers[i].CompanyName;
                cust.CustomerCode = customers[i].CustomerCode;
                cust.CustomerID = customers[i].CustomerID;
                cust.DateCreated = customers[i].DateCreated;
                cust.DateUpdated = customers[i].DateUpdated;
                cust.PhoneNumber = customers[i].PhoneNumber;
                cust.State = customers[i].State;
                cust.ZipCode = customers[i].ZipCode;
                custom.Add(cust);
            }
            return custom;
        }
    }
}
