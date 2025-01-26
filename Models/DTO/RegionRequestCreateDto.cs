namespace NZ_Walks_web_api_project.Models.DTO
{
    public class RegionRequestCreateDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? RegionImageUrl { get; set; }
    }
}
