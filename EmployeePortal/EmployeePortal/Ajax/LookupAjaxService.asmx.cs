using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using EmployeePortal.Entities;
using EmployeePortal.Business;

namespace EmployeePortal.Ajax
{
    /// <summary>
    /// Summary description for LookupAjaxService
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LookupAjaxService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<LookupOption> GetCountries()
        {
            return LookupBusiness.GetCountries();
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<State> GetStates(int countryID)
        {
            return LookupBusiness.GetStates(countryID);
        }
    }
}
