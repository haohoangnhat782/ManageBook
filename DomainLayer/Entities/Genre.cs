
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
      public class Genre
      {
            public Genre() { }

            public Genre(int? id, string? name, string? description, bool? isActive)
            {
                  Id = id;
                  Name = name;
                  Description = description;
                  IsActive = isActive;
            }
            [Key]
            public int? Id { get; set; }

            public string? Name { get; set; }

            public string? Description { get; set; }

            public bool? IsActive { get; set; }
      }
}
