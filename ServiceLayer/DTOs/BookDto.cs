namespace ApplicationLayer.DTOs
{
    public class BookDto
    {
        public BookDto() { }

        public BookDto(int? id, string? title, string? author, string? publisher, bool? available, float? price, DateTime? createdOn, bool? isActive, int? genreId)
        {
            Id = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            Available = available;
            Price = price;
            CreatedOn = createdOn;
            IsActive = isActive;
            GenreID = genreId;
        }




        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public bool? Available { get; set; }
        public float? Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? GenreID { get; set; }
    }

}