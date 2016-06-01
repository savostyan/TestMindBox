namespace MindBox
{
    public class AdvCard
    {
        public const string NO_CITY = "Город не указан";

        public string CityFrom { get; set; }
        public string CityTo { get; set; }

        public AdvCard()
        {
            CityFrom = NO_CITY;
            CityTo = NO_CITY;
        }

        public AdvCard(string cityFrom, string cityTo)
        {
            CityFrom = cityFrom;
            CityTo = cityTo;
        }
    }
}
