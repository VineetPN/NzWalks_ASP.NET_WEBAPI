namespace MyAPIProjectTest.Models.DTOs{

    public class UpdateRegionRequestDTO{
        
        public string Code { get; set; } //Aulkin: AKL

        public string Name { get; set; }

        public string? RegionImageURL { get; set; } //Nullable
    }
}