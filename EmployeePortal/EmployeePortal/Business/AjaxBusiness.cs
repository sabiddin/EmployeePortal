using EmployeePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Business
{
    public class AjaxBusiness
    {
        private static List<State> _states = new List<State>() {
            new State {    CountryID =1, StateID =1, StateName ="New York" },
            new State {    CountryID =1, StateID =2, StateName ="New Jersey" },
            new State {    CountryID =1, StateID =3, StateName ="New Hampshire" }
        };
        public static List<State> GetStates(int countryId)
        {
            return _states.Where(s => s.CountryID == countryId).ToList();
        }

    }
}