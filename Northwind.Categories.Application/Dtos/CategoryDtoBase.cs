namespace Northwind.Categories.Application.Dtos
{
    public class CategoryDtoBase
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
    }
}
