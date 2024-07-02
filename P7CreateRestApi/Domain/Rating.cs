namespace Dot.Net.WebApi.Domain
{
    /// <summary>
    /// Rating DTO Class.
    /// </summary>
    /// <remarks></remarks>
    public class Rating
    {
        public int Id { get; set; }
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public byte? OrderNumber { get; set; }
    }
}