namespace MyApiProjectTest.Models.Domain{
    public class RegionDTO{
        public Guid Id { get; set; }
        public string Code { get; set; } //Aulkin: AKL

        public string Name { get; set; }

        public string? RegionImageURL { get; set; } //Nullable
        
    }
}