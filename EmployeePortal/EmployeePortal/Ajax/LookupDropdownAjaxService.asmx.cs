using EmployeePortal.Business;
using EmployeePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace EmployeePortal.Ajax
{
    /// <summary>
    /// Summary description for LookupDropdowns
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]    
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LookupDropdownAjaxService : System.Web.Services.WebService
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
