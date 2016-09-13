using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Online.Business.Entities;
using Online.Interfaces;
using Online.Business;
using Online.Business.Common;
using System.Security.Claims;
using Ninject;

namespace Online.API.WebApiControllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {

        [Inject]
        public ICustomerDataService _customerDataService { get; set; }

        /// <summary>
        /// Import Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userInformation"></param>
        /// <returns></returns>
        [Route("ImportCustomers")]
        [HttpPost]
        public HttpResponseMessage ImportCustomers(HttpRequestMessage request, [FromBody] CustomerInformation customerInformation)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerBusinessService.ImportCustomers(out transaction);
            if (transaction.ReturnStatus == false)
            {
                var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return badResponse;
            }

            customerInformation = new CustomerInformation();
            customerInformation.ReturnMessage = transaction.ReturnMessage;
            customerInformation.ReturnStatus = transaction.ReturnStatus;

            var response = Request.CreateResponse<CustomerInformation>(HttpStatusCode.OK, customerInformation);          
            return response;

        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userInformation"></param>
        /// <returns></returns>
        [Route("GetCustomers")]
        [HttpGet]
        public HttpResponseMessage GetCustomers(HttpRequestMessage request, [FromBody] CustomerInformation customerInformation)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            string customerCode = string.Empty;
            string companyName = string.Empty;
            int currentPageNumber = 1;
            int pageSize = 15;
            string sortExpression = "CompanyName";
            string sortDirection = "ASC";

            int totalRows = 0;

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            List<Customer> customers = customerBusinessService.GetCustomers(customerCode, companyName, currentPageNumber, pageSize, sortDirection, sortExpression, out totalRows, out transaction);      
            if (transaction.ReturnStatus == false)
            {
                var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return badResponse;
            }

            customerInformation = new CustomerInformation();        
            customerInformation.ReturnStatus = transaction.ReturnStatus;
            customerInformation.TotalRows = totalRows;
            customerInformation.TotalPages = Utilities.CalculateTotalPages(totalRows, pageSize);
            customerInformation.ReturnMessage.Add("page " + currentPageNumber + " of " + customerInformation.TotalPages + " returned at " + DateTime.Now.ToString());
            customerInformation.Customers = customers;

            var response = Request.CreateResponse<CustomerInformation>(HttpStatusCode.OK, customerInformation);
            return response;

        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [Route("GetCustomer")]
        [HttpPost]
        public HttpResponseMessage GetCustomer(HttpRequestMessage request, [FromBody] CustomerInformation customerInformation)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            int customerID = customerInformation.CustomerID;          

            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerInformation = customerBusinessService.GetCustomer(customerID, out transaction);
            if (transaction.ReturnStatus == false)
            {
                var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return badResponse;
            }
         
            customerInformation.ReturnStatus = transaction.ReturnStatus;           

            var response = Request.CreateResponse<CustomerInformation>(HttpStatusCode.OK, customerInformation);
            return response;

        }


        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [Route("UpdateCustomer")]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(HttpRequestMessage request, [FromBody] CustomerInformation customerInformation)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            if (request.Headers.Authorization == null)
            {
                transaction.ReturnMessage.Add("Your session is invalid.");
                transaction.ReturnStatus = false;
                var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.Unauthorized, transaction);
                return badResponse;
            }

            string tokenString = request.Headers.Authorization.ToString();
                   
            CustomerBusinessService customerBusinessService = new CustomerBusinessService(_customerDataService);
            customerBusinessService.UpdateCustomer(customerInformation, out transaction);
            if (transaction.ReturnStatus == false)
            {
                var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return badResponse;
            }

            customerInformation.ReturnStatus = true;
            customerInformation.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CustomerInformation>(HttpStatusCode.OK, customerInformation);
            return response;


        }



    }
}