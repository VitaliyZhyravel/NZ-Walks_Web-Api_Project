namespace NZWalks.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double? LengthInKm { get; set; } 
        public Guid RegionId { get; set; } 
        public Region Region { get; set; } = null!;
        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; } = null!;

    }
}
