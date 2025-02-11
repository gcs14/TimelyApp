using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopSchedulingApp.Models
{
    public class City : Country
    {
        public int CityId {  get; set; }
        public string CityName {  get; set; }

        public City() { }

        public City(int cityId, string city, int countryId)
        {
            CityId = cityId;
            CityName = city;
            CountryId = countryId;
        }
    }
}
