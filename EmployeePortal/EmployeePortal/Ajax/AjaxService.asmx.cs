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
    /// Summary description for AjaxService
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    //[System.Web.Script.Services.GenerateScriptType(typeof(State))]    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AjaxService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<State> GetStates(int countryID)
        {
            return AjaxBusiness.GetStates(countryID);
        }
    }
}
