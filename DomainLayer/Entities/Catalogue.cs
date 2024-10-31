
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
      public class Catalogue
      {
            public Catalogue() { }

            public Catalogue(int? catalogueId, string? catalogueName)
            {
                  CatalogueID = catalogueId;
                  CatalogueName = catalogueName;
            }

            [Key]
            public int? CatalogueID { get; set; }
            public string? CatalogueName { get; set; }
            public virtual ICollection<Book> Books { get; set; } = new List<Book>();
      }
}
