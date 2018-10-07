using EmployeePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Business
{
    public class LookupBusiness
    {
        public static List<LookupOption> GetCountries() {
            return new List<LookupOption> {
                new LookupOption{ Code = 1, Value= "United States"},
                new LookupOption { Code= 2, Value= "Canada" },
                new LookupOption { Code = 3, Value ="India"}
            };
        }       
        public static List<State> GetStates(int countryId)
        {
            List<State> states = new List<State>() {
            new State { CountryID =1, StateID =1, StateName ="New York" },
            new State { CountryID =1, StateID =2, StateName ="New Jersey" },
            new State { CountryID =1, StateID =3, StateName ="New Hampshire" },
            new State { CountryID =2, StateID =4, StateName ="Toronto" },
            new State { CountryID =2, StateID =5, StateName ="Ontario" },
            new State { CountryID =3, StateID =6, StateName ="Telangana" },
            new State { CountryID =3, StateID =6, StateName ="Andhra Prades" }
        };
            return states.Where(s => s.CountryID == countryId).ToList();
        }
    }
}