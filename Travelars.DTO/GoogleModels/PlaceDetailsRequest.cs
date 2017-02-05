namespace Travelars.DTO.GoogleModels
{
    public class PlaceDetailsRequest
    {
        public string PlaceId { get; set; }
        public string Language { get; set; }
        public string Extensions { get; set; } = "review_summary";
    }
}
