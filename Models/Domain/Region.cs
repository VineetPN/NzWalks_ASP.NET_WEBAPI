namespace MyApiProjectTest.Models.Domain{
    public class Region{
        public Guid Id { get; set; }
        public string Code { get; set; } //Aulkin: AKL

        public string Name { get; set; }

        public string? RegionImageURL { get; set; } //Nullable

        public Region(Guid id, string code, string name, string? regionImageURL) 
        {
            Id = id;
            Code = code;
            Name = name;
            RegionImageURL = regionImageURL;
        }
        public Region(){
            
        }
        
    }
}