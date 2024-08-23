namespace Ecomm.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        // Jab data seed kar rhe hai tab use m CreateData property use kar rhe hai
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
