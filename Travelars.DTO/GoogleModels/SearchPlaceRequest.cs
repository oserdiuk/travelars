namespace Travelars.DTO.GoogleModels
{
    public class SearchPlaceRequest
    {
        public string Address { get; set; }
        public RankBy RankBy { get; set; }
        public string Types { get; set; }
        public string Language { get; set; }
        public string Keyword { get; set; }
        public PriceLevel? MinPrice { get; set; }
        public PriceLevel? MaxPrice { get; set; }
        public string Name { get; set; }
        public bool OpenNow { get; set; }
        public string Radius { get; set; }
    }
}
