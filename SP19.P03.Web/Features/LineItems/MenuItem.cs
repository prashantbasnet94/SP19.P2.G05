using SP19.P03.Web.Features.Menus;

namespace SP19.P03.Web.Features.LineItems
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

    }
}