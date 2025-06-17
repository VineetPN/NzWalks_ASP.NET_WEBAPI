namespace MyApiProjectTest.Models.Domain.DTOs{
    public class AddRegionRequestDTO{
        
        public string Code { get; set; } //Aulkin: AKL

        public string Name { get; set; }

        public string? RegionImageURL { get; set; } //Nullable
        
    }
}