namespace SP19.P05.Web.Features.Menus
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
    }
}