namespace DesktopSchedulingApp.Models
{
    public class City : Country
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public City() { }

        public City(int cityId, string city, int countryId)
        {
            CityId = cityId;
            CityName = city;
            CountryId = countryId;
        }
    }
}
