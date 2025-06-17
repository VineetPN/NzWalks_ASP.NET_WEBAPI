namespace MyApiProjectTest.Models.Domain{
    public class Walk{
        public Guid Id { get; set; }
        public string Name { get; set; } // Name of the walk

        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageURL { get; set; }
        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }

        //Navigation proporty
        public Difficulty difficulty{ get; set; }
        public Region region{ get; set; }   // One to one relation with the Region, EF is smart af to know all these things. So this is how we relate 
        
    }
}