
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
      public class BookCatalogue
      {
            public BookCatalogue() { }

            public BookCatalogue(int bookCatalogueId, int? bookId, int? catalogueId)
            {
                  BookCatalogueID = bookCatalogueId;
                  BookID = bookId;
                  CatalogueID = catalogueId;
            }
            [Key]
            public int BookCatalogueID { get; set; }
            public int? BookID { get; set; }
            public int? CatalogueID { get; set; }
      }
}
