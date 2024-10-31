namespace ApplicationLayer.DTOs
{
    public class GenreDto
    {
        public GenreDto() { }

        public GenreDto(int id, string name, string description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }

}