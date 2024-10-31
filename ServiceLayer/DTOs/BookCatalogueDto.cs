namespace ApplicationLayer.DTOs
{
    public class BookCatalogue
    {
        public BookCatalogue() { }

        public BookCatalogue(int bookCatalogueId, int bookId, int catalogueId)
        {
            BookCatalogueId = bookCatalogueId;
            BookId = bookId;
            CatalogueId = catalogueId;
        }
        public int BookCatalogueId { get; set; }
        public int BookId { get; set; }
        public int CatalogueId { get; set; }
    }
}
