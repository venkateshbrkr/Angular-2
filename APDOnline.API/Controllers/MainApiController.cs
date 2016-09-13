using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Configuration;
using Online.Business.Entities;
using Online.Business;
using Online.Interfaces;
using Online.Data.EntityFramework;
using System.Net.Http.Headers;
using System.Text;

namespace Online.API
{
    [RoutePrefix("api/main")]
    public class MainApiController : ApiController
    {
        IApplicationDataService applicationDataService;
        /// <summary>
        /// Constructor with Dependency Injection using Ninject
        /// </summary>
        /// <param name="dataService"></param>
        public MainApiController()
        {
            applicationDataService = new ApplicationDataService();
        }


        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        [Route("AuthenicateUser")]
        [HttpGet]
        public HttpResponseMessage AuthenicateUser([FromUri] string route)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.IsAuthenicated = User.Identity.IsAuthenticated;
            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);
            return response;

        }


        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        [Route("InitializeApplication")]
        [HttpPost]
        public HttpResponseMessage InitializeApplication([FromUri] ApplicationDTO newHireDataDTO)
        {
            bool isAuthenticated = false;          
            AccountsApiModel accountsWebApiModel = new AccountsApiModel();
            ApplicationApiModel applicationWebApiModel = new ApplicationApiModel();
            TransactionalInformation transaction = new TransactionalInformation();
            ApplicationInitializationBusinessService initializationBusinessService;            
            string username = string.Empty;
            try
            {
                //Theater Manager
                initializationBusinessService = new ApplicationInitializationBusinessService(applicationDataService);
                List<ApplicationMenu> menuItems = initializationBusinessService.GetMenuItems(1, out transaction);
                if (transaction.ReturnStatus == false)
                {
                    accountsWebApiModel.ReturnMessage = transaction.ReturnMessage;
                    accountsWebApiModel.ReturnStatus = transaction.ReturnStatus;
                    var badResponse = Request.CreateResponse<AccountsApiModel>(HttpStatusCode.BadRequest, accountsWebApiModel);
                    return badResponse;
                }
                accountsWebApiModel.ReturnStatus = transaction.ReturnStatus;
                accountsWebApiModel.IsAuthenicated = true;
                accountsWebApiModel.ReturnMessage.Add("Login successful.");
                accountsWebApiModel.MenuItems = menuItems;                
                isAuthenticated = true;               
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                accountsWebApiModel.ReturnMessage.Add(errorMessage);
                var badResponse = Request.CreateResponse<AccountsApiModel>(HttpStatusCode.BadRequest, accountsWebApiModel);
                return badResponse;
            }
            var response = Request.CreateResponse<AccountsApiModel>(HttpStatusCode.OK, accountsWebApiModel);
            return response;
        }
    }
}
