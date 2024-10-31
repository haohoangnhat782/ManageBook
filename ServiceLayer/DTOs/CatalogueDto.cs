namespace ApplicationLayer.DTOs
{
    public class CatalogueDto
    {
        public CatalogueDto() { }

        public CatalogueDto(int catalogueId, string catalogueName)
        {
            CatalogueId = catalogueId;
            CatalogueName = catalogueName;
        }
        public int CatalogueId { get; set; }
        public string CatalogueName { get; set; }
    }

}