using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopSchedulingApp.Models
{
    public class Country
    {
        public int CountryId {  get; set; }
        public string CountryName {  get; set; }
        
        public Country() { }

        public Country(int countryId, string country)
        {
            CountryId = countryId;
            CountryName = country;
        }
    }
}
